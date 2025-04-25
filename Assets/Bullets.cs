using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using System.Data.Common;

public class Bullets : MonoBehaviour
{
    float moveSpeed = 7f;
    Rigidbody2D rb;
    PlayerMovement target;
    Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 7f);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
