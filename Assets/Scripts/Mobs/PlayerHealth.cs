using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject gameOverUI; 
    public int maxHealth = 10;
    public int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (gameObject != null)
                Destroy(gameObject);
                gameOverUI.SetActive(true);
        }

    }

    internal void Heal(int healing)
    {
        throw new NotImplementedException();
    }
}
