using System;

public class ShelfHealth : Health
{
    public event Action OnShelfHit;

    private void Start()
    {
        GameManager.Instance.RoundOver += Reset;
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
            OnShelfHit?.Invoke();   
        }
    }
}
