using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{
    public GameObject starObject;
    public float spawnTime = 4f;
    public float timer = 0.25f;

    private void Start()
    {
        
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Instantiate(starObject,gameObject.transform);
            timer = spawnTime;
        }
    }
}
