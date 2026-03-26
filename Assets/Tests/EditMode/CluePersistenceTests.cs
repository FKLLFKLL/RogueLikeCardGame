using NUnit.Framework;
using AshRoad.Models;

namespace AshRoad.Tests
{
    public class CluePersistenceTests
    {
        [Test]
        public void CluesPersistInDataContainer()
        {
            var d = new StoryProgressData();
            d.clues.Add("clue_signal_01");
            Assert.True(d.clues.Contains("clue_signal_01"));
        }
    }
}
