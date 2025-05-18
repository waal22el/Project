using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 25f;
    public Camera playerCamera;

    public GameObject arrowPrefab;
    public float fireRate = 1f;
    public float arrowSpeed = 6f;
    public Vector3 offset = Vector3.zero;

    private float nextShotTime;

    void Start()
    {
        nextShotTime = Time.time;
    }

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
            
            //Fire arrow
            if (Time.time >= nextShotTime)
            {
                Vector3 direction = mousePos - transform.position;// Get relative direction
                direction.z = 0f;

                Shoot(direction);
                nextShotTime = Time.time + fireRate;
            }
        }
    }

    void Shoot(Vector3 direction)
    {
        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = transform.position +
        (direction - transform.position).normalized * 2f + offset;
        arrow.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        PlayerArrow arrowScript = arrow.GetComponent<PlayerArrow>();
        arrowScript.GoForth(arrowSpeed, (int)damage, new Vector2(direction.x, direction.y));
    }
}
