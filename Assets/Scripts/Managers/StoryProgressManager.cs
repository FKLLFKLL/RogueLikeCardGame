using System.Collections.Generic;
using UnityEngine;
using AshRoad.Models;

namespace AshRoad.Managers
{
    public class StoryProgressManager : MonoBehaviour
    {
        public List<string> requiredTrueEndingGroups = new() { "friend", "signal", "convoy" };
        public StoryProgressData Data { get; private set; } = new();

        public void LoadPersistent() => Data = GameManager.Instance.SaveManager.LoadStory();
        public void SavePersistent() => GameManager.Instance.SaveManager.SaveStory(Data);

        public void AddClue(string clueId, string groupId)
        {
            Data.clues.Add(clueId);
            if (!string.IsNullOrWhiteSpace(groupId))
            {
                Data.clueGroups.Add(groupId);
            }

            EvaluateTrueEnding(Data.clueGroups);
        }

        public void UnlockScene(string sceneId) => Data.scenes.Add(sceneId);

        public void EvaluateTrueEnding(HashSet<string> knownGroups)
        {
            if (knownGroups == null)
            {
                Data.trueEndingEligible = false;
                return;
            }

            if (requiredTrueEndingGroups == null || requiredTrueEndingGroups.Count == 0)
            {
                Data.trueEndingEligible = false;
                return;
            }

            bool met = true;
            foreach (var group in requiredTrueEndingGroups) if (!knownGroups.Contains(group)) met = false;
            Data.trueEndingEligible = met;
        }
    }
}
