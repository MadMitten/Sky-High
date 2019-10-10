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
        if (GameBehaviour.instance.paused == false)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                ShootableObjects.instance.shootObject(0, this.transform);
                timer = spawnTime;
            }
        }
    }
}
