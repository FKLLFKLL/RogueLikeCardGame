using NUnit.Framework;
using AshRoad.Models;
using AshRoad.Shared;

namespace AshRoad.Tests
{
    public class PersonalityChoiceTests
    {
        [Test]
        public void PersonalityShiftChangesValue()
        {
            var p = new PersonalityState();
            p.Add(PersonalityType.Heart, 2);
            Assert.AreEqual(2, p.Heart);
        }
    }
}
