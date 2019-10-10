using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnpauseButton : MonoBehaviour {
    Button unpause, quit;

    private void Start()
    {
        unpause = GameObject.Find("Pause_Resume").GetComponent<Button>();
        quit = GameObject.Find("Pause_Quit").GetComponent<Button>();

        unpause.onClick.AddListener(unpaused);
        quit.onClick.AddListener(quitted);

    }

    private void unpaused()
    {
        //Debug.Log("Unpaused pressed");
        GameBehaviour.instance.unpauseEverything();
    }

    private void quitted()
    {
        SceneController.instance.quitGame();
    }
}
