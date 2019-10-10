using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjects : MonoBehaviour
{
    public static ShootableObjects instance = null;
    public GameObject[] shootables;


    private void Awake()
    {
        singleton();
    }

    public void shootObject(int index, Transform tran)
    {
        Instantiate(shootables[index], tran);
    }

    public GameObject shootObject(int index, Vector3 pos, Quaternion quat)
    {
        //Debug.Log("Position: " + tran.position);
        //Debug.Log("Transform: " + tran);
        GameObject go = Instantiate(shootables[index],pos,quat);
        return go;
    }


    void singleton()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }
}
