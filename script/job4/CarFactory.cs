using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFactory : MonoBehaviour
{
    public static CarFactory Instance;

    public int waktumobil;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator Carinc()
    {
        Debug.Log("carinc called");
        if (waktumobil > 0)
        {
            Debug.Log(waktumobil);
            waktumobil -= 1;
            yield return new WaitForSeconds(1);
            StartCoroutine(Carinc());
        }
        else if (waktumobil == 0)
        {
            plusmoney();
        }
       
    }
       
    void plusmoney()
    {
        Debug.Log("plus money car factory");
        mainm.Instance.moneyonhold += mainm.Instance.pay4;
        waktumobil = 60;
        StartCoroutine(Carinc());
        Debug.Log("start carinc");
    }
}
