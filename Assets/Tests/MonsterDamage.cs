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

    public GameObject keyPrefab;
    [Range(0f, 1f)]
    public float keyDropChance = 0.2f; 

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
        if (hasDied) return;

        health -= damageAmount;

        if (health <= 0)
        {
            Die();
            DropSingleItem(); 
            hasDied = true;
        }
    }

    void Die()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
        }

        var movementScript = GetComponent<Movement>();
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null) collider.enabled = false;

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }

        Destroy(gameObject, 0.5f);
    }

    float GetDeathAnimationLength()
    {
        if (animator == null) return 1f;

        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name.ToLower().Contains("die"))
            {
                return clip.length;
            }
        }
        return 1f;
    }

    private void DropSingleItem()
    {
        if (Random.value <= keyDropChance && keyPrefab != null)
        {
            GameObject key = Instantiate(keyPrefab, transform.position, Quaternion.identity);
            AddDropForce(key);
            return; 
        }

        if (itemDrops.Length > 0)
        {
            int index = Random.Range(0, itemDrops.Length);
            GameObject droppedItem = Instantiate(itemDrops[index], transform.position, Quaternion.identity);
            AddDropForce(droppedItem);
        }
    }

    private void AddDropForce(GameObject item)
    {
        Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            rb.freezeRotation = true;
        }
    }
}
