using System.Collections.Generic;
using UnityEngine;
using AshRoad.Data;
using AshRoad.Shared;

namespace AshRoad.Map
{
    public class MapManager : MonoBehaviour
    {
        public RegionData activeRegion;
        public NodeData currentNode;
        private readonly Dictionary<string, NodeData> nodeLookup = new();

        public void BuildRegion(RegionData region)
        {
            activeRegion = region;
            nodeLookup.Clear();
            foreach (var n in region.nodes) nodeLookup[n.id] = n;
            currentNode = nodeLookup[region.startNodeId];
        }

        public bool TryTravelTo(string nodeId)
        {
            if (!currentNode.nextNodeIds.Contains(nodeId)) return false;
            var next = nodeLookup[nodeId];
            if (!Managers.GameManager.Instance.RunManager.Resources.Spend(ResourceType.Food, next.foodCost)) return false;
            currentNode = next;
            return true;
        }
    }
}
