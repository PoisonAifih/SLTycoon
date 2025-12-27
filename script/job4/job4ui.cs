using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class job4ui : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject htpUI;
    public GameObject gameUI;
    public Text rate;
    public Text income;
    public Text duit;
    public bool collected;

    private loadscene ls;
        // Start is called before the first frame update
    void Start()
    {
        collected = false;

        ls = FindObjectOfType<loadscene>();

        pauseUI.SetActive(false);
        htpUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        rate.text = "Rate: " + mainm.Instance.pay4.ToString() + "$/min";
        income.text = "accumulated income in factory: " + mainm.Instance.moneyonhold.ToString() + "$";
        duit.text = mainm.Instance.money.ToString() + "$";
    }

    public void htp()
    {
        htpUI.SetActive(true);
    }

    public void bek()
    {
        htpUI.SetActive(false);

    }

    public void resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    public void pulang()
    {
        if (collected == true) mainm.Instance.daycycle += 1;
        ls.sceneload(1);
    }

    public void collect()
    {
        mainm.Instance.money += mainm.Instance.moneyonhold;
        mainm.Instance.moneyonhold = 0;
        collected = true;
    }

    public void hom()
    {
        pauseUI.SetActive(true);
    }
}
