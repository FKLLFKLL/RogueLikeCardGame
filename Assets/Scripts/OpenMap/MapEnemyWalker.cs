using UnityEngine;

namespace RogueLikeCardGame.OpenMap
{
    public class MapEnemyWalker : MonoBehaviour
    {
        [SerializeField] private float speed = 1.2f;
        [SerializeField] private float roamRadius = 4f;

        private Vector3 origin;
        private Vector3 target;

        private void Start()
        {
            origin = transform.position;
            PickNewTarget();
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target) < 0.1f) PickNewTarget();
        }

        private void PickNewTarget()
        {
            Vector2 offset = Random.insideUnitCircle * roamRadius;
            target = origin + new Vector3(offset.x, offset.y, 0f);
        }
    }
}
