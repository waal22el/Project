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
        animator = GetComponent<Animator>();  

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

        animator.SetFloat("Speed", movement.magnitude);
        if (movement.x != 0)
        {
            GetComponent<SpriteRenderer>().flipX = movement.x < 0;
        }

    }

    void FixedUpdate()
    {
        if (!isChasing)
        {
            rb.velocity = movement * maxSpeed;  
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


