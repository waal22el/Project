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

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    public float moveSpeed;

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
        if(isChasing)
        {
            if(transform.position.x > playerTransform.position.x)
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
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

