using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Low coupling supports few dependencies which makes it easy to test and make changes.
// This code has low dependency which is why it uses the low coupling pattern.
// High cohesion means that the code sticks toghether and does one thing well.
// This code has the same purpose and therefore it has high cohesion. 
public class Movement : MonoBehaviour
{
    public float directionChange = 3f;
    public float maxSpeed = 3f;
    private Vector2 movement;
    private float timeLeft;

    private Rigidbody2D rb;

    public bool isChasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PickNewDirection();
        timeLeft = directionChange;
    }

    void Update()
    {
        if (!isChasing)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                PickNewDirection();
                timeLeft = directionChange;
            }
        }
    }

    void FixedUpdate()
    {
        if (!isChasing)
        {
            rb.linearVelocity = movement * maxSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void PickNewDirection()
    {
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}

