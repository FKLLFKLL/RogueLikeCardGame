using System.Collections.Generic;
using UnityEngine;
using AshRoad.Models;

namespace AshRoad.Data
{
    [CreateAssetMenu(menuName = "AshRoad/RewardData")]
    public class RewardData : ScriptableObject
    {
        public string id;
        public List<RewardGrant> grants = new();
    }
}
