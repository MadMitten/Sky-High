using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {
    public Button[] levelButtons;

    private void Start()
    {
        switchButtons();
    }

    private void switchButtons()
    {
        //Debug.Log("Completed Levels: " + PersistenceManager.instance.data.completedLevels);
        foreach (Button button in levelButtons)
        {
            button.interactable = false;
        }

        for (int i = 0; i < PersistenceManager.instance.data.completedLevels; i++)
        {

            //Debug.Log("Completed Levels: " + PersistenceManager.instance.data.completedLevels);
            levelButtons[i].interactable = true;
        }
    }
}
