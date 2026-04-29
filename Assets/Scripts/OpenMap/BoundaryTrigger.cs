using System;
using UnityEngine;

namespace RogueLikeCardGame.OpenMap
{
    public class BoundaryTrigger : MonoBehaviour
    {
        public event Action OnBoundaryReached;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerMapController>() == null) return;
            OnBoundaryReached?.Invoke();
        }
    }
}
