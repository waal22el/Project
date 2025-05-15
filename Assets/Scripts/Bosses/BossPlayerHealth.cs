using UnityEngine;

public class BossPlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    void Start() { currentHealth = maxHealth; }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage! HP left: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player died!");
            gameObject.SetActive(false);
        }
    }
}

