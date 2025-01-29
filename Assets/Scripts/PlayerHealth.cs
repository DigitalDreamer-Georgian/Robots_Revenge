using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Transform respawn;
    [SerializeField] private HealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }

    private void Start()
    {
        health = maxHealth;
        healthBar?.UpdateHealthBar(health, maxHealth);
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
            Respawn();
        }

        healthBar?.UpdateHealthBar(health, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        healthBar?.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        health = maxHealth;
        healthBar?.UpdateHealthBar(health, maxHealth);
        if (respawn != null)
        {
            transform.position = respawn.position;
        }
    }
}
