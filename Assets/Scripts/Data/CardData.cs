using UnityEngine;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.Data
{
    [CreateAssetMenu(menuName = "RogueLike/Card Data", fileName = "CardData")]
    public class CardData : ScriptableObject
    {
        [Header("Identity")]
        public string cardId;
        public string displayName;
        [TextArea] public string rulesText;

        [Header("Costs / lifecycle")]
        public int apCost = 1;
        public bool exhaust;
        public bool isConsumable;

        [Header("Personality")]
        public CardPersonalityAffinity personalityAffinity = CardPersonalityAffinity.None;
        [Min(1)] public int personalityWeight = 1;
        public CardIntent intent = CardIntent.Utility;

        [Header("Gauge effects")]
        public EnemyGaugeType primaryGaugeTarget = EnemyGaugeType.Health;
        public int primaryGaugeAmount;
        public bool useSecondaryGauge;
        public EnemyGaugeType secondaryGaugeTarget = EnemyGaugeType.Emotion;
        public int secondaryGaugeAmount;
        public bool useTertiaryGauge;
        public EnemyGaugeType tertiaryGaugeTarget = EnemyGaugeType.Awareness;
        public int tertiaryGaugeAmount;

        [Header("Combat state")]
        public bool modifiesEnemyStateToAggressive;
        public bool canBeUsedInNeutral = true;

        [Header("Defense")]
        public int blockAmount;
        [Range(0f, 1f)] public float blockPercent;
    }
}
