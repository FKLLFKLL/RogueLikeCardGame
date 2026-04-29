using UnityEngine;

namespace AshRoad.Map
{
    // Legacy node-map manager retained only as a compatibility shell.
    // Open-world exploration now lives in RogueLikeCardGame.OpenMap.OpenMapManager.
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private bool logDeprecationWarning = true;

        private void Start()
        {
            if (logDeprecationWarning)
            {
                Debug.LogWarning("[Map] Node-based map flow is deprecated. Use OpenMapManager for 2D exploration runs.");
            }
        }
    }
}
