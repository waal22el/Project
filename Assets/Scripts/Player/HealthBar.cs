using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    public int maxHP = 0;
    private int defaultHP = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (maxHP == 0)
        {
            SetMaxHP(defaultHP);
        }
    }

    public void SetMaxHP(int hp)
    {
        maxHP = hp;
    }

    public void SetHP(int hp)
    {
        health.transform.localScale = new Vector3((float)hp/maxHP, 1f);
    }
}
