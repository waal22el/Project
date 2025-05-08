using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 1f;
    public float shootingDistance = 1f;

    protected float nextFire;
    protected Transform player;
    private BossPatrol patrolScript;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        nextFire = Time.time;
        patrolScript = GetComponent<BossPatrol>();
    }

    protected virtual void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= shootingDistance)
        {
            // Stoppa patrullering när spelaren är nära
            if (patrolScript != null)
                patrolScript.enabled = false;

            CheckIfTimeToFire();
        }
        else
        {
            // Återaktivera patrull om spelaren är långt bort
            if (patrolScript != null)
                patrolScript.enabled = true;
        }
    }

    protected void CheckIfTimeToFire()
    {
        if (Time.time >= nextFire)
        {
            Attack();
            nextFire = Time.time + fireRate;
        }
    }

    protected virtual void Attack()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}

