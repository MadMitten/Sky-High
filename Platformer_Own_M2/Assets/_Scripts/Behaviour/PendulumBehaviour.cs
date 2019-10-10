using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumBehaviour : MonoBehaviour
{
    GameObject obPend;
    public GameObject target;
    Vector3 zAxis = new Vector3(0, 0, 1);
    bool leftToRight = true;
    public float speed = 60f;
    public float swingAngle = 70f;
    Quaternion constraintA;
    Quaternion constraintB;

    private void Awake()
    {
        obPend = this.gameObject;
    }

    void Update()
    {
        if (GameBehaviour.instance.paused == false)
        {
            constraintA = Quaternion.Euler(0, 0, swingAngle);
            constraintB = Quaternion.Euler(0, 0, -swingAngle);

            if (leftToRight)
            {
                obPend.transform.RotateAround(target.transform.position, zAxis * 1, speed * Time.deltaTime);
                if (obPend.transform.rotation.z > constraintA.z)
                {
                    leftToRight = false;
                }
            }
            else
            {
                obPend.transform.RotateAround(target.transform.position, zAxis * -1, speed * Time.deltaTime);
                if (obPend.transform.rotation.z < constraintB.z)
                {
                    leftToRight = true;
                }
            }
        }
    }
}
