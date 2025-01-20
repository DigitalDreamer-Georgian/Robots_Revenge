using UnityEngine;

public enum WeaponType
{
    GUN,
    SWORD,
    COUNT
}

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    float bulletSpeed = 10.0f;
    float moveSpeed = 5.0f;

    [SerializeField]
    WeaponType weaponType = WeaponType.GUN;

    [SerializeField]
    Transform attackPos;

    [SerializeField]
    LayerMask whatIsEnemies;
    float attackRange = 1.0f;
    int damage = 1;
    float startTimeBtwAttack = 0.5f;
    float timeBtwAttack;

    void Update()
    {
        // Aiming
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        mouse.z = 0.0f;
        Vector3 mouseDirection = (mouse - transform.position).normalized;
        Debug.DrawLine(transform.position, transform.position + mouseDirection * 5.0f);

        if (weaponType == WeaponType.SWORD && attackPos != null)
        {
            attackPos.localPosition = mouseDirection * attackRange;
        }

        // Attacking
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            switch (weaponType)
            {
                case WeaponType.GUN:
                    ShootGun(mouseDirection);
                    break;

                case WeaponType.SWORD:
                    SwordAttack();
                    break;
            }
        }

        if (weaponType == WeaponType.SWORD && timeBtwAttack > 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }

        // Cycle Weapon
        if (Input.GetKeyDown(KeyCode.R))
        {
            int weaponNumber = (int)++weaponType;
            weaponNumber %= (int)WeaponType.COUNT;
            weaponType = (WeaponType)weaponNumber;
            Debug.Log("Selected weapon: " + weaponType);
        }
    }

    void ShootGun(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position + direction * 0.75f;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        bullet.GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(bullet, 1.0f);
    }

    void SwordAttack()
    {
        if (timeBtwAttack <= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            foreach (var enemy in enemiesToDamage)
            {
                enemy.GetComponent<Enemy>()?.TakeDamage(damage);
            }

            timeBtwAttack = startTimeBtwAttack;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (weaponType == WeaponType.SWORD && attackPos != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
    }
}
