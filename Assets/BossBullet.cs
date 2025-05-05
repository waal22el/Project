using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 5f;           // Hur snabbt kulan rör sig
    public int damage = 1;             // Hur mycket skada kulan gör
    public float lifetime = 3f;        // Hur länge kulan finns innan den förstörs

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed; // Kulan flyger åt höger från sin rotation
        Destroy(gameObject, lifetime);         // Förstör kulan efter X sekunder
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Skadar spelaren om den har ett hälsoscript
            BossPlayerHealth playerHealth = collision.GetComponent<BossPlayerHealth>();
            if (playerHealth != null)
            {
               playerHealth.TakeDamage(damage);
                Debug.Log("Hit!"); // 👉 Lägger till "Hit!" i konsolen
            }
            Destroy(gameObject); // Kulan förstörs vid träff
        }
    }
}


