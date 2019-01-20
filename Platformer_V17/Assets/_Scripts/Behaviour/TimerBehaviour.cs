using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehaviour : MonoBehaviour {

    public float minutes = 1;
    float value = 60f;
    float timer;

    private void Start()
    {
        resetTimer();
    }

    void setTimerTextBox(float newValue)
    {
        string secondsLeadingZero;
        if(timer>=10f)
        {
            secondsLeadingZero = "";
        }
        else
        {
            secondsLeadingZero = "0";
        }
        string timerTextString = minutes + ":" + secondsLeadingZero + Mathf.Floor(timer);
       // Debug.Log(timerTextString);
        GameObject textBoxHolder = GameObject.Find("Timer");
        Text timerText = textBoxHolder.GetComponent<Text>();
        timerText.text = "" + timerTextString;
    }

    void resetTimer()
    {
        timer = 1 * value;
    }
    
    void Update () {
        if(minutes > 0)
        {
            if(timer%60 == 0)
            {
                minutes--;
            }
        }
		if(timer - Time.deltaTime > 0)
        {
            timer -= Time.deltaTime;
            setTimerTextBox(timer);
        }
        else if (timer - Time.deltaTime < 0)
        {
            if (minutes > 0)
            {
                minutes--;
                resetTimer();
            }
            else
            {
                setTimerTextBox(0f);
            }
        }
        else
        {

        }
	}
}
