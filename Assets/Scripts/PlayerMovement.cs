using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 300f;
    [SerializeField] private Rigidbody2D rigidbody;

    private void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(xMov, rigidbody.velocity.y).normalized * speed;
    }
}
