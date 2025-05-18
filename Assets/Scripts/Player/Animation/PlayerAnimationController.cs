using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerHealth playerHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth.health <= 0)
        {
            animator.SetBool("isDead", true); // Startar d�dsanimationen via bool
            return;
        }

        // R�relseanimation (Running/Idle)
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
        playerHealth.health -= damage;
        if (playerHealth.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("isDead"); // Triggar d�dsanimationen via Trigger
        StartCoroutine(RemoveAfterDeath());
    }

    private System.Collections.IEnumerator RemoveAfterDeath()
    {
        yield return new WaitForSeconds(1.0f); // V�ntar p� att d�dsanimationen ska spelas klart
        Destroy(gameObject); // Tar bort spelaren fr�n scenen
    }
}


