using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    [SerializeField] private GameObject gameOverUI;

    public HealthBar healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHP(maxHealth);
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {   
        Debug.Log($"[PlayerHealth] Taking {damage} damage. Health before: {health}");
        health -= damage;
        healthBar.SetHP(health);
        Debug.Log($"[PlayerHealth] Health after: {health}");

        if (health <= 0)
        {
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }

            if(gameObject != null)
                Destroy(gameObject);
            //Debug.Log("[PlayerHealth] Player destroyed!");
            
            
        }
    }

    public void Heal(int healing)
    {
        health = Mathf.Min(health + healing, maxHealth);
        healthBar.SetHP(health);
    }
}
