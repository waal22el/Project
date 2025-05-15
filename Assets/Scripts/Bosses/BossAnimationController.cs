using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    private Animator animator;

    // Dessa variabler styr animationerna – kan göras public för att testa i Inspector
    public bool isDead = false;
    public bool isRunning = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead)
        {
            animator.SetTrigger("Death");
        }
        else if (isRunning)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}


