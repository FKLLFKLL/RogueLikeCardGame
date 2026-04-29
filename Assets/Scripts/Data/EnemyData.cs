using UnityEngine;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.Data
{
    public enum NeutralBehaviorType
    {
        Wait = 0,
        Warn = 1,
        Patrol = 2
    }

    [CreateAssetMenu(menuName = "RogueLike/Enemy Data", fileName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public string enemyId;
        public string displayName;

        [Header("Core gauges")]
        public int maxHealth = 30;
        [Range(0, 100)] public int startingEmotion = 50;
        [Range(0, 100)] public int startingAwareness = 50;

        [Header("Combat behavior")]
        public EnemyCombatState startingCombatState = EnemyCombatState.Neutral;
        public int aggressiveAttackDamage = 6;
        public NeutralBehaviorType neutralBehaviorType = NeutralBehaviorType.Wait;

        [Header("Threshold hints")]
        [Range(0, 100)] public int lowEmotionThreshold = 20;
        [Range(0, 100)] public int highEmotionThreshold = 80;
        [Range(0, 100)] public int lowAwarenessThreshold = 20;
    }
}
