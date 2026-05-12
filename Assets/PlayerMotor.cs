using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    private bool canDash = true;
    private Rigidbody2D rigidbody2D;
    public float speed = 10;
    public float jumpForce = 10;
    public float maxspeed = 10;
    public float stoppingforce = 5;
    public float multijump;
    public float max_jumps = 2;
    public float dashForce = 10;
    private float dashTime;
    public float dashDuration = 0.2f;


  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();

    }

  
    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
        HandleMaxSpeed();
        PlayerStopping();


    }

    private void MovePlayer()
    {
        rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
    }

    private void HandleMaxSpeed()
    {
        if(dashTime > 0)
        {
            dashTime -= Time.fixedDeltaTime;
            return;
        }

        if (rigidbody2D.linearVelocityX >= maxspeed)
        {
            rigidbody2D.linearVelocityX = maxspeed;
        }
        else if (rigidbody2D.linearVelocityX <= -maxspeed)
        {
            rigidbody2D.linearVelocityX = -maxspeed;
        }
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingforce, 0));
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (multijump > 0)
            {
                multijump--;
            }
            else if (multijump == 0)
            {
                canJump = false;
            }
           
        }
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        canDash = true;
        multijump = max_jumps;
    }

    private void OnDash()
    {
        if(canDash)
        {
            rigidbody2D.AddForce(new Vector2(direction.x * dashForce, 0), ForceMode2D.Impulse);
            dashTime = dashDuration;
        }

    }



   


}
