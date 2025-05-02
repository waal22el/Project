using UnityEngine;
using UnityEngine.UI;

public class MonsterDamage : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public Image healthBar;
    private Animator animator;  

    public GameObject deathEffect;  

    public GameObject[] itemDrops;

    private bool hasDied = false;
    void Start()
    {
        maxHealth = health;
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0 && hasDied == false)
        {
            Die();
            ItemDrop();
            hasDied = true;
        }
    }

    void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");  
        }

        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f); 
        }


        var movementScript = GetComponent<Movement>(); 
        if (movementScript != null)
        {
            movementScript.enabled = false;  
        }

        Destroy(gameObject, 1f); 

    }

    private void ItemDrop()
    {
        if (itemDrops.Length > 0)
        {
            int index = Random.Range(0, itemDrops.Length);
            GameObject item = Instantiate(itemDrops[index], transform.position, Quaternion.identity);

            if (item.TryGetComponent<Rigidbody2D>(out var rb2D))
            {
                rb2D.gravityScale = 0;
                rb2D.velocity = Vector2.zero;
                rb2D.angularVelocity = 0;
                rb2D.bodyType = RigidbodyType2D.Kinematic; 
            }

        }
    }
}
