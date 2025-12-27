using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnroad : MonoBehaviour
{
    public GameObject road;
    public bool create = false;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        delay = 2.5f;
    }

    public IEnumerator Genroad()
    {
        Instantiate(road, this.gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        StartCoroutine(Genroad());
    }
}
