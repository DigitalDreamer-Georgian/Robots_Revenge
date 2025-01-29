using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, maxHealth = 2;
    public float speed;

    [SerializeField] HealthBar healthBar;
    [SerializeField] private GameObject ScrapPrefab;
    [SerializeField] private Transform ScrapSpawnPoint;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }
    private void Update()
    {
        if (health <= 0)
        {
            DropScrap();
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        damage = 1;
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
    }
    private void DropScrap()
    {
        if (ScrapPrefab != null)
        {
            Vector3 spawnPosition = ScrapSpawnPoint ? ScrapSpawnPoint.position : transform.position;
            Instantiate(ScrapPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
