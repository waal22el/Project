using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 1f;
    public float shootingDistance = 5f;
    public float forgetDistance = 15f;
    public float chaseSpeed = 2f;

    protected float nextFire;
    protected Transform player;
    private BossPatrol patrolScript;
    private Rigidbody2D rb;
    private bool playerDetected = false;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        nextFire = Time.time;
        patrolScript = GetComponent<BossPatrol>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= shootingDistance)
        {
            playerDetected = true;

            if (patrolScript != null)
                patrolScript.enabled = false;

            ChasePlayer();         // Boss rör sig mot spelaren
            CheckIfTimeToFire();   // Boss skjuter samtidigt
        }
        else if (playerDetected && distance <= forgetDistance)
        {
            ChasePlayer();
            CheckIfTimeToFire();
        }
        else
        {
            // Spelaren har lämnat området, patrullera vidare
            playerDetected = false;

            if (patrolScript != null)
                patrolScript.enabled = true;
        }
    }

    protected void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * chaseSpeed;
    }

    protected void CheckIfTimeToFire()
    {
        if (Time.time >= nextFire)
        {
            Attack();
            nextFire = Time.time + fireRate;
        }
    }

    protected virtual void Attack()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = spawnedBullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
            bulletRb.linearVelocity = direction * 10f; // Bullet speed
    }
}

