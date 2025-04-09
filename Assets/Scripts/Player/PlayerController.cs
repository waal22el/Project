using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0;

    private Vector2 input = Vector2.zero;
    private bool moving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            input.x = Input.GetAxisRaw("Horizontal"); // Horizontal or Vertical movement, but not diagonal
            input.y = input.x == 0 ? Input.GetAxisRaw("Vertical") : 0;

            if (input != Vector2.zero)
            {
                Vector3 targetPos = new Vector3(transform.position.x + input.x, transform.position.y + input.y, transform.position.z);

                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)// Moves the player over time
    {
        moving = true;

        while (Mathf.Epsilon < (targetPos - transform.position).sqrMagnitude) // Distance is above tiny float
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        moving = false;
    }
}
