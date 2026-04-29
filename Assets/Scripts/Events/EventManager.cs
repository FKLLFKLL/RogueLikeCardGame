using UnityEngine;
using RogueLikeCardGame.Data;
using RogueLikeCardGame.Runtime;
using RogueLikeCardGame.Story;

namespace RogueLikeCardGame.Events
{
    public class EventManager : MonoBehaviour
    {
        [SerializeField] private ResourceManager resourceManager;
        [SerializeField] private StoryProgressManager storyProgressManager;

        public EnemyStateOverrideResult ResolveChoice(EventChoiceData choice)
        {
            if (choice?.reward?.grants == null)
            {
                return EnemyStateOverrideResult.None;
            }

            foreach (RewardGrant grant in choice.reward.grants)
            {
                if (!string.IsNullOrWhiteSpace(grant.cardId))
                {
                    CardData card = resourceManager.ResolveCard(grant.cardId);
                    if (card != null)
                    {
                        storyProgressManager.RecordCollectedCard(card.cardId);
                        Debug.Log($"[Event] Granted card {card.displayName} ({card.personalityAffinity}).");
                    }
                }

                if (!string.IsNullOrWhiteSpace(grant.clueId))
                {
                    storyProgressManager.AddClue(grant.clueId);
                }
            }

            if (!choice.overrideNextEncounterState)
            {
                return EnemyStateOverrideResult.None;
            }

            return new EnemyStateOverrideResult(choice.nextEncounterState);
        }
    }

    public readonly struct EnemyStateOverrideResult
    {
        public static EnemyStateOverrideResult None => new(false, default);

        public bool HasOverride { get; }
        public Shared.EnemyCombatState State { get; }

        public EnemyStateOverrideResult(Shared.EnemyCombatState state) : this(true, state)
        {
        }

        private EnemyStateOverrideResult(bool hasOverride, Shared.EnemyCombatState state)
        {
            HasOverride = hasOverride;
            State = state;
        }
    }
}
