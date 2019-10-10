using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletBehaviour : MonoBehaviour
{
    float speed = 5f;
    float ttl = 0.75f;
    bool right = false;

    void Awake()
    {
        right = PlayerMovement.instance.facingRight;
        Destroy(gameObject, ttl);
    }

    void FixedUpdate()
    {
        if(right == true)
        {
            //Debug.Log("Facing Right");
            gameObject.transform.Translate(Vector2.right / speed);
        } else
        {
         //   Debug.Log("Not Facing Right");
            gameObject.transform.Translate(Vector2.left / speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if(!collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
