using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlayerPickup : MonoBehaviour
{
    [Header("Settings")]
    public float pickupRadius = 1.5f;

    void Start()
    {
        var collider = GetComponent<CircleCollider2D>();
        collider.radius = pickupRadius;
        collider.isTrigger = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}