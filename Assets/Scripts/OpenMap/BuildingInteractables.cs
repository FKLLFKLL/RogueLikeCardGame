using UnityEngine;

namespace RogueLikeCardGame.OpenMap
{
    public abstract class BuildingInteractable : MonoBehaviour
    {
        public abstract void Interact();
    }

    public class EventBuilding : BuildingInteractable
    {
        public override void Interact() => Debug.Log("[OpenMap] Event building triggered.");
    }

    public class MerchantBuilding : BuildingInteractable
    {
        public override void Interact() => Debug.Log("[OpenMap] Merchant opened.");
    }

    public class CampBuilding : BuildingInteractable
    {
        public override void Interact() => Debug.Log("[OpenMap] Camp rest triggered.");
    }

    public class StoryClueBuilding : BuildingInteractable
    {
        public override void Interact() => Debug.Log("[OpenMap] Story/clue interaction triggered.");
    }
}
