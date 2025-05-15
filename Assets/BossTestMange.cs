using UnityEngine;

public class BossTestDamage : MonoBehaviour
{
    public BossAnimationController bossController;
    public int damageAmount = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bossController != null)
            {
                bossController.TakeDamage(damageAmount);
                Debug.Log("Boss took " + damageAmount + " damage!");
            }
        }
    }
}
