using UnityEngine;

public class Items : MonoBehaviour
{
    [Header("Settings")]
    public float pickupDelay = 0.5f;
    private bool canPickup = false;

    void Start()
    {
        if (TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.AddForce(new Vector2(Random.Range(-1f, 1f), 3f), ForceMode2D.Impulse);
        }

        Invoke(nameof(EnablePickup), pickupDelay);
    }

    void EnablePickup()
    {
        canPickup = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!canPickup) return;

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Item collected!");
        }
    }
}
