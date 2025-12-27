using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucket : MonoBehaviour
{
    public GameObject[] tong;
    public GameObject[] items;
    public GameObject[] rw;

    public int pressed;
    public bool ispressed;
    public int itemselect;
    public bool itemspawn;

    private job1_ui yuai;

    // Start is called before the first frame update
    void Start()
    {
        yuai = FindObjectOfType<job1_ui>();

        for (int i = 0; i < 9; i++)
        {
            items[i].SetActive(false);
        }
        for (int i = 0; i < 2; i++)
        {
           rw[i].SetActive(false);
        }


        ispressed = false;
        itemspawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") && ispressed == false && yuai.waktu > 0 && yuai.pausepressed == false)
        {
            Debug.Log("plas_bucket pressed");
            pressed = 0;
            StartCoroutine(pencet());
        }
        if (Input.GetKeyDown("x") && ispressed == false && yuai.waktu > 0 && yuai.pausepressed == false)
        {
            Debug.Log("paper_bucket pressed");
            pressed = 1;
            StartCoroutine(pencet());
        }
        if (Input.GetKeyDown("c") && ispressed == false && yuai.waktu > 0 && yuai.pausepressed == false)
        {
            Debug.Log("leaf_bucket pressed");
            pressed = 2;
            StartCoroutine(pencet());
        }

        if(itemspawn == false)
        {
            itemselect = Random.Range(0, 9);
            items[itemselect].SetActive(true);
            itemspawn = true;

        }
        
        if(ispressed == false)
        {
            for (int i = 0; i < 2; i++)
            {
                rw[i].SetActive(false);
            }
        }

    }

    IEnumerator pencet()
    {
        ispressed = true;
        tong[pressed].transform.Rotate(0, 0, -20, Space.Self);
        if (itemselect == pressed && ispressed == true)
        {
            Debug.Log("right");
            rw[0].SetActive(true);
            yuai.bnr += 1;
        }
        else if (itemselect == pressed + 3 && ispressed == true)
        {
            Debug.Log("right");
            rw[0].SetActive(true);
            yuai.bnr += 1;
        }
        else if (itemselect == pressed + 6 && ispressed == true)
        {
            Debug.Log("right");
            rw[0].SetActive(true);
            yuai.bnr += 1;
        }
        else
        {
            Debug.Log("wrong");
            rw[1].SetActive(true);
            yuai.slh += 1;
        }

        for (int i = 0; i < 9; i++)
        {
            items[i].SetActive(false);
        }
        yield return new WaitForSeconds(.1f);
        tong[pressed].transform.Rotate(0, 0, 20, Space.Self);
        for (int i = 0; i < 2; i++)
        {
            rw[i].SetActive(false);
        }

        ispressed = false;
        itemspawn = false;
    }

}

