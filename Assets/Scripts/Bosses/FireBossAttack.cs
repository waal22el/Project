using UnityEngine;

public class FireBossAttack : BossAttack
{
    protected override void Attack()
    {
        // Skapa en FireBullet (bullet är redan satt i Inspector)
        Instantiate(bullet, transform.position, Quaternion.identity);

        // Här kan du spela Fire-attack-animation eller ljud
        Debug.Log("FireBoss skjuter!");

        // Sen uppdateras cooldown och avstånd i BossAttack
    }
}

