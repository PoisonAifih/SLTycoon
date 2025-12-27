using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeprefab : MonoBehaviour
{
    public float tr_speed;
    public Material[] mat;
    Renderer rend;

    
    //private ddr ddr;
    private job2_ui ju2;

    bool ispressed;


    bool lefttouch;
    bool righttouch;

    // Start is called before the first frame update
    void Start()
    {
        ju2 = FindObjectOfType<job2_ui>();
        //ddr = FindObjectOfType<ddr>();
        

        tr_speed =  ju2.tr_speed;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = mat[0];

        ispressed = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
        
        this.gameObject.transform.Translate(0, tr_speed * Time.deltaTime, 0);



        if (Input.GetKeyDown("z") && lefttouch == true)
        {
            ijo();
            Debug.Log("left down");
        }
        if (Input.GetKeyDown("x") && righttouch == true)
        {
            ijo();
            Debug.Log("right down");
        }
        /*
        if (Input.GetKeyUp("z"))
        {

            Debug.Log("left up");
        }
        if (Input.GetKeyUp("x"))
        {

            Debug.Log("right up");
        }*/
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "boundary" && ispressed == false)
        {
            Destroy(this.gameObject);
            Debug.Log("collided");
            ju2.miss += 1;
        }
        if (collision.gameObject.tag == "boundary")
        {
            Destroy(this.gameObject);

        }
        if (collision.gameObject.tag == "circle2" )
        {
            Debug.Log("left collide");
            lefttouch = true;

        }
        if (collision.gameObject.tag == "circle")
        {

            Debug.Log("right collide");
            righttouch = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        righttouch = false;
        lefttouch = false;
    }

    void ijo()
    {
        ispressed = true;
        ju2.pressed += 1;
        lefttouch = false;
        righttouch = false;
        
        var materialsCopy = rend.materials;
        materialsCopy[1] = mat[1];
        rend.materials = materialsCopy;
    }

    
}
