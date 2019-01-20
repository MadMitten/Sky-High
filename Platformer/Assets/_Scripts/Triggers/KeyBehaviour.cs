using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You hit a Key");
        GameBehaviour.instance.keyTrue();
        Destroy(gameObject);
    }
}
