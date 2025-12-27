using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mm_ui : MonoBehaviour
{
    public GameObject volumeUI;
    private bool isvolume;
    private loadscene ls;
    private void Start()
    {
        ls = FindObjectOfType<loadscene>();
        volumeUI.SetActive(false);
        isvolume = false;
    }
    public void startgame()
    {
            ls.sceneload(1);
    }

    public void volum()
    {
        if(isvolume == false)
        {
            volumeUI.SetActive(true);
            isvolume = true;
        }
        else if(isvolume == true)
        {
            volumeUI.SetActive(false);
            isvolume = false;
        }
    }
    public void kluar()
    {
        Application.Quit();
    }
}
