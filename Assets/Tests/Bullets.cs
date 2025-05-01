using UnityEngine;
using System;

public class Bullets : MonoBehaviour
{
    public float moveSpeed = 7f;
    public int damage = 2;
    public Action OnDestroyed;

    private Rigidbody2D rb;
    private GameObject shooter;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void OnEnable()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = player != null ?
                          (player.transform.position - transform.position).normalized :
                          Vector2.right;
        rb.velocity = direction * moveSpeed;
        Invoke("DisableBullet", 7f);
    }

    void DisableBullet()
    {
        OnDestroyed?.Invoke();
        gameObject.SetActive(false);
    }

    public void SetShooter(GameObject shooterObj)
    {
        shooter = shooterObj;
        if (TryGetComponent<Collider2D>(out var bulletCollider))
            Physics2D.IgnoreCollision(bulletCollider, shooter.GetComponent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            col.GetComponent<PlayerHealth>()?.TakeDamage(damage);

        if (!col.isTrigger)
            DisableBullet();
    }
}





