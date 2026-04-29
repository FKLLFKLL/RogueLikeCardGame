using System.Collections.Generic;
using System.Linq;
using RogueLikeCardGame.Data;
using RogueLikeCardGame.Runtime;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.Story
{
    public readonly struct ReunionEvaluationResult
    {
        public ReunionTone Tone { get; }
        public CardPersonalityAffinity DominantAffinity { get; }
        public CardPersonalityAffinity RunnerUpAffinity { get; }

        public ReunionEvaluationResult(ReunionTone tone, CardPersonalityAffinity dominantAffinity, CardPersonalityAffinity runnerUpAffinity)
        {
            Tone = tone;
            DominantAffinity = dominantAffinity;
            RunnerUpAffinity = runnerUpAffinity;
        }
    }

    public class ReunionOutcomeEvaluator
    {
        // TODO: Plug this result into the reunion dialogue controller/UI when narrative implementation lands.
        public ReunionEvaluationResult EvaluateByCards(IEnumerable<string> finalCardIds, ResourceManager resourceManager)
        {
            Dictionary<CardPersonalityAffinity, int> scores = new()
            {
                [CardPersonalityAffinity.Nerve] = 0,
                [CardPersonalityAffinity.Heart] = 0,
                [CardPersonalityAffinity.Wits] = 0
            };

            foreach (string cardId in finalCardIds ?? Enumerable.Empty<string>())
            {
                CardData card = resourceManager.ResolveCard(cardId);
                if (card == null || card.personalityAffinity == CardPersonalityAffinity.None)
                {
                    continue;
                }

                if (!scores.ContainsKey(card.personalityAffinity))
                {
                    continue;
                }

                scores[card.personalityAffinity] += card.personalityWeight;
            }

            var ordered = scores.OrderByDescending(pair => pair.Value).ToArray();
            CardPersonalityAffinity dominant = ordered[0].Key;
            CardPersonalityAffinity runnerUp = ordered[1].Key;

            ReunionTone tone = dominant switch
            {
                CardPersonalityAffinity.Nerve => ReunionTone.NerveDominant,
                CardPersonalityAffinity.Heart => ReunionTone.HeartDominant,
                CardPersonalityAffinity.Wits => ReunionTone.WitsDominant,
                _ => ReunionTone.Balanced
            };

            return new ReunionEvaluationResult(tone, dominant, runnerUp);
        }
    }
}
