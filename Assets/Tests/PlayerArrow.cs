using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    private float speed = 7f;
    private int damage = 25;
    private Vector2 dir = new Vector2(0, 0);
    private Vector2 movement = new Vector2(0, 0);
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = movement;
    }

    public void GoForth(float moveSpeed, int arrowDamage, Vector2 direction)
    {
        speed = moveSpeed;
        damage = arrowDamage;
        dir = direction;
        movement = direction * moveSpeed;

        if (movement.sqrMagnitude > 0.01f) // Rotate arrow
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        Invoke("DisableBullet", 7f);
    }

    void DisableBullet()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("Boss"))
        {
            col.GetComponent<MonsterDamage>()?.TakeDamage(damage);
            Debug.Log("Hit");
        }
        if(!col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
