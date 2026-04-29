using System;
using UnityEngine;

namespace RogueLikeCardGame.Events
{
    [Serializable]
    public class RewardGrant
    {
        public string cardId;
        public int currency;
        public string clueId;
    }

    [CreateAssetMenu(menuName = "RogueLike/Reward Data", fileName = "RewardData")]
    public class RewardData : ScriptableObject
    {
        public RewardGrant[] grants;
    }
}
