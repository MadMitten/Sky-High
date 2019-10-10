using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float timerValue = 4.5f;
    float timeToTurn = 0;
    //float speedOfTurn = 30f;
    //float angleOfTurn = 90f;
    bool turn = false;
    void FixedUpdate()
    {
        if (GameBehaviour.instance.paused == false)
        {
            timeToTurn -= Time.deltaTime; //countdown of timeToTurn seconds
                                          // Debug.Log("PlatformTurn: " + timeToTurn);
            if (timeToTurn <= 0)
            {
                timeToTurn = timerValue;
                turn = !turn;
            }
            if (turn)
            {
                rotateObject();
            }
        }
    }

    void rotateObject()
    {
        gameObject.transform.Rotate(0, 0, 1);
    }
}
