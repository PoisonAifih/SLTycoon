using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSkybox : MonoBehaviour
{
    public Material daysky;
    public Material nightsky;

    // Start is called before the first frame update
    void Start()
    {
        if(mainm.Instance.daycycle <= 3) RenderSettings.skybox = daysky;
        if (mainm.Instance.daycycle >= 3) RenderSettings.skybox = nightsky;
    }

    private void Update()
    {
        if (mainm.Instance.daycycle <= 3) RenderSettings.skybox = daysky;
        if (mainm.Instance.daycycle >= 3) RenderSettings.skybox = nightsky;
    }
}
