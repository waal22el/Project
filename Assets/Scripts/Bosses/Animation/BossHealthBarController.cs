using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarController : MonoBehaviour
{
    public BossAnimationController boss; // Dra in bossen h�r i Inspector
    public Image healthFill;             // Dra in den gr�na "Health Fill"-bilden h�r

    void Update()
    {
        if (boss != null && healthFill != null)
        {
            float fillAmount = (float)boss.currentHealth / boss.maxHealth;
            healthFill.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }
}

