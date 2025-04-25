using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float moveSpeed = 7f;
    public int damage = 1;  // Public damage variable you can adjust
    private Rigidbody2D rb;
    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            target = playerObj.transform;
            Vector2 moveDirection = (target.position - transform.position).normalized;
            rb.linearVelocity = moveDirection * moveSpeed;
        }
        else
        {
            Debug.LogWarning("Player not found!");
        }

        Destroy(gameObject, 7f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerHealth playerHealth = col.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);  // Apply dynamic damage
            }

            Destroy(gameObject);
        }
    }

}





