using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddr : MonoBehaviour
{
    public GameObject tree;
    public Transform[] waypoints;

    public float speed;
   // private roadmove rm;
    //private spawnroad sr;

    // Start is called before the first frame update
    void Start()
    {
        //rm = FindObjectOfType<roadmove>();
        //sr = FindObjectOfType<spawnroad>();
        speed = 5;

    }


    public IEnumerator spawntree()
    {
        
        int randomwaypoint = Random.Range(0, 2);
        Instantiate(tree, waypoints[randomwaypoint].position, Quaternion.identity);

        yield return new WaitForSeconds(speed);
        StartCoroutine(spawntree());
    }

    public IEnumerator speedplus()
    {
        if(speed >= 3.4f)
        {
            yield return new WaitForSeconds(5);
            speed -= .2f;
            //rm.movespeed += reduce;
            //sr.delay -= .001f;
            StartCoroutine(speedplus());
        }
        else
        {
            speed = 3.2f;
        }
        
    }
}
