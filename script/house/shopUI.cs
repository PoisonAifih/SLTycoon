using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopUI : MonoBehaviour
{
    public GameObject nemUI;

    //up home
    public Text house1text;
    public Text house2text;
    public Text house3text;
    public Text house4text;

    public Button house1but;
    public Button house2but;
    public Button house3but;
    public Button house4but;

    //up save
    public Text solarbuttext;
    public Text windbuttext;

    public Text lvlsolartext;
    public Text lvlwindtext;

    public Button solarbut;
    public Button windbut;

    public Text resolartext;
    public Text rewindtext;

    //up job
    public Text lvljob1;
    public Text lvljob2;
    public Text lvljob3;
    public Text lvljob4;

    public Text payjob1;
    public Text payjob2;
    public Text payjob3;
    public Text payjob4;

    public Text upgjob1;
    public Text upgjob2;
    public Text upgjob3;
    public Text upgjob4;

    public Button job1but;
    public Button job2but;
    public Button job3but;
    public Button job4but;

    public Text job1buttext;
    public Text job2buttext;
    public Text job3buttext;
    public Text job4buttext;

    //up clothes
    public Text glassestext;
    public Text wingstext;
    public Text bowtext;
    public Text hat1text;
    public Text hat2text;
    public Text crowntext;

    public Text glassestextbut;
    public Text wingstextbut;
    public Text bowtextbut;
    public Text hat1textbut;
    public Text hat2textbut;
    public Text crowntextbut;

    public Button glassesbut;
    public Button wingsbut;
    public Button bowbut;
    public Button hat1but;
    public Button hat2but;
    public Button crownbut;

    //change house
    public GameObject confirmchangehouseUI;
    public GameObject nochangehouseUI;

    public int changeto;

    //script
    private island_prop ip;
    // Start is called before the first frame update
    void Start()
    {

        ip = FindObjectOfType<island_prop>();

        nemUI.SetActive(false);

        confirmchangehouseUI.SetActive(false);
        nochangehouseUI.SetActive(false);

}

    // Update is called once per frame
    void Update()
    {
        //buy house
        if (mainm.Instance.curhouse == 0)
        {
            house1text.text = "Equipped";
            house1but.enabled = false;
        }
        if (mainm.Instance.curhouse == 1)
        {
            house2text.text = "Equipped";
            house2but.enabled = false;
        }
        if (mainm.Instance.curhouse == 2)
        {
            house3text.text = "Equipped";
            house3but.enabled = false;
        }
        if (mainm.Instance.curhouse == 3)
        {
            house4text.text = "Equipped";
            house4but.enabled = false;
        }

        if (mainm.Instance.boughthouse2 == true && mainm.Instance.curhouse != 1)
        {
            house2text.text = "Equip";
            house2but.enabled = true;
        }
        if (mainm.Instance.boughthouse3 == true && mainm.Instance.curhouse != 2)
        {
            house3text.text = "Equip";
            house3but.enabled = true;
        }
        if (mainm.Instance.boughthouse4 == true && mainm.Instance.curhouse != 3)
        {
            house4text.text = "Equip";
            house4but.enabled = true;
        }

        if (mainm.Instance.curhouse != 0)
        {
            house1text.text = "Equip";
            house1but.enabled = true;
        }

        //buy save money from tax 
        if (mainm.Instance.boughtsolar == false)
        {
            solarbuttext.text = "buy";
            lvlsolartext.text = "15.000$";
        }
        else if (mainm.Instance.boughtsolar == true && mainm.Instance.lvlsolar < 10)
        {
            solarbuttext.text = "Upgrade";
            lvlsolartext.text = "Level: " + mainm.Instance.lvlsolar + " Upgrade: " + mainm.Instance.upsolar + "$";
            lvlwindtext.text = "Level: " + mainm.Instance.lvlwindturb + " Upgrade: " + mainm.Instance.upwindturb + "$";
        }
        else if (mainm.Instance.boughtsolar == true && mainm.Instance.lvlsolar == 10)
        {
            solarbuttext.text = "Max lv";
            solarbut.enabled = false;

        }

        if(mainm.Instance.boughtsolar == true) resolartext.text = "Electric bill reduce: " + mainm.Instance.reducesolar.ToString() + "%";
        else if (mainm.Instance.boughtsolar == false) resolartext.text = "Electric bill reduce: 0.4%";
        if (mainm.Instance.boughtwindturb == true) rewindtext.text = "Electric bill reduce: " + mainm.Instance.reducewind.ToString() + "%";
        else if (mainm.Instance.boughtwindturb == false) rewindtext.text = "Electric bill reduce: 0.8%";


        if (mainm.Instance.boughtwindturb == false)
        {
            windbuttext.text = "buy";
            lvlwindtext.text = "42.000$";
        }
        else if (mainm.Instance.boughtwindturb == true && mainm.Instance.lvlwindturb < 10)
        {
            windbuttext.text = "Upgrade";
            lvlsolartext.text = "Level: " + mainm.Instance.lvlsolar + " Upgrade: " + mainm.Instance.upsolar + "$";
            lvlwindtext.text = "Level: " + mainm.Instance.lvlwindturb + " Upgrade: " + mainm.Instance.upwindturb + "$";
        }
        else if (mainm.Instance.boughtwindturb == true && mainm.Instance.lvlwindturb == 10)
        {
            windbuttext.text = "Max lv";
            windbut.enabled = false;
        }

        //up job
        lvljob1.text = "Lv " + mainm.Instance.lvljob1.ToString();
        lvljob2.text = "Lv " + mainm.Instance.lvljob2.ToString();
        lvljob3.text = "Lv " + mainm.Instance.lvljob3.ToString();
        lvljob4.text = "Lv " + mainm.Instance.lvljob4.ToString();

        payjob1.text = "Pay: " + mainm.Instance.pay1.ToString() + "$";
        payjob2.text = "Pay: " + mainm.Instance.pay2.ToString() + "$";
        payjob3.text = "Pay: " + mainm.Instance.pay3.ToString() + "$";

        if (mainm.Instance.lvljob1 < 10)
        {
            upgjob1.text = mainm.Instance.upjob1.ToString() + "$";
            job1buttext.text = "Upgrade";
        }
        if (mainm.Instance.lvljob1 == 10)
        {
            job1buttext.text = "Lv Max";
            job1but.enabled = false;
            upgjob1.text ="";
        }

        if (mainm.Instance.lvljob2 == 10)
        {
            job2buttext.text = "Lv Max";
            job2but.enabled = false;
            upgjob2.text = "";
        }
        if (mainm.Instance.lvljob2 < 10)
        {
            upgjob2.text = mainm.Instance.upjob2.ToString() + "$";
            job2buttext.text = "Upgrade";
        }
        

        if (mainm.Instance.lvljob3 < 10)
        {
            upgjob3.text = mainm.Instance.upjob3.ToString() + "$";
            job2buttext.text = "Upgrade";
        }
        if (mainm.Instance.lvljob3 == 10)
        {
            job3buttext.text = "Lv Max";
            job3but.enabled = false;
            upgjob3.text = "";
        }

        //job car
        if (mainm.Instance.boughtjob4 == true)
        {
            payjob4.text = "Pay: " + mainm.Instance.pay4.ToString() + "$/min";
            if (mainm.Instance.lvljob4 < 10)
            {
                upgjob4.text = mainm.Instance.upjob4.ToString() + "$";
                job4buttext.text = "Upgrade";
            }
            else if (mainm.Instance.lvljob1 == 10)
            {
                job4buttext.text = "Lv Max";
                job4but.enabled = false;
                upgjob4.text = "";
            }
        }
        else if (mainm.Instance.boughtjob4 == false)
        {
            job4buttext.text = "Buy";
        }

        //tax
        mainm.Instance.tax1 = 13 - (mainm.Instance.reducesolar + mainm.Instance.reducewind);
        mainm.Instance.tax2 = 20 - (mainm.Instance.reducesolar + mainm.Instance.reducewind);
        mainm.Instance.tax3 = 29 - (mainm.Instance.reducesolar + mainm.Instance.reducewind);
        mainm.Instance.tax4 = 40 - (mainm.Instance.reducesolar + mainm.Instance.reducewind);

        //clothes
        if (mainm.Instance.curacc == 1)
        {
            glassestextbut.text = "Equipped";
            glassesbut.enabled = false;
        }
        if (mainm.Instance.curacc == 2)
        {
            wingstextbut.text = "Equipped";
            wingsbut.enabled = false;
        }
        if (mainm.Instance.curacc == 3)
        {
            bowtextbut.text = "Equipped";
            bowbut.enabled = false;
        }
        if (mainm.Instance.curacc == 4)
        {
            hat1textbut.text = "Equipped";
            hat1but.enabled = false;
        }
        if (mainm.Instance.curacc == 5)
        {
            hat2textbut.text = "Equipped";
            hat2but.enabled = false;
        }
        if (mainm.Instance.curacc == 6)
        {
            crowntextbut.text = "Equipped";
            crownbut.enabled = false;
        }

        if (mainm.Instance.boughtglasses == true && mainm.Instance.curacc != 1)
        {
            glassestextbut.text = "Equip";
            glassesbut.enabled = true;
        }
        if (mainm.Instance.boughtwings == true && mainm.Instance.curacc != 2)
        {
            wingstextbut.text = "Equip";
            wingsbut.enabled = true;
        }
        if (mainm.Instance.boughtbow == true && mainm.Instance.curacc != 3)
        {
            bowtextbut.text = "Equip";
            bowbut.enabled = true;
        }
        if (mainm.Instance.boughthat1 == true && mainm.Instance.curacc != 4)
        {
            hat1textbut.text = "Equip";
            hat1but.enabled = true;
        }
        if (mainm.Instance.boughthat2 == true && mainm.Instance.curacc != 5)
        {
            hat2textbut.text = "Equip";
            hat2but.enabled = true;
        }
        if (mainm.Instance.boughtcrown == true && mainm.Instance.curacc != 6)
        {
            crowntextbut.text = "Equip";
            crownbut.enabled = true;
        }

        if (mainm.Instance.boughtglasses == true) glassestext.text = "";
        if (mainm.Instance.boughtwings == true) wingstext.text = "";
        if (mainm.Instance.boughtbow == true) bowtext.text = "";
        if (mainm.Instance.boughthat1 == true) hat1text.text = "";
        if (mainm.Instance.boughthat2 == true) hat2text.text = "";
        if (mainm.Instance.boughtcrown == true) crowntext.text = "";
    }

    public void oke()
    {
        nemUI.SetActive(false);
    }

    //uphome

    public void house1()
    {
        if (mainm.Instance.curhouse != 0 && mainm.Instance.day % 15 == 0 && mainm.Instance.day % 15 == 0)
        {
            changeto = 0;
            confirmchangehouseUI.SetActive(true);
        }
        else if ( mainm.Instance.curhouse != 0 && mainm.Instance.day % 15 != 0)
        {
            nochangehouseUI.SetActive(true);
        }
    }
    public void buyhouse2()
    {
        if (mainm.Instance.boughthouse2 == false)
        {
            if (mainm.Instance.money >= 50000)
            {
                mainm.Instance.boughthouse2 = true;
                mainm.Instance.money -= 50000;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughthouse2 == true && mainm.Instance.curhouse != 1 && mainm.Instance.day%15 == 0)
        {
            changeto = 1;
            confirmchangehouseUI.SetActive(true);
        }
        else if (mainm.Instance.boughthouse2 == true && mainm.Instance.curhouse != 1 && mainm.Instance.day % 15 != 0)
        {
            nochangehouseUI.SetActive(true);
        }

    }

    public void buyhouse3()
    {
        if (mainm.Instance.boughthouse3 == false)
        {
            if (mainm.Instance.money >= 25000)
            {
                mainm.Instance.boughthouse3 = true;
                mainm.Instance.money -= 25000;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughthouse3 == true && mainm.Instance.curhouse != 2 && mainm.Instance.day % 15 == 0)
        {
            changeto = 2;
            confirmchangehouseUI.SetActive(true);
        }
        else if (mainm.Instance.boughthouse3 == true && mainm.Instance.curhouse != 2 && mainm.Instance.day % 15 != 0)
        {
            nochangehouseUI.SetActive(true);
        }

    }

    public void buyhouse4()
    {
        if (mainm.Instance.boughthouse4 == false)
        {
            if (mainm.Instance.money >= 100000)
            {
                mainm.Instance.boughthouse4 = true;
                mainm.Instance.money -= 100000;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughthouse4 == true && mainm.Instance.curhouse != 3 && mainm.Instance.day % 15 == 0)
        {
            changeto = 3;
            confirmchangehouseUI.SetActive(true);
        }
        else if (mainm.Instance.boughthouse4 == true && mainm.Instance.curhouse != 3 && mainm.Instance.day % 15 != 0)
        {
            nochangehouseUI.SetActive(true);
        }

    }

    public void yesconfirm()
    {
        mainm.Instance.curhouse = changeto;
        ip.changehouse();
        confirmchangehouseUI.SetActive(false);
    }

    public void cancelconfirm()
    {
        confirmchangehouseUI.SetActive(false);
    }

    public void closenochange()
    {
        nochangehouseUI.SetActive(false);
    }


    //upsave
    public void buysolar()
    {
        if (mainm.Instance.boughtsolar == false)
        {
            if (mainm.Instance.money >= 15000)
            {
                mainm.Instance.boughtsolar = true;
                mainm.Instance.money -= 15000;
                mainm.Instance.reducesolar = 0.4f;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughtsolar == true)
        {
            if (mainm.Instance.money >= mainm.Instance.upsolar)
            {
                mainm.Instance.money -= mainm.Instance.upsolar;
                mainm.Instance.upsolar += 2000;
                mainm.Instance.lvlsolar += 1;
                mainm.Instance.reducesolar += 0.4f;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
    }
    public void buywind()
    {
        if (mainm.Instance.boughtwindturb == false)
        {
            if (mainm.Instance.money >= 42000)
            {
                mainm.Instance.boughtwindturb = true;
                mainm.Instance.money -= 42000;
                mainm.Instance.reducewind = 0.8f;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughtwindturb == true)
        {
            if (mainm.Instance.money >= mainm.Instance.upwindturb)
            {
                mainm.Instance.money -= mainm.Instance.upwindturb;
                mainm.Instance.upwindturb += 5000;
                mainm.Instance.lvlwindturb += 1;
                mainm.Instance.reducewind += 0.8f;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
    }


    //uphob

    public void upjob1()
    {
        if (mainm.Instance.money >= mainm.Instance.upjob1 && mainm.Instance.lvljob1 < 10)
        {
            mainm.Instance.money -= mainm.Instance.upjob1;
            mainm.Instance.upjob1 += 500;
            mainm.Instance.pay1 += 5;
            mainm.Instance.lvljob1 += 1;
            
        }
        else
        {
            nemUI.SetActive(true);
        }
    }
    public void upjob2()
    {
        if (mainm.Instance.money >= mainm.Instance.upjob2 && mainm.Instance.lvljob2 < 10)
        {
            mainm.Instance.money -= mainm.Instance.upjob2;
            mainm.Instance.upjob2 += 1000;
            mainm.Instance.pay2 += 10;
            mainm.Instance.lvljob2 += 1;
        }
        else
        {
            nemUI.SetActive(true);
        }
    }
    public void upjob3()
    {
        if (mainm.Instance.money >= mainm.Instance.upjob3 && mainm.Instance.lvljob3 < 10)
        {
            mainm.Instance.money -= mainm.Instance.upjob3;
            mainm.Instance.upjob3 += 500;
            mainm.Instance.pay3 += 5;
            mainm.Instance.lvljob3 += 1;
            
        }
        else
        {
            nemUI.SetActive(true);
        }
    }
    public void upjob4()
    {
        if (mainm.Instance.boughtjob4 == false)
        {
            if (mainm.Instance.money >= mainm.Instance.upjob4)
            {
                mainm.Instance.boughtjob4 = true;
                mainm.Instance.money -= mainm.Instance.upjob4;
                mainm.Instance.upjob4 += 5000;
                CarFactory.Instance.waktumobil = 60;
                StartCoroutine(CarFactory.Instance.Carinc());
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughtjob4 == true && mainm.Instance.lvljob4 < 10)
        {
            if (mainm.Instance.money >= mainm.Instance.upjob4)
            {
                mainm.Instance.money -= mainm.Instance.upjob4;
                mainm.Instance.upjob4 += 10000;
                mainm.Instance.pay4 += 20;
                mainm.Instance.lvljob4 += 1;

            }
            else
            {
                nemUI.SetActive(true);
            }
        }
    }

    //accesories
    public void buyglasses()
    {
        if (mainm.Instance.boughtglasses == false)
        {
            if (mainm.Instance.money >= 2000)
            {
                mainm.Instance.boughtglasses = true;
                mainm.Instance.money -= 2000;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughtglasses == true && mainm.Instance.curacc != 1)
        {
            mainm.Instance.curacc = 1;
            ip.changeaccs();
        }
    }
    public void buywings()
    {
        if (mainm.Instance.boughtwings == false)
        {
            if (mainm.Instance.money >= 8000)
            {
                mainm.Instance.boughtwings = true;
                mainm.Instance.money -= 8000;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughtwings == true && mainm.Instance.curacc != 2)
        {
            mainm.Instance.curacc = 2;
            ip.changeaccs();
        }
    }

    public void buybow()
    {
        if (mainm.Instance.boughtbow == false)
        {
            if (mainm.Instance.money >= 1000)
            {
                mainm.Instance.boughtbow = true;
                mainm.Instance.money -= 1000;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughtbow == true && mainm.Instance.curacc != 3)
        {
            mainm.Instance.curacc = 3;
            ip.changeaccs();
        }
    }
    public void buyhat1()
    {
        if (mainm.Instance.boughthat1 == false)
        {
            if (mainm.Instance.money >= 5000)
            {
                mainm.Instance.boughthat1 = true;
                mainm.Instance.money -= 5000;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughthat1 == true && mainm.Instance.curacc != 4)
        {
            mainm.Instance.curacc = 4;
            ip.changeaccs();
        }
    }
    public void buyhat2()
    {
        if (mainm.Instance.boughthat2 == false)
        {
            if (mainm.Instance.money >= 3000)
            {
                mainm.Instance.boughthat2 = true;
                mainm.Instance.money -= 3000;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughthat2 == true && mainm.Instance.curacc != 5)
        {
            mainm.Instance.curacc = 5;
            ip.changeaccs();
        }
    }
    public void buycrown()
    {
        if (mainm.Instance.boughtcrown == false)
        {
            if (mainm.Instance.money >= 10000)
            {
                mainm.Instance.boughtcrown = true;
                mainm.Instance.money -= 10000;
            }
            else
            {
                nemUI.SetActive(true);
            }
        }
        else if (mainm.Instance.boughtcrown == true && mainm.Instance.curacc != 6)
        {
            mainm.Instance.curacc = 6;
            ip.changeaccs();
        }
    }
}
