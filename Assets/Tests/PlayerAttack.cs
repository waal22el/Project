using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 25f;
    public Camera playerCamera;

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Left-click
        {

            Debug.Log("Hello");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
    Input.mousePosition.x,
    Input.mousePosition.y,
    -Camera.main.transform.position.z // Needed if camera isn't at z=0
));
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            
            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.name);
                MonsterDamage monster = hit.collider.GetComponent<MonsterDamage>();
                if (monster != null)
                {
                    monster.TakeDamage(damage);
                    Debug.Log("Monster took damage!");
                }
            }
            else
            {
                Debug.Log("Nothing was hit.");
            }
        }
    }
}


