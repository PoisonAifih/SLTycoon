using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class houseUI : MonoBehaviour
{
    //ui
    public GameObject workchoiceUI;
    public GameObject setUI;
    public GameObject ctrlUI;
    public GameObject introUI;

    public GameObject uphomeUI;
    public GameObject upsaveUI;
    public GameObject upjobUI;
    public GameObject upclothUI;

    public Slider rotatespeed;
    public Text speedtxt;
    public Slider zoomamount;
    public Text zoomtext;

    public bool isworkchoice;
    public bool isset;

    public Text moneytext;
    public Text moneyshop;
    public GameObject moneyshopUI;

    public GameObject job4choiceUI;

    public Text daytext;

    public GameObject sleepUI;
    public GameObject sleepbuttonUI;

    public Button workbutton;

    public GameObject paytaxUI;
    public Text house_type;
    public Text cost;
    public Text payment;

    public GameObject donepay;

    public float paytaxamount;

    public GameObject randomeventUI;
    public Text randomeventtext;
    public GameObject wrongansUI;
    public GameObject rightansUI;
    public Text wrongtext;
    public Text righttext;
    public int randomevent;
    public int spawnrandomevent;

    //script
    private loadscene ls;
    private shopUI sui;
    
    // Start is called before the first frame update
    void Start()
    {
        sui = FindObjectOfType<shopUI>();
        ls = FindObjectOfType<loadscene>();
        isworkchoice = false;
        Time.timeScale = 1;

        job4choiceUI.SetActive(false);
        setUI.SetActive(false);
        ctrlUI.SetActive(false);
        workchoiceUI.SetActive(false);

        uphomeUI.SetActive(false);
        upsaveUI.SetActive(false);
        upjobUI.SetActive(false);
        upclothUI.SetActive(false);

        isset = false;
        paytaxUI.SetActive(false);

        moneyshopUI.SetActive(false);
        sleepUI.SetActive(false);
        sleepbuttonUI.SetActive(false);
        introUI.SetActive(false);

        donepay.SetActive(false);

        if(mainm.Instance.daycycle >= 3)
        {
            nosleep();
            workbutton.enabled = false;
        }

        if(mainm.Instance.day%15 == 0 && mainm.Instance.paytax == false)
        {
            workbutton.enabled = false;
            payeb();
            paytaxUI.SetActive(true);
        }
        if (mainm.Instance.day % 15 != 0)
        {
            mainm.Instance.paytax = false;
        }

        if(mainm.Instance.startplay == true)
        {
            instruction();
            mainm.Instance.startplay = false;
        }

        randomeventUI.SetActive(false);
        spawnrandomevent = Random.Range(0, 15);
        Debug.Log(spawnrandomevent);
        if(spawnrandomevent == 7 && mainm.Instance.daycycle < 3 && mainm.Instance.day % 15 != 0)
        {
            randomeventUI.SetActive(true);
            randomevent = Random.Range(0, 5);
            if (randomevent == 0) randomeventtext.text = "you're out buying lunch and you've been given the option of either a paper box or a styrofoam box. What's your choice?";
            if (randomevent == 1) randomeventtext.text = "you're going on a tour around the city, would you prefer to ride a bicycle or a motorcycle?";
            if (randomevent == 2) randomeventtext.text = "you're out shopping and the cashier asks if you want to use a plastic bag or a tote bag. What's your choice?";
            if (randomevent == 3) randomeventtext.text = "you're going to go to work, will you bring your own bento or would you buy you lunch?";
            if (randomevent == 4) randomeventtext.text = "you have a lot of trash accumulated, will you burn it or will you recycle it?";
        }

        okerandevet();

        if(mainm.Instance.boughtjob4 == true && mainm.Instance.carfactoryrunning == false)
        {
            CarFactory.Instance.waktumobil = 60;
            StartCoroutine(CarFactory.Instance.Carinc());
            mainm.Instance.carfactoryrunning = true;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (mainm.Instance.day % 15 == 0 & mainm.Instance.paytax == false)
        {
            payeb();
            paytaxUI.SetActive(true);
        }
        if (mainm.Instance.day % 15 != 0)
        {
            mainm.Instance.paytax = false;
        }

        moneyshop.text = mainm.Instance.money.ToString() + "$";
        moneytext.text = mainm.Instance.money.ToString() + "$";
        daytext.text = "Day: " + mainm.Instance.day.ToString();

        if (!workchoiceUI.activeSelf)
        {
            isworkchoice = false;
        }
        
        else if (workchoiceUI.activeSelf)
        {
            isworkchoice = true;
        }

        speedtxt.text = rotatespeed.value.ToString();
        zoomtext.text = zoomamount.value.ToString();
    }

    public void workchoice()
    {
        Debug.Log("pressed");
        if (isworkchoice == false)
        {
            workchoiceUI.SetActive(true);
            isworkchoice = true;
            Debug.Log("pressed true");
            if (mainm.Instance.boughtjob4 == true) job4choiceUI.SetActive(true);

        }
        else if (isworkchoice == true)
        {
            workchoiceUI.SetActive(false);
            isworkchoice = false;
            if (mainm.Instance.boughtjob4 == true) job4choiceUI.SetActive(false);
            Debug.Log("pressed false");
        }
    }

    public void randeventbut1()
    {
        randomeventUI.SetActive(false);
        if (randomevent == 0) rightansw();
        if (randomevent == 1) rightansw();
        if (randomevent == 2) wrongansw();
        if (randomevent == 3) rightansw();
        if (randomevent == 4) wrongansw();
    }

    public void randeventbut2()
    {
        randomeventUI.SetActive(false);
        if (randomevent == 0) wrongansw();
        if (randomevent == 1) wrongansw();
        if (randomevent == 2) rightansw();
        if (randomevent == 3) wrongansw();
        if (randomevent == 4) rightansw();
    }

    public void rightansw()
    {
        rightansUI.SetActive(true);
        int rightplus = Random.Range(10, 101);
        righttext.text = "+" + rightplus.ToString() + "$";
        mainm.Instance.money += rightplus;
    }

    public void wrongansw()
    {
        wrongansUI.SetActive(true);
        int wrongmin = Random.Range(10, 101);
        wrongtext.text = "-" + wrongmin.ToString() + "$";
        mainm.Instance.money -= wrongmin;
    }

    public void okerandevet()
    {
        rightansUI.SetActive(false);
        wrongansUI.SetActive(false);
    }
    public void controls()
    {
        ctrlUI.SetActive(true);
        setUI.SetActive(false);
        workchoiceUI.SetActive(false);
    }

    public void instruction()
    {
        introUI.SetActive(true);
    }

    public void closeintro()
    {
        introUI.SetActive(false);
    }
    public void bek()
    {
        ctrlUI.SetActive(false);
        introUI.SetActive(false);
        setUI.SetActive(true);

    }
    public void kluar()
    {
        Application.Quit();
    }

    public void job1()
    {
        ls.sceneload(2);
    }
    public void job2()
    {
        ls.sceneload(3);
    }
    public void job3()
    {
        ls.sceneload(4);
    }

    public void job4()
    {
        ls.sceneload(5);
    }

    public void payeb()
    {

        if (mainm.Instance.curhouse == 0)
        {
            house_type.text = "House type: hut";
            cost.text = "Cost % = " + mainm.Instance.tax1.ToString() + "%";
            paytaxamount = mainm.Instance.money * mainm.Instance.tax1 / 100;
            
        }
        if (mainm.Instance.curhouse == 1)
        {
            house_type.text = "House type: house";
            cost.text = "Cost % = " + mainm.Instance.tax2.ToString() + "%";
            paytaxamount = mainm.Instance.money * mainm.Instance.tax2 / 100;
        }
        if (mainm.Instance.curhouse == 2)
        {
            house_type.text = "House type: minka";
            cost.text = "Cost % = " + mainm.Instance.tax3.ToString() + "%";
            paytaxamount = mainm.Instance.money * mainm.Instance.tax3 / 100;
        }
        if (mainm.Instance.curhouse == 3)
        {
            house_type.text = "House type: mansion";
            cost.text = "Cost % = " + mainm.Instance.tax4.ToString() + "%";
            paytaxamount = mainm.Instance.money * mainm.Instance.tax4 / 100;
        }
        payment.text = "Payment amount = " + ((int)paytaxamount).ToString() + "$";
    }

    public void paytax()
    {
        if(mainm.Instance.money > 0) mainm.Instance.money -= (int)paytaxamount;
        if(mainm.Instance.money < 0) mainm.Instance.money += (int)paytaxamount;
        donepay.SetActive(true);
        mainm.Instance.paytax = true;
    }

    public void closetax()
    {
        donepay.SetActive(false);
        paytaxUI.SetActive(false);
        workbutton.enabled = true;
    }

    public void settings()
    {
        if (isset == false)
        {
            setUI.SetActive(true);
            isset = true;
            Debug.Log("setting true");
            DataPersistenceManager.Instance.SaveGame();
        }
        else if (isset == true)
        {
            setUI.SetActive(false);
            isset = false;
            Debug.Log("setting false");
        }
        
       
    }
    public void closeup()
    {
        uphomeUI.SetActive(false);
        upsaveUI.SetActive(false);
        upjobUI.SetActive(false);
        upclothUI.SetActive(false);
        sui.nemUI.SetActive(false);

        moneyshopUI.SetActive(false);
    }
    public void uphome()
    {
        uphomeUI.SetActive(true);
        upsaveUI.SetActive(false);
        upjobUI.SetActive(false);
        upclothUI.SetActive(false);
        moneyshopUI.SetActive(true);
    }

    public void upsave()
    {
        uphomeUI.SetActive(false);
        upsaveUI.SetActive(true);
        upjobUI.SetActive(false);
        upclothUI.SetActive(false);
        moneyshopUI.SetActive(true);
    }
    public void upjob()
    {
        uphomeUI.SetActive(false);
        upsaveUI.SetActive(false);
        upjobUI.SetActive(true);
        upclothUI.SetActive(false);
        moneyshopUI.SetActive(true);
    }
    public void upcloth()
    {
        uphomeUI.SetActive(false);
        upsaveUI.SetActive(false);
        upjobUI.SetActive(false);
        upclothUI.SetActive(true);
        moneyshopUI.SetActive(true);
    }

    public void walk()
    {
        Time.timeScale = 1f;
        sleepUI.SetActive(false);
        sleepbuttonUI.SetActive(true);
        workbutton.enabled = false;
    }

    public void sleep()
    {
        Time.timeScale = 1f;
        sleepUI.SetActive(false);
        sleepbuttonUI.SetActive(false);
        workbutton.enabled = true;
        mainm.Instance.daycycle = 0;
        mainm.Instance.day += 1;
    }

    public void nosleep()
    {
        workbutton.enabled = false;
        sleepUI.SetActive(true);
        Time.timeScale = 0f;
    }

}
