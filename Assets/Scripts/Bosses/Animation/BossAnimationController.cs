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

        if (rb.velocity.magnitude > 0.1f)
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
        StartCoroutine(DeathSequence());
    }

    private System.Collections.IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(1.0f); // Vänta på dödsanimationen 

        Destroy(gameObject); // Ta bort bossen

        yield return new WaitForSeconds(0.5f); // paus innan menyn visas

        PostBossMenuUI menuUI = FindObjectOfType<PostBossMenuUI>();
        if (menuUI != null)
        {
            menuUI.ShowMenu(); // Visa menyn efter bossen försvunnit
        }
        else
        {
            Debug.LogError("PostBossMenuUI not found in scene!");
        }
    }
}
