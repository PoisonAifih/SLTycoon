using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
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

    public GameData()
    {
        money = 0;

        pay1 = 5;
        pay2 = 10;
        pay3 = 5;
        pay4 = 20;

        curhouse = 0;

        lvlsolar = 1;
        lvlwindturb = 1;

        upwindturb = 42000;
        upsolar = 15000;

        reducesolar = 0;
        reducewind = 0;

        upjob1 = 500;
        upjob2 = 1000;
        upjob3 = 500;
        upjob4 = 30000;

        lvljob1 = 1;
        lvljob2 = 1;
        lvljob3 = 1;
        lvljob4 = 1;

        tax1 = 13;
        tax2 = 20;
        tax3 = 29;
        tax4 = 40;

        day = 1;
        daycycle = 0;

        startplay = true;
        paytax = false;

        curacc = 0;

        boughtbow = false;
        boughtcrown = false;
        boughtglasses = false;
        boughthat1 = false;
        boughthat2 = false;
        boughtwings = false;

        boughthouse2 = false;
        boughthouse3 = false;
        boughthouse4 = false;

        boughtsolar = false;
        boughtwindturb = false;

        boughtjob4 = false;
    }
}
