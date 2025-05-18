using UnityEngine;

public class PlayerAttackTest : MonoBehaviour
{
    public BossAnimationController boss; // Dra in bossen här i Inspector
    public int damageAmount = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (boss != null)
            {
                boss.TakeDamage(damageAmount);
                Debug.Log("Boss took " + damageAmount + " damage!");
            }
        }
    }
}

