using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawner : MonoBehaviour
{
    public GameObject rustycar;
    public GameObject elecar;
    public Transform rustypos;
    public Transform elepos;
    public GameObject repairanim;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        time = 3f;
        spawnrust();
        repairanim.SetActive(false);
    } 

    public void spawnrust()
    {
        Instantiate(rustycar, rustypos.position, Quaternion.identity);
    }

    public void swn()
    {
        StartCoroutine(spawnele());
    }
    public IEnumerator spawnele()
    {
        repairanim.SetActive(true);
        yield return new WaitForSeconds(time);
        repairanim.SetActive(false);
        Instantiate(elecar, elepos.position, Quaternion.identity);
        yield return null;
        
    }
}
