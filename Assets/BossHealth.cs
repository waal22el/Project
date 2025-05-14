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
            // Ladda meny-scenen direkt efter bossen d�r
            SceneManager.LoadScene("MenuPostBossFight"); 

            // F�rst�r bossen 
            Destroy(gameObject);
        }
    }
}

