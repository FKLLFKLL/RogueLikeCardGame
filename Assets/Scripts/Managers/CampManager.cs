using UnityEngine;

namespace AshRoad.Managers
{
    public class CampManager : MonoBehaviour
    {
        public void Heal() { /* extension point: heal player HP runtime */ }
        public void RemoveCard() { /* extension point: deck edit flow */ }
        public void ReflectMemory(string sceneId) => GameManager.Instance.StoryProgressManager.UnlockScene(sceneId);
    }
}
