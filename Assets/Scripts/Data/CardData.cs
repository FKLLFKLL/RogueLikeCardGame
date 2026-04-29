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
        public bool isConsumable;

        [Header("Personality")]
        public CardPersonalityAffinity personalityAffinity = CardPersonalityAffinity.None;
        [Min(1)] public int personalityWeight = 1;

        [Header("Combat effects")]
        public int damageAmount;
        public int aggressionModification;
        public int blockAmount;
        public StatusEffectType statusEffect = StatusEffectType.None;
        [Min(0)] public int statusDuration;
    }
}
