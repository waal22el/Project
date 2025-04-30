using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet; // Prefab som bossen skjuter
    public float fireRate = 1f;
    protected float nextFire;
    public float shootingDistance = 10f;
    protected Transform player;

    protected virtual void Start()
    {
        nextFire = Time.time;
        player = GameObject.FindWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        CheckIfTimeToFire();
    }

    protected void CheckIfTimeToFire()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= shootingDistance && Time.time > nextFire)
        {
            Attack();
            nextFire = Time.time + fireRate;
        }
    }

    protected virtual void Attack()
    {
        // Grundattack (kan vara tom eller skjuta en standardkula)
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}



