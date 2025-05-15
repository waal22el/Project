using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Image fillImage;
    public BossHealth bossHealth;

    void Update()
    {
        if (bossHealth != null && fillImage != null)
        {
            float fillAmount = (float)bossHealth.currentHealth / bossHealth.maxHealth;
            fillImage.fillAmount = fillAmount;
        }
    }
}

