using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;

    public float CurrentHealth { get => currentHealth; private set => currentHealth = value; }

    public void Reset()
    {
        currentHealth = maxHealth;
    }

    public bool IsAlive => currentHealth > 0f;

    protected void TakeDamage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0f, maxHealth);
    }
}
