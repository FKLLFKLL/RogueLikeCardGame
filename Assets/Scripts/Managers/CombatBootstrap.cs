using UnityEngine;
using AshRoad.Data;
using AshRoad.Combat;

namespace AshRoad.Managers
{
    public class CombatBootstrap : MonoBehaviour
    {
        public EncounterData sampleEncounter;
        public CombatManager combatManager;
        public void Start()
        {
            combatManager.StartEncounter(sampleEncounter, GameManager.Instance.RunManager.RunDeck);
        }
    }
}
