using UnityEngine;

    public class EnemyHealth : Health
    {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Shot")
        {
            Destroy(collision.gameObject);
            TakeDamage(collision.gameObject.GetComponent<ShotMovement>().Damage);
            if (IsAlive == false)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        GameManager.Instance.OnEnemyDestroyed?.Invoke();
        Destroy(gameObject);
    }
}