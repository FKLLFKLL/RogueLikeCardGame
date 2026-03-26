using UnityEngine;
using AshRoad.Shared;

namespace AshRoad.Managers
{
    public class ResourceManager : MonoBehaviour
    {
        public bool Spend(ResourceType type, int amount) => GameManager.Instance.RunManager.Resources.Spend(type, amount);
        public void Gain(ResourceType type, int amount) => GameManager.Instance.RunManager.Resources.Add(type, amount);
    }
}
