using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 25f;
    public Camera playerCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Vänsterklick för attack
        {
            Vector2 mousePos = playerCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.name);

                //  Försök hitta BossAnimationController först
                BossAnimationController boss = hit.collider.GetComponent<BossAnimationController>();
                if (boss != null)
                {
                    boss.TakeDamage((int)damage);
                    Debug.Log("Boss took " + damage + " damage!");
                    return; // Boss träffad, avbryt här
                }

                // Om det inte var en boss, kolla om det är en mob (MonsterDamage)
                MonsterDamage mob = hit.collider.GetComponent<MonsterDamage>();
                if (mob != null)
                {
                    mob.TakeDamage((int)damage);
                    Debug.Log("Mob took " + damage + " damage!");
                    return; // Mob träffad, avbryt här
                }

                Debug.Log("Hit something, but it has no damage script.");
            }
            else
            {
                Debug.Log("Nothing was hit.");
            }
        }
    }
}

