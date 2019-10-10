using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{
    [HideInInspector]
    public float speed = 20f;
    [HideInInspector]
    public float ttl = 0.75f;

    void Start()
    {
        //Destroy(gameObject, ttl);
    }

    void FixedUpdate()
    {
        if (GameBehaviour.instance.paused == false)
        {
            gameObject.transform.Translate(Vector2.up / speed);
            ttl -= Time.deltaTime;
            if (ttl <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
