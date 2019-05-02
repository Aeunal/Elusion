using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SpecialAbilityForAlice : MonoBehaviour
{
    public float dashSpeed = 10f;
    public float dashTime = 0.5f;

    private float timer = 0f;
    private MainPlayerController playerControllerRef;
    private bool shouldDash = false;
    private Rigidbody2D rb;
    private bool directionFound = false;
    private float dashDirection;
    private bool didDash = false;
    private bool hitCheck = false;
    private Transform hitChecker;


    void Start()
    {
        playerControllerRef = GetComponent<MainPlayerController>();
        rb = GetComponent<Rigidbody2D>();
        GameObject hitCheckerObj = GameObject.Find("Body");
        hitChecker = hitCheckerObj.transform;
    }

    void Update()
    {
        if (!playerControllerRef.getIsGrounded() && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            shouldDash = true;
        }
        if(playerControllerRef.getIsGrounded())
        {
            shouldDash = false;
            didDash = false;
           
        }
    }

    private void FixedUpdate()
    {
        
       
        if (shouldDash && !didDash)
        {

            hitCheck = Physics2D.OverlapCircle(hitChecker.position, 0.5f, playerControllerRef.whatIsGround);
            if (!directionFound)
            {
                dashDirection = dashSpeed;
                if (playerControllerRef.getLookingRight())
                {
                    dashDirection *= -1;
                }
                directionFound = true;
            }

            rb.MovePosition(rb.position + new Vector2(dashDirection, 0) * Time.deltaTime);
            timer += Time.deltaTime;

            if (timer >= dashTime || hitCheck)
            {
                timer = 0f;
                shouldDash = false;
                directionFound = false;
                didDash = true;
            }
        }
    }

    
}
