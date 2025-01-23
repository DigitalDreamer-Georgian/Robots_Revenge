using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    [SerializeField] private HealthBar healthBar; // Reference to the health bar

    private void Awake()
    {
        // Get the HealthBar component attached to a child of the player
        healthBar = GetComponentInChildren<HealthBar>();
    }

    private void Start()
    {
        health = maxHealth;
        healthBar?.UpdateHealthBar(health, maxHealth); // Initialize health bar
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
            Debug.Log("Player Respawn");
        }

        healthBar?.UpdateHealthBar(health, maxHealth); // Update health bar
    }

    // Method to handle damage, similar to the Enemy script
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        healthBar?.UpdateHealthBar(health, maxHealth); // Update health bar after damage

        if (health <= 0)
        {
            Debug.Log("Player Respawn"); // Placeholder for respawn or death logic
        }
    }
}
