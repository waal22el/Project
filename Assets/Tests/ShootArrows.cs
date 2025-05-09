using UnityEngine;
using System.Collections.Generic;

public class ShootArrows : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float shootingRange = 5f;
    public float bulletSpeed = 7f;
    public int bulletDamage = 2;
    public int poolSize = 10;

    private Transform player;
    private float nextShotTime;
    private Queue<GameObject> bulletPool;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        InitializePool();
        nextShotTime = Time.time;
    }

    void Update()
    {
        if (player == null) return;

        if (Vector3.Distance(transform.position, player.position) <= shootingRange)
        {
            if (Time.time >= nextShotTime)
            {
                Shoot();
                nextShotTime = Time.time + fireRate;
            }
        }
    }

    void InitializePool()
    {
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    void Shoot()
    {
        if (bulletPool.Count == 0) return;

        GameObject bullet = bulletPool.Dequeue();
        bullet.transform.position = transform.position +
                                  (player.position - transform.position).normalized * 0.5f;
        bullet.SetActive(true);

        Bullets bulletScript = bullet.GetComponent<Bullets>();
        bulletScript.moveSpeed = bulletSpeed;
        bulletScript.damage = bulletDamage;
        bulletScript.SetShooter(gameObject);
        bulletScript.OnDestroyed += () => bulletPool.Enqueue(bullet);
    }
}

