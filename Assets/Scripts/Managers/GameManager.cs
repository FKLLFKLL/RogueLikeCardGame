using UnityEngine;

namespace AshRoad.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public RunManager RunManager;
        public SaveManager SaveManager;
        public StoryProgressManager StoryProgressManager;

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
