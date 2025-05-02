using UnityEngine;
using UnityEngine.UI;

public class MonsterDamage : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public Image healthBar;
    private Animator animator;  // To trigger death animation

    public GameObject deathEffect;  // Optional: Assign particle effect or dead prefab

    public GameObject[] itemDrops;

    private bool hasDied = false;
    void Start()
    {
        maxHealth = health;
        animator = GetComponent<Animator>();  // Get the Animator component
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
        // Play death animation by triggering it
        if (animator != null)
        {
            animator.SetTrigger("Die");  // Assuming you have a "Die" trigger in the Animator
        }

        // Optional: Instantiate a death effect (e.g., particle effect, explosion)
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Optionally, disable movement or other behavior
        var movementScript = GetComponent<Movement>();  // Assuming your monster has a Movement script
        if (movementScript != null)
        {
            movementScript.enabled = false;  // Disable movement when the monster dies
        }

        // Destroy the monster after a delay, allowing death animation/effects to play
        Destroy(gameObject, 1f);  // Adjust the delay to match your animation length
    }

    private void ItemDrop()
    {
        if (itemDrops.Length > 0)
        {
            int index = Random.Range(0, itemDrops.Length);  // Choose one at random
            Instantiate(itemDrops[index], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

}
