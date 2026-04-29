using System.Collections.Generic;
using UnityEngine;
using RogueLikeCardGame.Story;

namespace RogueLikeCardGame.OpenMap
{
    public class FinalBossEncounter : MonoBehaviour
    {
        [SerializeField] private List<string> playerRunDeckCardIds = new();

        public void BeginEncounter()
        {
            Debug.Log("[FinalBoss] Boundary reached. Starting final encounter with missing best friend.");
            // TODO: Replace placeholder with full friend reveal cinematic + combat setup.
        }

        public ReunionEvaluationResult ResolveEndingByDeck(ResourceManager resourceManager)
        {
            return new ReunionOutcomeEvaluator().EvaluateByCards(playerRunDeckCardIds, resourceManager);
        }
    }
}
