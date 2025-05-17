using UnityEngine;

public class FireBossAttack : BossAttack
{
    protected override void Attack()
    {

        Vector3 direction = player.position - transform.position;
        direction.z = 0; // Only needed in 2D games to avoid tilting into Z

        // Calculate rotation
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Instantiate and apply rotation
        Instantiate(bullet, transform.position, rotation);

        // H�r kan du spela Fire-attack-animation eller ljud
        Debug.Log("FireBoss skjuter!");

        // Sen uppdateras cooldown och avst�nd i BossAttack
    }
}

