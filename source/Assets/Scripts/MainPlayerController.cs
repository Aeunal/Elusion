using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MainPlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    private float moveVelocity;
    private bool shouldJump = false;
    private bool lookingRight = true;

    private bool isGrounded;
    private Transform groundCheck;
    private float checkRadius = 0.1f;
    public LayerMask whatIsGround;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject groundChecker = GameObject.Find("Ground Check");
        groundCheck = groundChecker.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
        {
            shouldJump = true;
        }
      
            
        if (shouldJump && isGrounded)
        {
            Debug.Log("yep");
            rb.velocity = Vector2.up * jumpForce;
            shouldJump = false;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
      
        moveVelocity = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVelocity * speed, rb.velocity.y);
      //  rb.MovePosition(rb.position + new Vector2(moveVelocity * speed, 0) * Time.deltaTime);

        if(lookingRight == false && moveVelocity < 0)
        {
            switchDirection();
        }
        else if(lookingRight == true && moveVelocity > 0)
        {
            switchDirection();
        }

        
    }

    void switchDirection()
    {
        lookingRight = !lookingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public bool getIsGrounded()
    {
        return isGrounded;  
    }
    public bool getLookingRight()
    {
        return lookingRight;
    }
    public void setLookingRight(bool value)
    {
        lookingRight = value;
    }


}

