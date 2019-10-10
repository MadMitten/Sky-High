using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public AudioClip Door_Unlocking;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("You hit the door");
        if (GameBehaviour.instance.getKey())
        {
            GameBehaviour.instance.win();
        }

        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(Door_Unlocking, gameObject.transform.position);
        }
    }
}
