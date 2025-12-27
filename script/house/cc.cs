using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cc : MonoBehaviour
{
    public float speed = 2f;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //run
        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);
        float horizonalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");

        //arah
        Vector3 movedir = new Vector3(horizonalinput, 0, verticalinput);
        movedir.Normalize();

        transform.Translate(movedir * speed * Time.deltaTime, Space.World);

        if (movedir != Vector3.zero)
        {
            anim.SetBool("isawalk", true);
            transform.forward = movedir;
        }
        else
        {
            anim.SetBool("isawalk", false);
        }
    }

}
