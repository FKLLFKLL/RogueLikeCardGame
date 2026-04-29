using UnityEngine;

namespace AshRoad.Data
{
    [CreateAssetMenu(menuName = "AshRoad/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public string id;
        public string displayName;
        public int maxHp = 20;
        public int attackDamage = 5;
        public int defendAmount = 3;
        public bool alternatesBehavior = true;
    }
}
