using UnityEngine;
using AshRoad.Shared;

namespace AshRoad.Managers
{
    public class PersonalityManager : MonoBehaviour
    {
        public int Get(PersonalityType type) => GameManager.Instance.RunManager.Personality.Get(type);
        public void Shift(PersonalityType type, int amount) => GameManager.Instance.RunManager.Personality.Add(type, amount);
    }
}
