using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RogueLikeCardGame.Data;

namespace RogueLikeCardGame.Runtime
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private CardData[] cardDatabase;

        private Dictionary<string, CardData> cardLookup;

        private void Awake()
        {
            cardLookup = cardDatabase
                .Where(card => card != null && !string.IsNullOrWhiteSpace(card.cardId))
                .GroupBy(card => card.cardId)
                .ToDictionary(group => group.Key, group => group.First());
        }

        public CardData ResolveCard(string cardId)
        {
            if (string.IsNullOrWhiteSpace(cardId) || cardLookup == null)
            {
                return null;
            }

            cardLookup.TryGetValue(cardId, out CardData card);
            return card;
        }
    }
}
