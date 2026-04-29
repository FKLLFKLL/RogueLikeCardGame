using NUnit.Framework;
using AshRoad.Combat;
using AshRoad.Data;
using AshRoad.Shared;
using UnityEngine;

namespace AshRoad.Tests
{
    public class CombatApTests
    {
        [Test]
        public void CannotPlayWithoutEnoughAp()
        {
            var go = new GameObject();
            var mgr = go.AddComponent<CombatManager>();
            var encounter = ScriptableObject.CreateInstance<EncounterData>();
            encounter.goalType = CombatGoalType.Escape;
            var expensive = ScriptableObject.CreateInstance<CardData>();
            expensive.apCost = 4;
            mgr.StartEncounter(encounter, new System.Collections.Generic.List<CardData> { expensive });
            Assert.False(mgr.TryPlayCard(expensive));
        }
    }
}
