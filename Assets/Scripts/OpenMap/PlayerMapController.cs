using UnityEngine;

namespace RogueLikeCardGame.OpenMap
{
    public class PlayerMapController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private KeyCode interactKey = KeyCode.E;
        [SerializeField] private float interactRadius = 1.2f;

        private void Update()
        {
            Vector2 input = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            transform.position += (Vector3)(input.normalized * (moveSpeed * Time.deltaTime));

            if (Input.GetKeyDown(interactKey))
            {
                TryInteractNearbyBuilding();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var building = other.GetComponent<BuildingInteractable>();
            if (building != null)
            {
                building.Interact();
                return;
            }

            var enemy = other.GetComponent<MapEnemyWalker>();
            if (enemy != null)
            {
                enemy.TriggerCombat();
            }
        }

        private void TryInteractNearbyBuilding()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRadius);
            foreach (Collider2D hit in hits)
            {
                BuildingInteractable building = hit.GetComponent<BuildingInteractable>();
                if (building == null) continue;
                building.Interact();
                break;
            }
        }
    }
}
