using UnityEngine;
using RogueLikeCardGame.Runtime;
using RogueLikeCardGame.Story;

namespace RogueLikeCardGame.Debugging
{
    public class PrototypeDebugHUD : MonoBehaviour
    {
        [SerializeField] private CombatManager combatManager;
        [SerializeField] private StoryProgressManager storyProgressManager;
        [SerializeField] private ResourceManager resourceManager;

        private readonly ReunionOutcomeEvaluator evaluator = new();

        [ContextMenu("Log Reunion Outcome")]
        public void LogReunionOutcome()
        {
            var result = evaluator.EvaluateByCards(storyProgressManager.CollectedCardIds, resourceManager);
            Debug.Log($"[DebugHUD] Reunion dominant: {result.DominantAffinity}, runner-up: {result.RunnerUpAffinity}, tone: {result.Tone}");
        }

        [ContextMenu("Log Combat Snapshot")]
        public void LogCombatSnapshot()
        {
            if (combatManager?.Enemy == null)
            {
                Debug.Log("[DebugHUD] Combat data unavailable.");
                return;
            }

            Debug.Log($"[DebugHUD] AP:{combatManager.PlayerAp}, Enemy HP:{combatManager.Enemy.Health}, Aggression:{combatManager.Enemy.Aggression}");
        }
    }
}
