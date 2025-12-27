using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class job3_ui : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject mulaiUI;
    public GameObject gameUI;
    public GameObject endUI;
    public GameObject htpUI;

    public bool isstart;

    private cat_walk cw;
    private cat_walk2 cw2;
    private cat_walk3 cw3;

    public Text pooptext;
    public int poopcollect;

    public Text timetext;
    public int waktu;

    public int gaji;

    public GameObject[] acce;

    public Text finalpay;
    private loadscene ls;
    // Start is called before the first frame update
    void Start()
    {
        ls = FindObjectOfType<loadscene>();
        mulaiUI.SetActive(true);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        pauseUI.SetActive(false);
        htpUI.SetActive(false);

        isstart = false;
        waktu = 60;


        cw = FindObjectOfType<cat_walk>();
        cw2 = FindObjectOfType<cat_walk2>();
        cw3 = FindObjectOfType<cat_walk3>();

        for (int i = 0; i <= 6; i++)
        {
            acce[i].SetActive(false);
        }
        acce[mainm.Instance.curacc].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isstart == true)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        timetext.text = "Timer: " + waktu.ToString();
        pooptext.text = poopcollect.ToString();

        if (waktu <= 0)
        {

            gameUI.SetActive(false);
            endUI.SetActive(true);
            gaji = poopcollect * mainm.Instance.pay3;
            finalpay.text = "Final pay: " + poopcollect + " x " + mainm.Instance.pay3 + " = " + gaji.ToString() + "$";
            
            Time.timeScale = 0f;

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
    public void mulai()
    {
        Time.timeScale = 1;
        isstart = true;
        Debug.Log("pressed");
        mulaiUI.SetActive(false);
        gameUI.SetActive(true);
        StartCoroutine(timer());
        StartCoroutine(cw.spawnpoop());
        StartCoroutine(cw2.spawnpoop());
        StartCoroutine(cw3.spawnpoop());

    }
    public void resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    public void backhome()
    {
        mainm.Instance.money += gaji;
        ls.sceneload(1);
        mainm.Instance.daycycle += 1;
    }
    public void pulang()
    {
        ls.sceneload(1);
    }
    IEnumerator timer()
    {
        while (waktu > 0)
        {
            waktu -= 1;
            yield return new WaitForSeconds(1);
        }
    }
}
