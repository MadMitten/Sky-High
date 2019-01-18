using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameBehaviour.instance.addLife();
        Destroy(gameObject);
    }
}
