using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ele : MonoBehaviour
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
        
        this.gameObject.transform.Translate(0, 0, 2 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "boundele")
        {
            cs.spawnrust();
            Destroy(this.gameObject);
            
        }
    }
}
