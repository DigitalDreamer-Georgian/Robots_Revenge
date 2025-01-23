using UnityEngine;

public class beebullet : MonoBehaviour
{
    public int dmg = 1;
    public LayerMask whatIsPlayer;  // Layer mask for the player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet collides with the player
        if (((1 << collision.gameObject.layer) & whatIsPlayer) != 0)
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(dmg);  // Apply damage to the player
            }

            Destroy(gameObject);  // Destroy the bullet
        }
    }
}

