using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPlayerMovement : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            if(LevelController.instance.isNextLevelActive())
            {
                player.transform.Translate(Vector3.down * 2);
                LevelController.instance.increaseLevel();
            }
        }

        if (Input.GetKeyDown("w"))
        {
            if (LevelController.instance.isPreviousLevelActive())
            {
                player.transform.Translate(Vector3.up * 2);
                LevelController.instance.decreaseLevel();
            }
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            //get what level at, and go to scene
            LevelController.instance.goToLevel();
        }
    }
}
