using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    float rotationSpeed = 5f;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0,rotationSpeed,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("You hit a coin");
        Destroy(gameObject);
        GameBehaviour.instance.addCoin();
    }
}
