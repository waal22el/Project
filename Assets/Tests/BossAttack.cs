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
        nextFire = Time.time + fireRate;
        patrolScript = GetComponent<BossPatrol>();

    }

    protected virtual void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= shootingDistance)
        {
            // Stoppa patrullering n�r spelaren �r n�ra
            if (patrolScript != null)
                patrolScript.enabled = false;

            CheckIfTimeToFire();
        }
        else
        {
            // �teraktivera patrull om spelaren �r l�ngt bort
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
            Debug.Log("current time = " + Time.time);
            Debug.Log("nextFire = " + nextFire);
            Debug.Log("Delta Time = " + (nextFire - Time.time));
        }
    }

    protected virtual void Attack()
    {


        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}

