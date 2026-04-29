using UnityEngine;
using RogueLikeCardGame.Data;

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

        public EnemyRuntime Enemy => enemy;
        public int PlayerAp => playerAp;

        private void Start() => StartEncounter(encounterEnemy);

        public void StartEncounter(EnemyData enemyData)
        {
            enemy = new EnemyRuntime(enemyData);
            playerAp = ApPerTurn;
            temporaryBlock = 0;
            DrawCards(DrawTarget);
            DebugState("Encounter started");
        }

        public bool TryPlayCard(CardData card)
        {
            if (card == null || playerAp < card.apCost) return false;
            playerAp -= card.apCost;

            int damage = Mathf.RoundToInt(card.damageAmount * enemy.GetDamageMultiplierAgainstEnemy());
            enemy.ModifyHealth(-damage);
            enemy.ModifyAggression(card.aggressionModification);
            enemy.ApplyStatus(card.statusEffect, card.statusDuration);
            temporaryBlock += card.blockAmount;

            if (!IsEncounterWon()) DebugState($"Played {card.displayName}");
            return true;
        }

        public void EndPlayerTurn()
        {
            ExecuteEnemyTurn();
            playerAp = ApPerTurn;
            temporaryBlock = 0;
            DrawCards(DrawTarget);
            DebugState("Turn advanced");
        }

        private void ExecuteEnemyTurn()
        {
            if (enemy.ShouldSkipTurnFromStun())
            {
                Debug.Log("[Combat] Enemy is stunned and skips turn.");
                return;
            }

            if (enemy.ShouldMissTurnFromBlind() && Random.value <= 0.5f)
            {
                Debug.Log("[Combat] Enemy attack missed from blind.");
                return;
            }

            int damage = Mathf.RoundToInt(enemy.Data.baseAttackDamage * enemy.GetOutgoingDamageMultiplier());
            int reducedByBlock = Mathf.Min(temporaryBlock, damage);
            int finalDamage = damage - reducedByBlock;
            Debug.Log($"[Combat] Enemy attacks for {damage} ({reducedByBlock} blocked). Player takes {finalDamage}.");
        }

        private bool IsEncounterWon()
        {
            bool won = enemy.Health <= 0;
            if (won) Debug.Log($"[Combat] Victory! Enemy HP:{enemy.Health} Aggression:{enemy.Aggression}");
            return won;
        }

        private static void DrawCards(int count)
        {
            int drawCount = Mathf.Clamp(count, 0, MaxHandSize);
            Debug.Log($"[Combat] Draw {drawCount} cards (target hand size {DrawTarget}, max {MaxHandSize}).");
        }

        private void DebugState(string prefix)
        {
            Debug.Log($"[Combat] {prefix} | AP:{playerAp} Enemy HP:{enemy.Health} Aggression:{enemy.Aggression}");
        }
    }
}
