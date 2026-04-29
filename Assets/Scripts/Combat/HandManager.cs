using System.Collections.Generic;
using AshRoad.Data;

namespace AshRoad.Combat
{
    public class HandManager
    {
        public readonly List<CardData> Hand = new();
        public int MaxHandSize = 5;
        public void DrawToFull(DeckManager deck)
        {
            while (Hand.Count < MaxHandSize)
            {
                var c = deck.DrawOne();
                if (c == null) break;
                Hand.Add(c);
            }
        }
    }
}
