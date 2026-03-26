using UnityEngine;
using UnityEngine.SceneManagement;

namespace AshRoad.Managers
{
    public class SceneFlowController : MonoBehaviour
    {
        public void LoadMainMenu() => SceneManager.LoadScene("MainMenu");
        public void LoadMap() => SceneManager.LoadScene("MapScene");
        public void LoadEvent() => SceneManager.LoadScene("EventScene");
        public void LoadCombat() => SceneManager.LoadScene("CombatScene");
        public void LoadCamp() => SceneManager.LoadScene("CampScene");
        public void LoadMetaHub() => SceneManager.LoadScene("MetaHubScene");
    }
}
