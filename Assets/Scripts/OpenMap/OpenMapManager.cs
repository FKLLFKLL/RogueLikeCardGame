using System.Collections.Generic;
using UnityEngine;

namespace RogueLikeCardGame.OpenMap
{
    public class OpenMapManager : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawn;
        [SerializeField] private BoundaryTrigger boundaryTrigger;
        [SerializeField] private FinalBossEncounter finalBossEncounter;

        private readonly List<MapEnemyWalker> spawnedEnemies = new();

        private void Start()
        {
            if (boundaryTrigger != null)
            {
                boundaryTrigger.OnBoundaryReached += TriggerFinalBoss;
            }
        }

        public void RegisterEnemy(MapEnemyWalker walker)
        {
            if (walker != null && !spawnedEnemies.Contains(walker)) spawnedEnemies.Add(walker);
        }

        public Vector3 GetSpawnPosition() => playerSpawn != null ? playerSpawn.position : Vector3.zero;

        private void TriggerFinalBoss()
        {
            // TODO: Add story/dialogue reveal flow that missing best friend is the final boss.
            finalBossEncounter?.BeginEncounter();
        }
    }
}
