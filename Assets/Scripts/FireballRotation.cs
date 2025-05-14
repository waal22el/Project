using UnityEngine;

public class FireballRotation : MonoBehaviour
{

    public Transform player;

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply the rotation
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    
}
