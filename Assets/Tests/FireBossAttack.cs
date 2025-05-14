using UnityEngine;

public class FireBossAttack : BossAttack
{
    protected override void Attack()
    {
        // Skapa en FireBullet (bullet �r redan satt i Inspector)
        Instantiate(bullet, transform.position, Quaternion.identity);

        // H�r kan du spela Fire-attack-animation eller ljud
        Debug.Log("FireBoss skjuter!");

        // Sen uppdateras cooldown och avst�nd i BossAttack
    }
}

