using System.Collections.Generic;
using UnityEngine;
using AshRoad.Shared;

namespace AshRoad.Data
{
    [CreateAssetMenu(menuName = "AshRoad/NodeData")]
    public class NodeData : ScriptableObject
    {
        public string id;
        public NodeType nodeType;
        public List<string> nextNodeIds = new();
        public string linkedContentId;
        public int foodCost = 1;
    }
}
