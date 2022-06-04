using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShotMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime = 5f;

    public float Damage;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        StartCoroutine(DestroyAfterTooLong());
    }

    // Should use pooling instead but damn I don't have time for this
    IEnumerator DestroyAfterTooLong()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
