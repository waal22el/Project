using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;

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
        Debug.Log($"[PlayerHealth] Health after: {health}");

        if(health <= 0)
        {
            Debug.Log("[PlayerHealth] Player destroyed!");
            Destroy(gameObject);
        }
    }

    public void Heal(int healing)
    {
        health = Mathf.Min(health + healing, maxHealth);
        healthBar.SetHP(health);
    }
}
