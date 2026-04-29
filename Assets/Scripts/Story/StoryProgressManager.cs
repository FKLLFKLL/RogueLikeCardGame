using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueLikeCardGame.Story
{
    public class StoryProgressManager : MonoBehaviour
    {
        [SerializeField] private string[] requiredTrueEndingClueGroups;

        private readonly HashSet<string> discoveredClueGroups = new();
        private readonly List<string> collectedCardIds = new();

        public IReadOnlyCollection<string> DiscoveredClueGroups => discoveredClueGroups;
        public IReadOnlyList<string> CollectedCardIds => collectedCardIds;

        public void AddClue(string clueGroup)
        {
            if (string.IsNullOrWhiteSpace(clueGroup))
            {
                return;
            }

            discoveredClueGroups.Add(clueGroup);

            // Fix: evaluate true ending against all discovered groups, not only the newest clue.
            bool isTrueEndingEligible = requiredTrueEndingClueGroups.All(group => discoveredClueGroups.Contains(group));
            Debug.Log($"[Story] Added clue group {clueGroup}. True ending eligible: {isTrueEndingEligible}");
        }

        public void RecordCollectedCard(string cardId)
        {
            if (!string.IsNullOrWhiteSpace(cardId))
            {
                collectedCardIds.Add(cardId);
            }
        }
    }
}
