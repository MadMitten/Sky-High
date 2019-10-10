using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {
    public static AudioControl instance = null;

    private void Awake()
    {
        if(instance==null )
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void destroyMenuAudio()
    {
        Destroy(this.gameObject);
    }
}
