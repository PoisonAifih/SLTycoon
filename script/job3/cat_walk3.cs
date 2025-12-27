using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_walk3 : MonoBehaviour
{
    public float speed;

    private Transform target;
    public GameObject targetpos;
    public Transform cat1;
    public Transform cat2;

    public GameObject tai;
    public Transform catpos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-22.7f, 0.5f, -13.2f);
        speed = 1.5f;

        target = targetpos.transform;
        float randomposx = Random.Range(-22, 9);
        float randomposz = Random.Range(-13, 8);

        target.transform.position = new Vector3(randomposx, 0.5f, randomposz);


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {

            float randomposx = Random.Range(-22, 9);
            float randomposz = Random.Range(-13, 8);

            target.transform.position = new Vector3(randomposx, 0.5f, randomposz);
        }
        if (Vector3.Distance(transform.position, cat1.position) < 0.1f)
        {

            float randomposx = Random.Range(-22, 9);
            float randomposz = Random.Range(-13, 8);

            target.transform.position = new Vector3(randomposx, 0.5f, randomposz);
        }
        if (Vector3.Distance(transform.position, cat2.position) < 0.1f)
        {

            float randomposx = Random.Range(-22, 9);
            float randomposz = Random.Range(-13, 8);

            target.transform.position = new Vector3(randomposx, 0.5f, randomposz);
        }
    }

    public IEnumerator spawnpoop()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        Instantiate(tai, catpos.transform.position, Quaternion.Euler(-90, 0, 0));
        StartCoroutine(spawnpoop());
    }
}
