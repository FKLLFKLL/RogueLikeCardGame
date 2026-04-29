using System.Collections.Generic;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.EditorTools
{
    // Lightweight scaffolding reference for starter cards.
    // TODO: Replace with authored assets in the production content pipeline.
    public static class PrototypeCardCatalog
    {
        public static readonly IReadOnlyList<PrototypeCardDefinition> StarterCards = new List<PrototypeCardDefinition>
        {
            new("strike", "Strike", CardPersonalityAffinity.Nerve, CardIntent.Attack, EnemyGaugeType.Health, -8, true, true, EnemyGaugeType.Emotion, +4),
            new("block", "Block", CardPersonalityAffinity.Nerve, CardIntent.Defend, EnemyGaugeType.Health, 0, false, false, EnemyGaugeType.Health, 0, blockAmount: 6),
            new("negotiate", "Negotiate", CardPersonalityAffinity.Heart, CardIntent.Negotiate, EnemyGaugeType.Emotion, -10, false, false, EnemyGaugeType.Health, 0),
            new("praise", "Praise", CardPersonalityAffinity.Heart, CardIntent.Negotiate, EnemyGaugeType.Emotion, -7, false, true, EnemyGaugeType.Awareness, -3),
            new("hide", "Hide", CardPersonalityAffinity.Wits, CardIntent.Stealth, EnemyGaugeType.Awareness, -12, false, false, EnemyGaugeType.Health, 0),
            new("distraction", "Distraction", CardPersonalityAffinity.Wits, CardIntent.Stealth, EnemyGaugeType.Awareness, -8, false, true, EnemyGaugeType.Emotion, +3),
            new("intimidate", "Intimidate", CardPersonalityAffinity.Nerve, CardIntent.Utility, EnemyGaugeType.Awareness, -6, false, true, EnemyGaugeType.Emotion, +5),
            new("acid_flask", "Acid Flask", CardPersonalityAffinity.Wits, CardIntent.Attack, EnemyGaugeType.Health, -9, true, true, EnemyGaugeType.Awareness, -4, true, EnemyGaugeType.Emotion, +4, consumable: true),
        };
    }

    public readonly struct PrototypeCardDefinition
    {
        public string CardId { get; }
        public string Name { get; }
        public CardPersonalityAffinity Affinity { get; }
        public CardIntent Intent { get; }
        public EnemyGaugeType PrimaryGauge { get; }
        public int PrimaryAmount { get; }
        public bool ForcesAggressive { get; }
        public bool UsesSecondary { get; }
        public EnemyGaugeType SecondaryGauge { get; }
        public int SecondaryAmount { get; }
        public bool UsesTertiary { get; }
        public EnemyGaugeType TertiaryGauge { get; }
        public int TertiaryAmount { get; }
        public int BlockAmount { get; }
        public bool Consumable { get; }

        public PrototypeCardDefinition(
            string cardId,
            string name,
            CardPersonalityAffinity affinity,
            CardIntent intent,
            EnemyGaugeType primaryGauge,
            int primaryAmount,
            bool forcesAggressive,
            bool usesSecondary,
            EnemyGaugeType secondaryGauge,
            int secondaryAmount,
            bool usesTertiary = false,
            EnemyGaugeType tertiaryGauge = EnemyGaugeType.Health,
            int tertiaryAmount = 0,
            int blockAmount = 0,
            bool consumable = false)
        {
            CardId = cardId;
            Name = name;
            Affinity = affinity;
            Intent = intent;
            PrimaryGauge = primaryGauge;
            PrimaryAmount = primaryAmount;
            ForcesAggressive = forcesAggressive;
            UsesSecondary = usesSecondary;
            SecondaryGauge = secondaryGauge;
            SecondaryAmount = secondaryAmount;
            UsesTertiary = usesTertiary;
            TertiaryGauge = tertiaryGauge;
            TertiaryAmount = tertiaryAmount;
            BlockAmount = blockAmount;
            Consumable = consumable;
        }
    }
}
