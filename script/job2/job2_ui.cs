using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class job2_ui : MonoBehaviour
{
    public GameObject mulaiUI;
    public GameObject gameUI;
    public GameObject endUI;
    public GameObject pauseUI;
    public GameObject htpUI;

    public Text presstree;
    public Text missed;

    public Text finalpay;

    public bool isstart;

    public int pressed;
    public int miss;

    public float tr_speed;
    
    private ddr ddr;
    private spawnroad sr;

    public int gaji;

    public Slider treespeed;
    public Text speedtext;

    public GameObject[] acce;


    private loadscene ls;
    // Start is called before the first frame update
    void Start()
    {
        ls = FindObjectOfType<loadscene>();
        ddr = FindObjectOfType<ddr>();
        sr = FindObjectOfType<spawnroad>();

        for (int i = 0; i <= 6; i++)
        {
            acce[i].SetActive(false);
        }
        acce[mainm.Instance.curacc].SetActive(true);

        htpUI.SetActive(false);
        mulaiUI.SetActive(true);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        pauseUI.SetActive(false);

        tr_speed = -.3f;

        isstart = false;

    }

    // Update is called once per frame
    void Update()
    {
        presstree.text = pressed.ToString();
        missed.text = miss.ToString();

        
        if (miss >= 3)
        {
            gameUI.SetActive(false);
            endUI.SetActive(true);
            gaji = pressed * mainm.Instance.pay2;
            finalpay.text = "Final Pay: " + pressed.ToString() + " x " + mainm.Instance.pay2.ToString() + " = " + (pressed * mainm.Instance.pay2).ToString() + "$";
            
            Time.timeScale = 0;

        }

        speedtext.text = treespeed.value.ToString();
        tr_speed = 0 - treespeed.value;

        if (Input.GetKeyDown(KeyCode.Escape) && isstart == true){
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
       
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

    public void mulai()
    {
        Time.timeScale = 1;
        Debug.Log("pressed");
        isstart = true;
        mulaiUI.SetActive(false);
        gameUI.SetActive(true); 
        StartCoroutine(ddr.spawntree());
        StartCoroutine(sr.Genroad());
        StartCoroutine(ddr.speedplus());
    }
    public void pulang()
    {
        ls.sceneload(1);
        
    }
    public void backhome()
    {
        mainm.Instance.money += gaji;
        ls.sceneload(1);
        mainm.Instance.daycycle += 1;
    }
}
