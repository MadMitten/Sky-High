using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Out of Bounds");
        PlayerBehaviour.instance.newPlayer();
        GameBehaviour.instance.loseLife();
        Destroy(collision.gameObject);
    }
}
