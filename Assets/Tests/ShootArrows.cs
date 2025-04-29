using UnityEngine;

public class ShootArrows : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float shootingRange = 5f;
    public float bulletSpeed = 7f;
    public int bulletDamage = 2;

    private float fireTimer;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        fireTimer += Time.deltaTime;

        if (Vector2.Distance(transform.position, player.position) <= shootingRange &&
            fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        Vector2 spawnPos = transform.position + (player.position - transform.position).normalized * 0.5f;
        var bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        var bulletScript = bullet.GetComponent<Bullets>();
        bulletScript.moveSpeed = bulletSpeed;
        bulletScript.damage = bulletDamage;
        bulletScript.SetShooter(gameObject);
    }

}

