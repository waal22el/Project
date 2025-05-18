using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 25f;
    public Camera playerCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Vänsterklick
        {
            Vector2 mousePos = playerCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.name);

                // Försök hitta MonsterDamage-komponenten först
                MonsterDamage monster = hit.collider.GetComponent<MonsterDamage>();
                if (monster != null)
                {
                    monster.TakeDamage((int)damage); // Antar att MonsterDamage använder int för skada
                    Debug.Log("Monster took damage!");
                    return; // Hoppa ut, vi behöver inte fortsätta kolla
                }

                // Försök hitta BossHealth-komponenten om det inte var ett monster
                BossHealth boss = hit.collider.GetComponent<BossHealth>();
                if (boss != null)
                {
                    boss.TakeDamage((int)damage);
                    Debug.Log("Boss took damage!");
                    return;
                }

                Debug.Log("Hit something, but it has no health script.");
            }
            else
            {
                Debug.Log("Nothing was hit.");
            }
        }
    }
}

