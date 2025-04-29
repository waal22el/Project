using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float moveSpeed = 7f;
    public int damage = 2;
    private Rigidbody2D rb;
    private Vector2 direction;
    private GameObject shooter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        direction = player != null ?
                   (player.transform.position - transform.position).normalized :
                   Vector2.right;

        Destroy(gameObject, 7f);
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = direction * moveSpeed; // fixed: use velocity, not linearVelocity
        }
    }

    public void SetShooter(GameObject shooterObj)
    {
        shooter = shooterObj;

        Collider2D bulletCollider = GetComponent<Collider2D>();
        Collider2D[] shooterColliders = shooterObj.GetComponentsInChildren<Collider2D>();

        if (bulletCollider != null)
        {
            foreach (var shooterCollider in shooterColliders)
            {
                if (shooterCollider != null)
                    Physics2D.IgnoreCollision(bulletCollider, shooterCollider);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}





