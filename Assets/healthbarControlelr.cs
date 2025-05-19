using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarController : MonoBehaviour
{
    public BossAnimationController boss; // Dra in bossen här i Inspector
    public Image healthFill;             // Dra in den gröna "Health Fill"-bilden här

    void Update()
    {
        if (boss != null && healthFill != null)
        {
            float fillAmount = (float)boss.currentHealth / boss.maxHealth;
            healthFill.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }
}