using UnityEngine;

public class BossPatrol : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    private int direction = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Anv�nd linearVelocity enligt nya Unity-standarden
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // V�nd riktning vid krock (t.ex. med v�gg)
        direction *= -1;
    }
}
