using UnityEngine;

public class ShootArrows : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 1f;
    public float shootingRange = 5f;

    private float fireTimer = 0f;
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        fireTimer += Time.deltaTime;

        if (distance <= shootingRange && fireTimer >= fireRate)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            fireTimer = 0f;
        }
    }
}

