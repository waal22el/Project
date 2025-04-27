using UnityEngine;

public class movement : MonoBehaviour
{
    float xInput;
    float yInput;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(xInput, yInput));
    }
}

