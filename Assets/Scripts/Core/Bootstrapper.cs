using UnityEngine;

namespace AshRoad.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        // Attach in Boot scene to initialize persistent systems.
        private void Start()
        {
            if (Managers.GameManager.Instance != null)
            {
                Managers.GameManager.Instance.StoryProgressManager.LoadPersistent();
            }
        }
    }
}
