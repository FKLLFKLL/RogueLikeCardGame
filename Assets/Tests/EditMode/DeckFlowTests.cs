using NUnit.Framework;
using AshRoad.Combat;
using AshRoad.Data;
using UnityEngine;

namespace AshRoad.Tests
{
    public class DeckFlowTests
    {
        [Test]
        public void Draw_Discard_Exhaust_Behave()
        {
            var c1 = ScriptableObject.CreateInstance<CardData>();
            var c2 = ScriptableObject.CreateInstance<CardData>();
            var deck = new DeckManager();
            deck.Initialize(new[] { c1, c2 });
            var drawn = deck.DrawOne();
            deck.Discard(drawn);
            deck.Exhaust(c2);
            Assert.AreEqual(1, deck.DiscardPile.Count);
            Assert.AreEqual(1, deck.ExhaustPile.Count);
        }
    }
}
