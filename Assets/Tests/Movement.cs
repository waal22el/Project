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
    private Animator animator;

    public bool isChasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  // ✅ Get the Animator component

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

        // ✅ Update animator with current speed
        animator.SetFloat("Speed", movement.magnitude);
        // Flip the sprite based on movement direction
        if (movement.x != 0)
        {
            GetComponent<SpriteRenderer>().flipX = movement.x < 0;
        }

    }

    void FixedUpdate()
    {
        if (!isChasing)
        {
            rb.velocity = movement * maxSpeed;  // ✅ Corrected from linearVelocity
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void PickNewDirection()
    {
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}


