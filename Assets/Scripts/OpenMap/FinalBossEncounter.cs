using UnityEngine;
using UnityEngine.SceneManagement;
using RogueLikeCardGame.Data;
using RogueLikeCardGame.Runtime;
using RogueLikeCardGame.Story;

namespace RogueLikeCardGame.OpenMap
{
    public class FinalBossEncounter : MonoBehaviour
    {
        [SerializeField] private EnemyData finalBossEnemy;

        public void BeginEncounter()
        {
            if (RunState.Instance == null || finalBossEnemy == null) return;
            Debug.Log("[FinalBoss] Boundary reached. Starting friend boss encounter.");
            RunState.Instance.QueueCombat(finalBossEnemy, true);
            SceneManager.LoadScene("CombatScene");
            // TODO(Story): Replace with reveal conversation before loading combat.
        }

        public ReunionEvaluationResult ResolveEndingByDeck(ResourceManager resourceManager)
        {
            return new ReunionOutcomeEvaluator().EvaluateByCards(RunState.Instance.Deck, resourceManager);
        }
    }
}
