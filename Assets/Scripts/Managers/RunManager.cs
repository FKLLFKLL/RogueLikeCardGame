using System.Collections.Generic;
using UnityEngine;
using AshRoad.Models;
using AshRoad.Data;

namespace AshRoad.Managers
{
    public class RunManager : MonoBehaviour
    {
        public RunResources Resources = new();
        public PersonalityState Personality = new();
        public List<CardData> RunDeck = new();
        public bool FailedSoftly { get; private set; }

        public void StartRun(List<CardData> startingDeck)
        {
            FailedSoftly = false;
            Resources = new RunResources();
            Personality = new PersonalityState();
            RunDeck = new List<CardData>(startingDeck);
        }

        public void SoftFailRun()
        {
            FailedSoftly = true;
        }
    }
}
