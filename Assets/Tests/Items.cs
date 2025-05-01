using UnityEngine;

public class Items : MonoBehaviour
{
    private Rigidbody2D itemRb;
    public float dropForce = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       itemRb = GetComponent<Rigidbody2D>();
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    
}
