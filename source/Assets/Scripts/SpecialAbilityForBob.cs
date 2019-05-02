using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SpecialAbilityForBob : MonoBehaviour
{
  
    public float GroundBreakerSpeed = 10f;
    private MainPlayerController playerControllerRef;
    private bool shouldGroundBreak = false;
    private Rigidbody2D rb;


    void Start()
    {
        playerControllerRef = GetComponent<MainPlayerController>();
        rb = GetComponent<Rigidbody2D>();
      
    }

    void Update()
    {
       
        if(!playerControllerRef.getIsGrounded() && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            shouldGroundBreak = true;
        }
    }

    private void FixedUpdate()
    {
        if(shouldGroundBreak)
        {
            rb.MovePosition(rb.position + new Vector2(0, -GroundBreakerSpeed) * Time.deltaTime);
            if(playerControllerRef.getIsGrounded())
            {
                shouldGroundBreak = false;
            }
        }
    }
}
