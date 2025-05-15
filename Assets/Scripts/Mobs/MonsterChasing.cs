using UnityEngine;

public class MonsterChasing : MonoBehaviour
{
    public Transform playerTransform;
    private Movement movementScript;
    public float chaseDistance;
    public float moveSpeed;
    public float chaseDuration;
    private float chaseTimer;
    private bool hasChased = false;
    void Start()
    {
        movementScript = GetComponent<Movement>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if (!movementScript.isChasing && distanceToPlayer < chaseDistance)
        {
            movementScript.isChasing = true;
            chaseTimer = chaseDuration;
            hasChased = true;
        }
        if (movementScript.isChasing)
        {
            chaseTimer -= Time.deltaTime; // Decrease the timer
            if (chaseTimer <= 0f)
            {
                movementScript.isChasing = false;
            }
            else
            {
                ChasePlayer();
            }
        }

    }
    void ChasePlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
