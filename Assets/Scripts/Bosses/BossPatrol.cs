using UnityEngine;

public class BossPatrol : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    private Vector2 currentDirection;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentDirection = GetRandomDirection();
    }

    void Update()
    {
        rb.linearVelocity = currentDirection * moveSpeed;
        FlipSprite();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentDirection = GetRandomDirection();
    }

    private Vector2 GetRandomDirection()
    {
        Vector2 newDirection;
        int attempts = 0;

        do
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            newDirection = new Vector2(x, y).normalized;
            attempts++;
        }
        // Förhindra att den står still eller väljer nästan samma riktning igen
        while ((newDirection.magnitude < 0.1f || Vector2.Dot(newDirection, currentDirection) > 0.8f) && attempts < 10);

        return newDirection;
    }

    private void FlipSprite()
    {
        if (currentDirection.x != 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = currentDirection.x > 0 ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }
    }
}
