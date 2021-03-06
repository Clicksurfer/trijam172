using System;

public class ShelfHealth : Health
{
    public event Action OnShelfHit;

    private void Start()
    {
        GameManager.Instance.OnRoundOver += Reset;
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().Kill();
            TakeDamage(1);
            OnShelfHit?.Invoke();   
        }
    }
}
