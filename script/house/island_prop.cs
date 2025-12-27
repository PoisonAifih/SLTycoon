using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class island_prop : MonoBehaviour
{
    public GameObject[] houses;
    public GameObject[] accsesories;

    public GameObject solar;
    public GameObject wind_turb;

    // Start is called before the first frame update
    void Start()
    {
        changeaccs();
        changehouse();

        if (mainm.Instance.boughtsolar == true)
        {
            solar.SetActive(true);
        }
        else if (mainm.Instance.boughtsolar == false)
        {
            solar.SetActive(false);
        }


        if(mainm.Instance.boughtwindturb == true)
        {
            wind_turb.SetActive(true);
        }
        else if (mainm.Instance.boughtwindturb == false)
        {
            wind_turb.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainm.Instance.boughtsolar == true)
        {
            solar.SetActive(true);
        }
        else if (mainm.Instance.boughtsolar == false)
        {
            solar.SetActive(false);
        }


        if (mainm.Instance.boughtwindturb == true)
        {
            wind_turb.SetActive(true);
        }
        else if (mainm.Instance.boughtwindturb == false)
        {
            wind_turb.SetActive(false);
        }
    }

    public void changehouse()
    {
        for(int i = 0; i < 4; i++)
        {
            houses[i].SetActive(false);
        }
        
        houses[mainm.Instance.curhouse].SetActive(true);
    }

    public void changeaccs()
    {
        for (int i = 0; i <= 6; i++)
        {
            accsesories[i].SetActive(false);
        }

        accsesories[mainm.Instance.curacc].SetActive(true);
    }
}
