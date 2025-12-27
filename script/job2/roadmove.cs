using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadmove : MonoBehaviour
{
    public float movespeed;

    private job2_ui ju2;
    // Start is called before the first frame update
    void Start()
    {
        movespeed = 3f;

        ju2 = FindObjectOfType<job2_ui>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ju2.isstart == true)
        {
            transform.position -= new Vector3(0, 0, movespeed * Time.deltaTime);
        }
        else
        {
            ;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "boundary")
        {
            Destroy(this.gameObject);
        }
    }

}
