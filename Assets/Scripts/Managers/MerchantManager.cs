using UnityEngine;

namespace AshRoad.Managers
{
    public class MerchantManager : MonoBehaviour
    {
        public int rerollCost = 2;
        public bool TryReroll()
        {
            return GameManager.Instance.RunManager.Resources.Spend(Shared.ResourceType.Scrap, rerollCost);
        }
    }
}
