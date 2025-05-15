using UnityEngine;

public class Items : MonoBehaviour
{
    private Rigidbody2D itemRb;
    public float dropForce = 5;
    void Start()
    {
       itemRb = GetComponent<Rigidbody2D>();
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }
}
