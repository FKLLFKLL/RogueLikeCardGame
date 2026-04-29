using UnityEngine;
using RogueLikeCardGame.Data;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.Runtime
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] private EnemyData encounterEnemy;

        private const int ApPerTurn = 3;
        private const int DrawTarget = 5;
        private const int MaxHandSize = 10;

        private EnemyRuntime enemy;
        private int playerAp;
        private int temporaryBlock;
        private float temporaryBlockPercent;

        public EnemyRuntime Enemy => enemy;
        public int PlayerAp => playerAp;

        private void Start()
        {
            StartEncounter(encounterEnemy);
        }

        public void StartEncounter(EnemyData enemyData)
        {
            enemy = new EnemyRuntime(enemyData);
            playerAp = ApPerTurn;
            temporaryBlock = 0;
            temporaryBlockPercent = 0f;
            DrawCards(DrawTarget);
            DebugState("Encounter started");
        }

        public bool TryPlayCard(CardData card)
        {
            if (card == null || playerAp < card.apCost)
            {
                return false;
            }

            if (enemy.CombatState == EnemyCombatState.Neutral && !card.canBeUsedInNeutral)
            {
                Debug.Log($"[Combat] Card blocked in neutral state: {card.displayName}");
                return false;
            }

            playerAp -= card.apCost;
            ResolveCard(card);

            bool won = IsEncounterWon();
            if (!won)
            {
                DebugState($"Played {card.displayName}");
            }

            return true;
        }

        private void ResolveCard(CardData card)
        {
            enemy.ModifyGauge(card.primaryGaugeTarget, card.primaryGaugeAmount);

            if (card.useSecondaryGauge)
            {
                enemy.ModifyGauge(card.secondaryGaugeTarget, card.secondaryGaugeAmount);
            }

            if (card.useTertiaryGauge)
            {
                enemy.ModifyGauge(card.tertiaryGaugeTarget, card.tertiaryGaugeAmount);
            }

            if (card.blockAmount > 0)
            {
                temporaryBlock += card.blockAmount;
            }

            if (card.blockPercent > 0f)
            {
                temporaryBlockPercent = Mathf.Clamp01(temporaryBlockPercent + card.blockPercent);
            }

            if (card.modifiesEnemyStateToAggressive && enemy.CombatState == EnemyCombatState.Neutral)
            {
                enemy.SetAggressive();
            }

            Debug.Log($"[Combat] {card.displayName} resolved. Gauges H:{enemy.Health} E:{enemy.Emotion} A:{enemy.Awareness}");
        }

        public void EndPlayerTurn()
        {
            ExecuteEnemyTurn();
            playerAp = ApPerTurn;
            temporaryBlock = 0;
            temporaryBlockPercent = 0f;
            DrawCards(DrawTarget);
            DebugState("Turn advanced");
        }

        private void ExecuteEnemyTurn()
        {
            if (enemy.CombatState == EnemyCombatState.Neutral)
            {
                Debug.Log("[Combat] Neutral enemy hesitates and does not attack.");
                return;
            }

            int damage = enemy.Data.aggressiveAttackDamage;

            if (enemy.Emotion <= enemy.Data.lowEmotionThreshold)
            {
                damage = Mathf.Max(0, damage - 2);
            }
            else if (enemy.Emotion >= enemy.Data.highEmotionThreshold)
            {
                damage += 2;
            }

            if (enemy.Awareness <= enemy.Data.lowAwarenessThreshold)
            {
                damage = Mathf.Max(0, damage - 2);
            }

            int percentBlocked = Mathf.RoundToInt(damage * temporaryBlockPercent);
            int reducedByBlock = Mathf.Min(temporaryBlock + percentBlocked, damage);
            int finalDamage = damage - reducedByBlock;

            Debug.Log($"[Combat] Enemy attacks for {damage} ({reducedByBlock} blocked). Player takes {finalDamage}.");
        }

        private bool IsEncounterWon()
        {
            bool won = enemy.Health <= 0 || enemy.Emotion <= 0 || enemy.Awareness <= 0;
            if (won)
            {
                Debug.Log($"[Combat] Victory! H:{enemy.Health} E:{enemy.Emotion} A:{enemy.Awareness}");
            }

            return won;
        }

        private void DrawCards(int count)
        {
            int drawCount = Mathf.Clamp(count, 0, MaxHandSize);
            Debug.Log($"[Combat] Draw {drawCount} cards (target hand size {DrawTarget}, max {MaxHandSize}).");
        }

        private void DebugState(string prefix)
        {
            Debug.Log($"[Combat] {prefix} | AP:{playerAp} EnemyState:{enemy.CombatState} H:{enemy.Health} E:{enemy.Emotion} A:{enemy.Awareness}");
        }
    }
}
