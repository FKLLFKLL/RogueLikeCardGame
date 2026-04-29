using System.Collections.Generic;
using AshRoad.Data;

namespace AshRoad.Combat
{
    public class DeckManager
    {
        public readonly List<CardData> DrawPile = new();
        public readonly List<CardData> DiscardPile = new();
        public readonly List<CardData> ExhaustPile = new();

        public void Initialize(IEnumerable<CardData> cards)
        {
            DrawPile.Clear(); DiscardPile.Clear(); ExhaustPile.Clear();
            DrawPile.AddRange(cards);
        }

        public CardData DrawOne()
        {
            if (DrawPile.Count == 0) Reshuffle();
            if (DrawPile.Count == 0) return null;
            var top = DrawPile[0];
            DrawPile.RemoveAt(0);
            return top;
        }

        public void Discard(CardData c) => DiscardPile.Add(c);
        public void Exhaust(CardData c) => ExhaustPile.Add(c);

        private void Reshuffle()
        {
            DrawPile.AddRange(DiscardPile);
            DiscardPile.Clear();
        }
    }
}
