using UnityEngine;

namespace RogueLikeCardGame.OpenMap
{
    public class PlayerMapController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 4f;

        private void Update()
        {
            Vector2 input = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            transform.position += (Vector3)(input.normalized * (moveSpeed * Time.deltaTime));
        }
    }
}
