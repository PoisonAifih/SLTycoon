using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rusty : MonoBehaviour
{
    private carspawner cs;
    // Start is called before the first frame update
    void Start()
    {
        cs = FindObjectOfType<carspawner>();
        this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        this.gameObject.transform.Translate(0, 0, 1 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "boundrust")
        {
            cs.swn();
            Destroy(this.gameObject);
        }
    }
}
