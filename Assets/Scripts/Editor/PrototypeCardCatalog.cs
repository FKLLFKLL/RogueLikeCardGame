using System.Collections.Generic;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.EditorTools
{
    // Lightweight scaffolding reference for starter cards in HP + Aggression combat model.
    public static class PrototypeCardCatalog
    {
        public static readonly IReadOnlyList<PrototypeCardDefinition> StarterCards = new List<PrototypeCardDefinition>
        {
            new("strike", "Strike", CardPersonalityAffinity.Nerve, damage: 8, aggressionDelta: 1),
            new("guard", "Guard", CardPersonalityAffinity.Nerve, block: 6),
            new("calm_words", "Calm Words", CardPersonalityAffinity.Heart, aggressionDelta: -3),
            new("rattle", "Rattle", CardPersonalityAffinity.Heart, damage: 4, aggressionDelta: 2),
            new("flash_powder", "Flash Powder", CardPersonalityAffinity.Wits, status: StatusEffectType.Blind, statusDuration: 1),
            new("tripwire", "Tripwire", CardPersonalityAffinity.Wits, status: StatusEffectType.Stun, statusDuration: 1),
        };
    }

    public readonly struct PrototypeCardDefinition
    {
        public string CardId { get; }
        public string Name { get; }
        public CardPersonalityAffinity Affinity { get; }
        public int Damage { get; }
        public int AggressionDelta { get; }
        public int Block { get; }
        public StatusEffectType Status { get; }
        public int StatusDuration { get; }

        public PrototypeCardDefinition(string cardId, string name, CardPersonalityAffinity affinity, int damage = 0, int aggressionDelta = 0, int block = 0, StatusEffectType status = StatusEffectType.None, int statusDuration = 0)
        {
            CardId = cardId;
            Name = name;
            Affinity = affinity;
            Damage = damage;
            AggressionDelta = aggressionDelta;
            Block = block;
            Status = status;
            StatusDuration = statusDuration;
        }
    }
}
