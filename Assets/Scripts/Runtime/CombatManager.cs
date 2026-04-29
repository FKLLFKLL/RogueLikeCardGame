using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RogueLikeCardGame.Data;
using RogueLikeCardGame.Shared;
using RogueLikeCardGame.Story;

namespace RogueLikeCardGame.Runtime
{
    public class CombatManager : MonoBehaviour
    {
        private const int ApPerTurn = 3;
        private const int DrawPerTurn = 5;
        private const int MaxHandSize = 10;

        private readonly List<CardData> drawPile = new();
        private readonly List<CardData> discardPile = new();
        private readonly List<CardData> exhaustPile = new();
        private readonly List<CardData> hand = new();

        private EnemyRuntime enemy;
        private int playerAp;

        private void Start()
        {
            if (RunState.Instance == null || RunState.Instance.PendingEnemy == null)
            {
                Debug.LogWarning("[Combat] Missing pending encounter. Returning to map.");
                SceneManager.LoadScene("MapScene");
                return;
            }

            StartEncounter(RunState.Instance.PendingEnemy);
            RunState.Instance.ClearPendingEnemy();
        }

        public void StartEncounter(EnemyData enemyData)
        {
            enemy = new EnemyRuntime(enemyData);
            drawPile.Clear(); discardPile.Clear(); exhaustPile.Clear(); hand.Clear();
            drawPile.AddRange(RunState.Instance.Deck);
            Shuffle(drawPile);
            BeginTurn();
            DebugState("Encounter started");
        }

        public void BeginTurn()
        {
            playerAp = ApPerTurn;
            DrawCards(DrawPerTurn);
        }

        public bool TryPlayCard(CardData card)
        {
            if (card == null || !hand.Contains(card) || playerAp < card.apCost) return false;
            playerAp -= card.apCost;
            hand.Remove(card);

            // Aggression formula: damage taken multiplier = 1 + aggression * enemyData.aggressionVulnerabilityScaling
            int dealtDamage = Mathf.RoundToInt(card.damageAmount * enemy.GetDamageMultiplierAgainstEnemy());
            enemy.ModifyHealth(-dealtDamage);
            enemy.ModifyAggression(card.aggressionModification);
            enemy.ApplyStatus(card.statusEffect, card.statusDuration);

            if (card.isConsumable) exhaustPile.Add(card); else discardPile.Add(card);
            Debug.Log($"[Combat] Played {card.displayName}. Damage:{dealtDamage} EnemyHP:{enemy.Health} Aggro:{enemy.Aggression}");

            if (enemy.Health <= 0) HandleVictory();
            return true;
        }

        public void EndPlayerTurn()
        {
            ResolveEnemyTurn();
            if (RunState.Instance.PlayerHp <= 0)
            {
                Debug.Log("[Combat] Player defeated.");
                RunState.Instance.InFinalBossCombat = false;
                SceneManager.LoadScene("MainMenu");
                return;
            }

            DiscardHand();
            BeginTurn();
            DebugState("Turn advanced");
        }

        private void ResolveEnemyTurn()
        {
            if (enemy.ShouldSkipTurnFromStun())
            {
                Debug.Log("[Combat] Stun: enemy skips turn.");
                return;
            }

            // Aggression formula: outgoing damage = baseDamage * (1 + aggression * enemyData.aggressionDamageScaling)
            int outgoingDamage = Mathf.RoundToInt(enemy.Data.baseAttackDamage * enemy.GetOutgoingDamageMultiplier());
            RunState.Instance.ModifyHp(-outgoingDamage);
            Debug.Log($"[Combat] Enemy attacks for {outgoingDamage}. Player HP now {RunState.Instance.PlayerHp}.");
        }

        private void HandleVictory()
        {
            if (!RunState.Instance.InFinalBossCombat)
            {
                Debug.Log("[Combat] Encounter won, returning to map.");
                SceneManager.LoadScene("MapScene");
                return;
            }

            ReunionEvaluationResult result = new ReunionOutcomeEvaluator().EvaluateByCards(RunState.Instance.Deck, null);
            string ending = result.IsTie
                ? "[Ending] Mixed reunion: unresolved but hopeful understanding."
                : result.DominantAffinity switch
                {
                    CardPersonalityAffinity.Nerve => "[Ending] Nerve ending: confrontational reunion.",
                    CardPersonalityAffinity.Heart => "[Ending] Heart ending: emotional reconciliation.",
                    CardPersonalityAffinity.Wits => "[Ending] Wits ending: cautious, clever reunion.",
                    _ => "[Ending] Mixed reunion placeholder."
                };

            Debug.Log(ending);
            RunState.Instance.InFinalBossCombat = false;
            SceneManager.LoadScene("MetaHubScene");
            // TODO(UI): Replace log ending with dedicated ending scene + authored narrative text.
        }

        private void DrawCards(int amount)
        {
            for (int i = 0; i < amount && hand.Count < MaxHandSize; i++)
            {
                if (drawPile.Count == 0) RefillDrawPile();
                if (drawPile.Count == 0) break;
                CardData card = drawPile[0];
                drawPile.RemoveAt(0);
                hand.Add(card);
            }
        }

        private void DiscardHand()
        {
            discardPile.AddRange(hand);
            hand.Clear();
        }

        private void RefillDrawPile()
        {
            drawPile.AddRange(discardPile);
            discardPile.Clear();
            Shuffle(drawPile);
        }

        private static void Shuffle(List<CardData> cards)
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int swap = Random.Range(0, i + 1);
                (cards[i], cards[swap]) = (cards[swap], cards[i]);
            }
        }

        private void DebugState(string prefix)
        {
            Debug.Log($"[Combat] {prefix} | AP:{playerAp} PlayerHP:{RunState.Instance.PlayerHp} EnemyHP:{enemy.Health} EnemyAggro:{enemy.Aggression} Hand:{hand.Count}/{MaxHandSize}");
        }
    }
}
