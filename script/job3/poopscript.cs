using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poopscript : MonoBehaviour
{
    private job3_ui ju3;
    // Start is called before the first frame update
    void Start()
    {
        ju3 = FindObjectOfType<job3_ui>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            Debug.Log("poop");
            ju3.poopcollect += 1;
            Destroy(this.gameObject);
        }
    }
}
