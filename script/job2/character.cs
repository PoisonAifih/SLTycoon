using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public ParticleSystem woter;

    // Start is called before the first frame update
    void Start()
    {
        woter.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
            woter.Play();
        }
        if (Input.GetKeyDown("x"))
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            woter.Play();
        }
        if (Input.GetKeyUp("z"))
        {
            woter.Stop();
        }
        if (Input.GetKeyUp("x"))
        {
            woter.Stop();
        }
    }
}
