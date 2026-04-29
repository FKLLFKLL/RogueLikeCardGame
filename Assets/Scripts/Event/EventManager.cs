using UnityEngine;
using AshRoad.Data;
using AshRoad.Models;

namespace AshRoad.Event
{
    public class EventManager : MonoBehaviour
    {
        public EventData ActiveEvent { get; private set; }

        public void SetEvent(EventData data) => ActiveEvent = data;

        public bool CanTakeChoice(EventChoiceData choice)
        {
            foreach (RequirementCheck req in choice.requirements)
            {
                if (req.amount > 0 && Managers.GameManager.Instance.RunManager.Resources.Get(req.resource) < req.amount) return false;
                if (!string.IsNullOrEmpty(req.requiredClueId) && !Managers.GameManager.Instance.StoryProgressManager.Data.clues.Contains(req.requiredClueId)) return false;
                if (req.minPersonality > 0 && Managers.GameManager.Instance.RunManager.Personality.Get(req.personality) < req.minPersonality) return false;
            }
            return true;
        }

        public void ResolveChoice(EventChoiceData choice)
        {
            if (!CanTakeChoice(choice)) return;
            Managers.GameManager.Instance.RunManager.Personality.Add(choice.personalityShiftType, choice.personalityShiftAmount);
            foreach (var reward in choice.rewards)
            {
                if (reward.amount != 0) Managers.GameManager.Instance.RunManager.Resources.Add(reward.resource, reward.amount);
                if (!string.IsNullOrEmpty(reward.clueId)) Managers.GameManager.Instance.StoryProgressManager.Data.clues.Add(reward.clueId);
            }
        }
    }
}
