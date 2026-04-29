using System.Collections.Generic;
using UnityEngine;
using AshRoad.Shared;

namespace AshRoad.Data
{
    [CreateAssetMenu(menuName = "AshRoad/EncounterData")]
    public class EncounterData : ScriptableObject
    {
        public string id;
        public EncounterType encounterType;
        public CombatGoalType goalType = CombatGoalType.DefeatAll;
        public int surviveTurnTarget = 3;
        public List<EnemyData> enemies = new();
    }
}
