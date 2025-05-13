using Unity.Mathematics;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private GameObject fireObject;

    private GameObject player;

    private Rigidbody2D rb;
    private float time = 0f;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();


        // Hitta spelaren och skjut mot hens position
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }

    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time >= lifetime)
        {
            Instantiate(fireObject, new Vector3(rb.position.x, rb.position.y,0), quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            BossPlayerHealth playerHealth = collision.GetComponent<BossPlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Hit!");
            }
            Instantiate(fireObject, new Vector3(player.transform.position.x, player.transform.position.y,player.transform.position.z), quaternion.identity);
            Destroy(gameObject);

        }
    }
}


