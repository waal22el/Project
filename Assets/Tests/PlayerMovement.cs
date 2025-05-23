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
    private Vector2 animationMovement = new Vector2(0, 0);
    private bool moving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() //Player animation triggers
    {

        if (moving && !animationMovement.Equals(movement))
        {
            animationMovement = movement;
            if (movement.y > 0)
            {
                animator.SetTrigger("Up");
            }
            else if (movement.y < 0)
            {
                animator.SetTrigger("Down");
            }
            else if (movement.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                animator.SetTrigger("Side");
            }
            else if (movement.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                animator.SetTrigger("Side");
            }
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

        if (movement.Equals(new Vector2(0, 0)))// Idle
        {
            moving = false;
            animator.SetFloat("Speed", 0);
        }
        else
        {
            moving = true;
            animator.SetFloat("Speed", 1);
        }
    }
}