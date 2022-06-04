using UnityEngine;

public class DustEnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Vector2 speed;

    private float distanceTravelled => startY - transform.position.y;
    private float startY = 0;

    private void Awake()
    {
        startY = transform.position.y;
    }

    private void Update()
    {
        rigidbody2D.velocity = new Vector2(Mathf.Sin(distanceTravelled * 3f), -1) * speed;
    }
}
