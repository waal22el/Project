using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int MoveUpwards = 0;
    public int MoveLeft = 0;
    public int MoveRight = 0;
    public int MoveDown = 0;

    private float time = 0f;

    private bool twoSecondTimerPassed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForceY(MoveUpwards);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForceX(-MoveLeft);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForceX(MoveRight);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForceY(-MoveDown);
        }

        //Stop moving when buttons are released
        if (Input.GetKeyUp(KeyCode.W) )
        {
            rb.linearVelocityY = 0;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.linearVelocityY = 0;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.linearVelocityX = 0;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.linearVelocityX = 0;
        }
        

    }

}
