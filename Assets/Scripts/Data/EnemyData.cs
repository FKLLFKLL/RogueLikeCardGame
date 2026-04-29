using UnityEngine;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.Data
{
    public enum MapPatrolBehavior
    {
        Idle = 0,
        Patrol = 1,
        Roam = 2
    }

    [CreateAssetMenu(menuName = "RogueLike/Enemy Data", fileName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public string enemyId;
        public string displayName;

        [Header("Core gauges")]
        public int maxHp = 30;
        public int startingAggression = 2;

        [Header("Combat behavior")]
        public int baseAttackDamage = 6;
        public float aggressionDamageScaling = 0.15f;
        public float aggressionVulnerabilityScaling = 0.1f;

        [Header("Map behavior")]
        public MapPatrolBehavior patrolBehavior = MapPatrolBehavior.Patrol;
        public float patrolSpeed = 1.2f;
        public float patrolRadius = 4f;
    }
}
