using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float directionChange = 3f;
    public float maxSpeed = 3f;
    private Vector2 movement;
    private float timeLeft;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PickNewDirection();
        timeLeft = directionChange;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            PickNewDirection();
            timeLeft = directionChange;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * maxSpeed;
    }

    void PickNewDirection()
    {
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}

