using System.Collections.Generic;
using UnityEngine;

namespace AshRoad.Data
{
    [CreateAssetMenu(menuName = "AshRoad/RegionData")]
    public class RegionData : ScriptableObject
    {
        public string id;
        public string displayName;
        public List<NodeData> nodes = new();
        public string startNodeId;
    }
}
