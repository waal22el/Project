using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 1f;
    public float shootingDistance = 5f;    // När bossen börjar skjuta och jaga
    public float forgetDistance = 15f;     // När bossen glömmer och återgår till patrull
    public float chaseSpeed = 2f;

    protected float nextFire;
    protected Transform player;
    private BossPatrol patrolScript;
    private Rigidbody2D rb;
    private bool playerDetected = false;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        nextFire = Time.time + fireRate;
        patrolScript = GetComponent<BossPatrol>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= shootingDistance)
        {
            playerDetected = true;

            if (patrolScript != null)
                patrolScript.enabled = false;

            rb.linearVelocity = Vector2.zero; // Stanna och skjut
            CheckIfTimeToFire();
        }
        else if (playerDetected && distance <= forgetDistance)
        {
            // Jaga och skjut samtidigt
            ChasePlayer();
            CheckIfTimeToFire();
        }
        else
        {
            // Glöm spelaren, gå tillbaka till patrullering
            playerDetected = false;

            if (patrolScript != null)
                patrolScript.enabled = true;

            rb.linearVelocity = Vector2.zero;
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
            Debug.Log("current time = " + Time.time);
            Debug.Log("nextFire = " + nextFire);
            Debug.Log("Delta Time = " + (nextFire - Time.time));
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



