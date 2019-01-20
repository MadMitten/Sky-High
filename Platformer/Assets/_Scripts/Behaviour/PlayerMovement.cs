using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 8f;
    float maxSpeed = 8f;
    float maxMag = 8f;
    float jumpForce = 8f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    GameObject goPlayer;
    float groundRadius = 0.35f;

    Rigidbody2D rb;
    bool grounded = false;
    bool facingRight = true;
    public bool physicsBased = true;

    // Start is called before the first frame update
    void Start()
    {
        goPlayer = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
   
        float movement = Input.GetAxis("Horizontal");
        if(movement > 0 && !facingRight)
        {
            flip();
        }
        else if(movement < 0 && facingRight)
        {
            flip();
        }

        Vector2 jumpVec = new Vector2(0, jumpForce);
        Vector2 moveVector = new Vector2(movement, 0);

        if(Input.GetKeyDown("space") && grounded)
        {
            // Debug.Log("Jump");
            rb.AddForce(jumpVec, ForceMode2D.Impulse);
            
            grounded = false;
        }
      
        if (!grounded)
        {
            moveVector = moveVector / 5;
        }


        if (physicsBased)
        {
            rb.AddForce(moveVector * speed);
            limitVelocity();
        }
        else
        {
            goPlayer.transform.Translate((Input.GetAxis("Horizontal")) * 0.1f, 0, 0);
        }
        
    }

    private void limitVelocity()
    {
        Vector2 v = rb.velocity;
        float mag = rb.velocity.magnitude;
        Debug.Log("Magnitude: " + mag);
        if (mag>maxMag)
        {
            speed = 0;
        }
        else
        {
            speed = maxSpeed;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
 

    void OnTriggerEnter2D(Collider2D col)
    {


    }

}
