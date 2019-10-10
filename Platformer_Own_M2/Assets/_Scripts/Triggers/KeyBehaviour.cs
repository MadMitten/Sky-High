using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public AudioClip Key_Collection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("You hit a Key");
        GameBehaviour.instance.keyTrue();
        Destroy(gameObject);

        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(Key_Collection, gameObject.transform.position);
        }
    }
}
