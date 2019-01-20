using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{
    float speed = 5f;
    float ttl = 0.75f;

    void Awake()
    {
        Destroy(gameObject, ttl);
    }

    void FixedUpdate()
    {
        gameObject.transform.Translate(Vector3.up / speed);
    }
}
