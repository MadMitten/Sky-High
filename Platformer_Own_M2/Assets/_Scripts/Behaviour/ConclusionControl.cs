using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ConclusionControl : MonoBehaviour
{
    public static ConclusionControl instance = null;
    public Text conclusionHeader;
    void Awake()
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

    public void changeText(bool win)
    {
        if(win)
        {
            conclusionHeader.text = "You Win";
        }
        else
        {
            conclusionHeader.text = "You Lose";
        }
    }
}
