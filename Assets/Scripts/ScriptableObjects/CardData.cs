using System.Collections.Generic;
using UnityEngine;
using AshRoad.Shared;

namespace AshRoad.Data
{
    [CreateAssetMenu(menuName = "AshRoad/CardData")]
    public class CardData : ScriptableObject
    {
        public string id;
        public string displayName;
        public CardType cardType;
        public CardRarity rarity;
        public List<CardTag> tags = new();
        public int apCost = 1;
        public int damage;
        public int block;
        public int draw;
        public bool exhaust;
        [TextArea] public string rulesText;
    }
}
