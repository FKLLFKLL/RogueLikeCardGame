using System.Collections.Generic;
using UnityEngine;
using AshRoad.Models;
using AshRoad.Shared;

namespace AshRoad.Data
{
    [CreateAssetMenu(menuName = "AshRoad/EventChoiceData")]
    public class EventChoiceData : ScriptableObject
    {
        public string id;
        public string text;
        public List<RequirementCheck> requirements = new();
        public List<RewardGrant> rewards = new();
        public PersonalityType personalityShiftType;
        public int personalityShiftAmount;
        public string nextSceneId;
    }
}
