using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance = null;
    float speed = 0.035f;
    float airMovement = 5f; //higher is slower
    public float maxSpeed = 8f;
    float maxMag = 8f;
    float jumpForce = 2.5f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    GameObject goPlayer;
    float groundRadius = 0.08f;
    float cooldownTimer = 1f;
    float cooldown = 1f;
    bool cooldownActive = false;
	Animator anim;

    Rigidbody2D rb;

    [HideInInspector]
    public bool grounded = false;
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    bool physicsBased = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        goPlayer = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBehaviour.instance.paused == false)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            if (cooldownActive)
            {
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    cooldownActive = false;
                    cooldown = cooldownTimer;
                }
            }
            //Check for movement.
            //Check if player is jumping.
            //Check if player is on the ground.

            float movement = Input.GetAxis("Horizontal"); //grab movement from input
            Vector2 moveVector = new Vector2(movement, 0); //convert to a Vector2

            checkFlip(movement); //check if player is facing a different direction, and flip if necessary
            checkIfGrounded(); //check if player is grounded

            if (Input.GetKeyDown("space") && grounded) //if player has pressed space, and is on the ground, then jump
            {
                jump();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (cooldownActive == false)
                {
                    shoot();
                    cooldownActive = true;
                }
            }

            if (!grounded) //if not grounded dvide movement by air movement
            {
                moveVector = moveVector / airMovement;
            }

            if (physicsBased)
            {
                rb.AddForce(moveVector * speed);
                limitVelocity();
            }
            else
            {
                goPlayer.transform.Translate((Input.GetAxis("Horizontal")) * speed, 0, 0);
                if (Input.GetAxis("Horizontal") != 0)
                {
                    anim.SetBool("isRunning", true);
                }
                if (Input.GetAxis("Horizontal") == 0)
                {
                    anim.SetBool("isRunning", false);
                }
                if (rb.velocity.y == 0)
                {
                    anim.SetBool("isJumping", false);

                }
            }
        } else
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
        
    }


    private void shoot()
    {
        ShootableObjects.instance.shootObject(1, goPlayer.transform.position, Quaternion.Euler(0,0,0f));
    }

    private void limitVelocity()
    {
        Vector2 v = rb.velocity;
        float mag = rb.velocity.magnitude;
        //Debug.Log("Magnitude: " + mag);
        if (mag>maxMag)
        {
            speed = 0;
        }
        else
        {
            speed = maxSpeed;
        }
    }

    void checkIfGrounded()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    void checkFlip(float movement)
    {
        if ((movement > 0 && !facingRight) || (movement < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    public void jump()
    {
        Vector2 jumpVec = new Vector2(0, jumpForce);
        rb.AddForce(jumpVec, ForceMode2D.Impulse);

        grounded = false;
    }
}
