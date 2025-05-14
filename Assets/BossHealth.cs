using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            // Ladda meny-scenen direkt efter bossen dör
            SceneManager.LoadScene("MenuPostBossFight"); 

            // Förstör bossen 
            Destroy(gameObject);
        }
    }
}

