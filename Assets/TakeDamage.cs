using UnityEngine;

public class BossTestDamage : MonoBehaviour
{
    public BossAnimationController boss; // Dra in din boss här i Inspector
    public int damageAmount = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Tryck på Space för att skada bossen
        {
            if (boss != null)
            {
                boss.TakeDamage(damageAmount);
                Debug.Log("Boss took " + damageAmount + " damage!");
            }
            else
            {
                Debug.LogWarning("Boss reference is missing in Inspector!");
            }
        }
    }
}