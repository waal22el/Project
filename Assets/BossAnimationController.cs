using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            return;
        }

        if (rb.linearVelocity.magnitude > 0.1f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("isDead");
        StartCoroutine(RemoveAfterDeath());
    }

    private System.Collections.IEnumerator RemoveAfterDeath()
    {
        yield return new WaitForSeconds(1.0f); //  efter Death-animationen
        Destroy(gameObject);
    }
}
