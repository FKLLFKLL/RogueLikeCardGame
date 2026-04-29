using UnityEngine;
using RogueLikeCardGame.Data;
using RogueLikeCardGame.Runtime;

namespace RogueLikeCardGame.OpenMap
{
    public abstract class BuildingInteractable : MonoBehaviour
    {
        [SerializeField] private bool consumeAfterUse = true;
        public abstract void Interact();

        protected void CompleteInteraction(string message)
        {
            Debug.Log(message);
            // TODO(UI): Replace with proper interaction popup + reward panel.
            if (consumeAfterUse) gameObject.SetActive(false);
        }
    }

    public class EventBuilding : BuildingInteractable
    {
        [SerializeField] private CardData[] rewardPool;

        public override void Interact()
        {
            if (RunState.Instance == null || rewardPool == null || rewardPool.Length == 0)
            {
                CompleteInteraction("[OpenMap] Event building had no card rewards configured.");
                return;
            }

            CardData reward = rewardPool[Random.Range(0, rewardPool.Length)];
            RunState.Instance.AddCard(reward);
            CompleteInteraction($"[OpenMap] Event reward: gained card {reward.displayName}.");
        }
    }

    public class MerchantBuilding : BuildingInteractable
    {
        [SerializeField] private CardData merchantPick;

        public override void Interact()
        {
            if (RunState.Instance != null && merchantPick != null)
            {
                RunState.Instance.AddCard(merchantPick);
            }
            CompleteInteraction($"[OpenMap] Merchant placeholder: granted {(merchantPick != null ? merchantPick.displayName : "a future shop token")}.");
            // TODO(Design): Replace with real shop choices and pricing.
        }
    }

    public class CampBuilding : BuildingInteractable
    {
        [SerializeField] private int healAmount = 10;
        public override void Interact()
        {
            RunState.Instance?.ModifyHp(healAmount);
            CompleteInteraction($"[OpenMap] Camp rest: restored {healAmount} HP.");
        }
    }

    public class FoodScavengeBuilding : BuildingInteractable
    {
        [SerializeField] private int foodAmount = 1;
        public override void Interact()
        {
            RunState.Instance?.GainFood(foodAmount);
            CompleteInteraction($"[OpenMap] Scavenge success: +{foodAmount} food.");
        }
    }

    public class StoryClueBuilding : BuildingInteractable
    {
        public override void Interact()
        {
            RunState.Instance?.GainClue(1);
            CompleteInteraction("[OpenMap] Story site explored: gained 1 clue.");
            // TODO(Story): Attach authored clue text and progression unlock checks.
        }
    }
}
