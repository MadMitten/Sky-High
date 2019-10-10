using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance = null;

    GameObject pauseMenu;
    Text coinText;
    Text livesText;

    void Awake()
    {
        singleton();
    }

    void Start()
    {
        getTextComponents();
        updateUI();
    }

    void getTextComponents()
    {
        GameObject textContainer = GameObject.Find("CoinText");
        GameObject livesContainer = GameObject.Find("LivesText");
        pauseMenu = GameObject.Find("Paused Panel");
        coinText = textContainer.GetComponent<Text>();
        livesText = livesContainer.GetComponent<Text>();
    }

    public void updateUI()
    {
        coinText.text = "COINS: " + GameBehaviour.instance.getCoins();
        livesText.text = "LIVES: " + GameBehaviour.instance.getLives();
        pauseMenu.SetActive(GameBehaviour.instance.paused);
    }

    private void singleton()
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
