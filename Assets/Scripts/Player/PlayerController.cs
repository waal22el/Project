using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0;
    public int maxHealth = 10;
    public HealthBar healthBar;
    
    private int currentHealth;
    private Vector2 input = Vector2.zero;
    private bool moving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHP(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            input.x = Input.GetAxisRaw("Horizontal"); // Horizontal or Vertical movement, but not diagonal
            input.y = input.x == 0 ? Input.GetAxisRaw("Vertical") : 0;

            if (input != Vector2.zero)
            {
                Vector3 targetPos = new Vector3(transform.position.x + input.x, transform.position.y + input.y, transform.position.z);

                StartCoroutine(Move(targetPos));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1); //Testing damage
        }
    }

    IEnumerator Move(Vector3 targetPos)// Moves the player over time
    {
        moving = true;

        while (Mathf.Epsilon < (targetPos - transform.position).sqrMagnitude) // Distance is above tiny float
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        moving = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHP(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int healing)
    {
        currentHealth = Mathf.Min(currentHealth + healing, maxHealth);
        healthBar.SetHP(currentHealth);
    }
}
