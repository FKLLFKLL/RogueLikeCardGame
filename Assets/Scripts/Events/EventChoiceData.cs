using System;
using UnityEngine;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.Events
{
    [Serializable]
    public class EventChoiceData
    {
        public string choiceId;
        [TextArea] public string description;
        public RewardData reward;
        public bool overrideNextEncounterState;
        public EnemyCombatState nextEncounterState = EnemyCombatState.Neutral;
    }
}
