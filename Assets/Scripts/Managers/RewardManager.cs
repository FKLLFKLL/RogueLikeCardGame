using UnityEngine;
using AshRoad.Data;

namespace AshRoad.Managers
{
    public class RewardManager : MonoBehaviour
    {
        public void Grant(RewardData reward)
        {
            foreach (var grant in reward.grants)
            {
                GameManager.Instance.RunManager.Resources.Add(grant.resource, grant.amount);
                if (!string.IsNullOrEmpty(grant.clueId)) GameManager.Instance.StoryProgressManager.Data.clues.Add(grant.clueId);
            }
        }
    }
}
