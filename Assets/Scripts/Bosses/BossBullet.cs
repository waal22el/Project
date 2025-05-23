﻿using Unity.Mathematics;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject fireObject;

    private float lifetime;
    private GameObject player;

    private Rigidbody2D rb;
    private float time = 0f;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();


        // Hitta spelaren och skjut mot hens position
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {

            float disctance = Vector2.Distance(transform.position, player.transform.position);
            lifetime = disctance / speed;
        

            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;


        }

    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time != 0 && time % 1 == 0)
        {
            rb.linearVelocity *= 0.5f;
        }

        if (time >= lifetime)
            {
                Instantiate(fireObject, new Vector3(rb.position.x, rb.position.y, 0), quaternion.identity);
                Destroy(gameObject);
            }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            DealDamage(damage, playerHealth);
            Instantiate(fireObject, new Vector3(player.transform.position.x, player.transform.position.y,player.transform.position.z), quaternion.identity);
            Destroy(gameObject);

        }
    }

    void DealDamage(int dmg, PlayerHealth playerH) 
    {
        if (playerH != null)
        {
            playerH.TakeDamage(dmg);
        }
    }
}


