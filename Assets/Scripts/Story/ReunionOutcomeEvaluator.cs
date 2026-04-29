using System.Collections.Generic;
using System.Linq;
using RogueLikeCardGame.Data;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.Story
{
    public readonly struct ReunionEvaluationResult
    {
        public ReunionTone Tone { get; }
        public CardPersonalityAffinity DominantAffinity { get; }
        public CardPersonalityAffinity RunnerUpAffinity { get; }
        public bool IsTie { get; }

        public ReunionEvaluationResult(ReunionTone tone, CardPersonalityAffinity dominantAffinity, CardPersonalityAffinity runnerUpAffinity, bool isTie)
        {
            Tone = tone;
            DominantAffinity = dominantAffinity;
            RunnerUpAffinity = runnerUpAffinity;
            IsTie = isTie;
        }
    }

    public class ReunionOutcomeEvaluator
    {
        public ReunionEvaluationResult EvaluateByCards(IEnumerable<CardData> finalCards, Runtime.ResourceManager _)
        {
            Dictionary<CardPersonalityAffinity, int> scores = new()
            {
                [CardPersonalityAffinity.Nerve] = 0,
                [CardPersonalityAffinity.Heart] = 0,
                [CardPersonalityAffinity.Wits] = 0
            };

            foreach (CardData card in finalCards ?? Enumerable.Empty<CardData>())
            {
                if (card == null || card.personalityAffinity == CardPersonalityAffinity.None) continue;
                scores[card.personalityAffinity] += card.personalityWeight;
            }

            var ordered = scores.OrderByDescending(pair => pair.Value).ToArray();
            bool tie = ordered[0].Value == ordered[1].Value;
            CardPersonalityAffinity dominant = ordered[0].Key;
            CardPersonalityAffinity runnerUp = ordered[1].Key;

            ReunionTone tone = tie ? ReunionTone.Balanced : dominant switch
            {
                CardPersonalityAffinity.Nerve => ReunionTone.NerveDominant,
                CardPersonalityAffinity.Heart => ReunionTone.HeartDominant,
                CardPersonalityAffinity.Wits => ReunionTone.WitsDominant,
                _ => ReunionTone.Balanced
            };

            return new ReunionEvaluationResult(tone, dominant, runnerUp, tie);
        }
    }
}
