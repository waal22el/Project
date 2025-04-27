using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healing = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.FindFirstObjectByType<PlayerController>().Heal(healing);
        Destroy(gameObject);
    }
}
