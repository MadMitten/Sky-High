using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanishingPlatformBehaviour : MonoBehaviour
{
    float ttl = 10f;
    public float vanishSpeed = 2f;
    bool playerOnMe = false;
    Rigidbody2D rb;
    SpriteRenderer sr;


    private void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(playerOnMe)
        {
           // Debug.Log("Time To Live: " + ttl);
            ttl -= Time.deltaTime*vanishSpeed;
            Color tmp = sr.color;

            tmp.a = ttl/10;

            sr.color = tmp;
        }
        if(ttl<=0)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("Player hit me");
        playerOnMe = true;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        playerOnMe = false;
    }
}
