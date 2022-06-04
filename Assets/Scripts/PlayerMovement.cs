using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 300f;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    private void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(xMov, rigidbody.velocity.y).normalized * speed;
        animator.SetBool("Moving", Mathf.Abs(xMov) >= 0.05f);
        animator.GetComponent<SpriteRenderer>().flipX = xMov > 0f;
    }
}
