using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainm : MonoBehaviour, IdataPersistence
{
    public static mainm Instance { get; private set; }
    private FileDataHandler dataHandler;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, DataPersistenceManager.Instance.fileName);
    }

    public bool startplay;

    public int money;

    public int pay1;
    public int pay2;
    public int pay3;
    public int pay4;

    public int upjob1;
    public int upjob2;
    public int upjob3;
    public int upjob4;

    public int lvljob1;
    public int lvljob2;
    public int lvljob3;
    public int lvljob4;

    public bool boughtjob4;

    public int curhouse;
    public bool boughthouse2;
    public bool boughthouse3;
    public bool boughthouse4;

    public bool boughtsolar;
    public bool boughtwindturb;

    public int upwindturb;
    public int upsolar;

    public int lvlwindturb;
    public int lvlsolar;

    public float reducesolar;
    public float reducewind;

    public int day;
    public int daycycle;

    public float tax1;
    public float tax2;
    public float tax3;
    public float tax4;

    public bool paytax;

    public bool boughtbow;
    public bool boughtglasses;
    public bool boughtwings;
    public bool boughthat1;
    public bool boughthat2;
    public bool boughtcrown;

    public int curacc;
    public int moneyonhold;

    public bool carfactoryrunning;

    private void Start()
    {
        carfactoryrunning = false;
    }

    public void SaveData(ref GameData data)
    {
        data.money = this.money;

        data.pay1 = this.pay1;
        data.pay2 = this.pay2;
        data.pay3 = this.pay3;
        data.pay4 = this.pay4;

        data.curhouse = this.curhouse;

        data.lvlsolar = this.lvlsolar;
        data.lvlwindturb = this.lvlwindturb;

        data.upwindturb = this.upwindturb;
        data.upsolar = this.upsolar;

        data.reducesolar = this.reducesolar;
        data.reducewind = this.reducewind;

        data.upjob1 = this.upjob1;
        data.upjob2 = this.upjob2;
        data.upjob3 = this.upjob3;
        data.upjob4 = this.upjob4;

        data.lvljob1 = this.lvljob1;
        data.lvljob2 = this.lvljob2;
        data.lvljob3 = this.lvljob3;
        data.lvljob4 = this.lvljob4;

        data.tax1 = this.tax1;
        data.tax2 = this.tax2;
        data.tax3 = this.tax3;
        data.tax4 = this.tax4;

        data.day = this.day;
        data.daycycle = this.daycycle;

        data.startplay = this.startplay;
        data.paytax = this.paytax;

        data.curacc = this.curacc;

        data.boughtbow = this.boughtbow;
        data.boughtcrown = this.boughtcrown;
        data.boughtglasses = this.boughtglasses;
        data.boughthat1 = this.boughthat1;
        data.boughthat2 = this.boughthat2;
        data.boughtwings = this.boughtwings;

        data.boughthouse2 = this.boughthouse2;
        data.boughthouse3 = this.boughthouse3;
        data.boughthouse4 = this.boughthouse4;

        data.boughtsolar = this.boughtsolar;
        data.boughtwindturb = this.boughtwindturb;

        data.boughtjob4 = this.boughtjob4;
        data.moneyonhold = this.moneyonhold;
    }

    public void LoadData(GameData data)
    {
        this.money = data.money;

        this.pay1 = data.pay1;
        this.pay2 = data.pay2;
        this.pay3 = data.pay3;
        this.pay4 = data.pay4;

        this.curhouse = data.curhouse;

        this.lvlsolar = data.lvlsolar;
        this.lvlwindturb = data.lvlwindturb;

        this.upwindturb = data.upwindturb;
        this.upsolar = data.upsolar;

        this.reducesolar = data.reducesolar;
        this.reducewind = data.reducewind;

        this.upjob1 = data.upjob1;
        this.upjob2 = data.upjob2;
        this.upjob3 = data.upjob3;
        this.upjob4 = data.upjob4;

        this.lvljob1 = data.lvljob1;
        this.lvljob2 = data.lvljob2;
        this.lvljob3 = data.lvljob3;
        this.lvljob4 = data.lvljob4;

        this.tax1 = data.tax1;
        this.tax2 = data.tax2;
        this.tax3 = data.tax3;
        this.tax4 = data.tax4;

        this.day = data.day;
        this.daycycle = data.daycycle;

        this.startplay = data.startplay;
        this.paytax = data.paytax;

        this.curacc = data.curacc;

        this.boughtbow = data.boughtbow;
        this.boughtcrown = data.boughtcrown;
        this.boughtglasses = data.boughtglasses;
        this.boughthat1 = data.boughthat1;
        this.boughthat2 = data.boughthat2;
        this.boughtwings = data.boughtwings;

        this.boughthouse2 = data.boughthouse2;
        this.boughthouse3 = data.boughthouse3;
        this.boughthouse4 = data.boughthouse4;

        this.boughtsolar = data.boughtsolar;
        this.boughtwindturb = data.boughtwindturb;

        this.boughtjob4 = data.boughtjob4;
        this.moneyonhold = data.moneyonhold;
    }
}
