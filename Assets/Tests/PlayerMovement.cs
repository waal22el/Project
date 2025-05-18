using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int MoveUpwards = 0;
    public int MoveLeft = 0;
    public int MoveRight = 0;
    public int MoveDown = 0;

    private Animator animator;
    private Vector2Int movement = new Vector2Int(0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.Set(0, 0);
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForceY(MoveUpwards);
            animator.SetTrigger("Up");
            movement.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForceX(-MoveLeft);
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetTrigger("Side");
            movement.x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForceX(MoveRight);
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetTrigger("Side");
            movement.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForceY(-MoveDown);
            animator.SetTrigger("Down");
            movement.y -= 1;
        }


        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.AddForceY(-MoveUpwards);
            movement.y -= 1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.AddForceX(MoveLeft);
            movement.x += 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.AddForceX(-MoveRight);
            movement.x -= 1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.AddForceY(MoveDown);
            movement.y += 1;
        }

        if (movement.Equals(new Vector2Int(0, 0)))
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

}
