using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform shotOrigin;
    [SerializeField] private GameObject shotPrefab;
    [SerializeField] private float cooldown = 0.5f;

    private float timer = 0f;

    private void Update()
    {
        // Check for shooting button presses
        if (Input.GetKey(KeyCode.Space))
            if (timer == 0f)
                Shoot();

        timer = Mathf.Clamp(timer - Time.deltaTime, 0f, cooldown);
    }

    private void Shoot()
    {
        timer = cooldown;
        Instantiate(shotPrefab, shotOrigin.position, Quaternion.Euler(0,0,0));
    }
}
