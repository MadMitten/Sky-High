using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehaviour : MonoBehaviour {
    public AudioClip Heart_Picked_Up;

    private void OnTriggerEnter2D(Collider2D collider)
	{
		//    Debug.Log("Hit");
		if (collider.gameObject.CompareTag("Player"))
		{
            GameBehaviour.instance.lifeDecrease();
			Destroy(this.gameObject);
		}

        if (collider.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(Heart_Picked_Up, gameObject.transform.position);
        }
    }
}
