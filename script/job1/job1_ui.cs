using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class job1_ui : MonoBehaviour
{
    public GameObject mulaiUI;
    public GameObject gameUI;
    public GameObject endUI;
    public GameObject pauseUI;
    public GameObject htpUI;

    public Text right;
    public Text wrong;
    public Text timer_text;
    public Text finalpay;
    public Text benertext;
    public Text salahtext;

    public int bnr;
    public int slh;

    public int waktu;

    public int gaji;

    private bucket bc;

    public bool isstart;
    public bool pausepressed;

    public GameObject[] acce;

    private loadscene ls;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <= 6; i++)
        {
            acce[i].SetActive(false);
        }
        acce[mainm.Instance.curacc].SetActive(true);

        ls = FindObjectOfType<loadscene>();
        bc = FindObjectOfType<bucket>();

        mulaiUI.SetActive(true);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        pauseUI.SetActive(false);
        htpUI.SetActive(false);

        waktu = 30;

        Time.timeScale = 0f;
        isstart = false;

        pausepressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        right.text = bnr.ToString();
        wrong.text = slh.ToString();

        timer_text.text = "Timer: " + waktu.ToString();

        if(waktu <= 0)
        {
            bc.itemspawn = true;
            gameUI.SetActive(false);
            endUI.SetActive(true);
            endtext();
            for (int i = 0; i < 2; i++)
            {
                bc.rw[i].SetActive(false);
            }
            Time.timeScale = 0f;
            
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isstart == true)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            pausepressed = true;
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
        pausepressed = false;
    }

    void endtext()
    {
        benertext.text = "Right: " + bnr.ToString();
        salahtext.text = "Wrong: -" + slh.ToString();
        gaji = (bnr - slh) * mainm.Instance.pay1;
        finalpay.text = "Final Pay: " + (bnr - slh).ToString() +" x " + mainm.Instance.pay1.ToString() + " = " + gaji.ToString() + "$";
        
    }

    public void mulai()
    {
        Time.timeScale = 1f;
        isstart = true;
        mulaiUI.SetActive(false);
        gameUI.SetActive(true);
        StartCoroutine(timer());
        bc.itemspawn = false;
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
        while(waktu > 0)
        {
            waktu -= 1;
            yield return new WaitForSeconds(1);
        }
    }
}
