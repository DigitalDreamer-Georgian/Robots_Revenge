using UnityEngine;

public enum WeaponType
{
    SWORD,
    GUN,
    SHOTGUN,
    COUNT
}

public class Player : MonoBehaviour
{
    public Animator ani;
    public GameObject GunSprite;
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
        // Calculate the angle in degrees
        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
        GunSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        GunSprite.transform.position = transform.position + mouseDirection * 0.7f;
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
                case WeaponType.SHOTGUN:
                    ShootShotgun(mouseDirection);
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
            switch (weaponType)
            {
                case WeaponType.GUN:
                    ani.SetBool("floatingGun", true);
                    GunSprite.SetActive(true);
                    break;

                case WeaponType.SWORD:
                    ani.SetBool("floatingGun", false);
                    GunSprite.SetActive(false);
                    break;

                case WeaponType.SHOTGUN:
                    ani.SetBool("floatingGun", true);
                    GunSprite.SetActive(true);
                    break;
            }
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
    void ShootShotgun(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab);
        GameObject bulletLeft = Instantiate(bulletPrefab);
        GameObject bulletRight = Instantiate(bulletPrefab);

        Vector3 directionLeft = Quaternion.Euler(0.0f, 0.0f, 10.0f) * direction;
        Vector3 directionRight = Quaternion.Euler(0.0f, 0.0f, -10.0f) * direction;

        bullet.transform.position = transform.position + direction * 0.75f;
        bulletLeft.transform.position = transform.position + directionLeft * 0.75f;
        bulletRight.transform.position = transform.position + directionRight * 0.75f;

        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        bulletLeft.GetComponent<Rigidbody2D>().velocity = directionLeft * bulletSpeed;
        bulletRight.GetComponent<Rigidbody2D>().velocity = directionRight * bulletSpeed;

        bullet.GetComponent<SpriteRenderer>().color = Color.white;
        bulletLeft.GetComponent<SpriteRenderer>().color = Color.white;
        bulletRight.GetComponent<SpriteRenderer>().color = Color.white;

        Destroy(bullet, 1.0f);
        Destroy(bulletLeft, 1.0f);
        Destroy(bulletRight, 1.0f);
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
