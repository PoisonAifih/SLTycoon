using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume_slider : MonoBehaviour
{
    public Slider volumeslider;
    public Text voltext;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

        volumeslider.onValueChanged.AddListener((v) =>
        {
            voltext.text = v.ToString("0.00");
        });

    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeslider.value;
        Save();
    }

    private void Load()
    {
        volumeslider.value = PlayerPrefs.GetFloat("musicVolume");
        voltext.text = volumeslider.value.ToString();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeslider.value);
    }
}
