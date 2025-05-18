using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int MoveUpwards = 3;
    public int MoveLeft = 3;
    public int MoveRight = 3;
    public int MoveDown = 3;

    private Animator animator;
    private Vector2 movement = new Vector2(0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() //Player animation triggers
    {
        movement.Set(0, 0);
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Up");
            movement.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetTrigger("Side");
            movement.x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetTrigger("Side");
            movement.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Down");
            movement.y -= 1;
        }


        if (Input.GetKeyUp(KeyCode.W))
        {
            movement.y -= 1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movement.x += 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movement.x -= 1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movement.y += 1;
        }

        if (movement.Equals(new Vector2(0, 0)))
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    void FixedUpdate() //Player velocity
    {
        movement.Set(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            movement.y += MoveUpwards;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x -= MoveLeft;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x += MoveRight;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y -= MoveDown;
        }

        rb.velocity = movement;
    }
}