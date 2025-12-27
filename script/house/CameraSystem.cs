using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cmvc;

    private bool isrotatingright;
    private bool isrotatingleft;
    public float currentzoom;

    public float curz;
    public float curx;

    private bool maju;
    private bool mundur;
    private bool kiri;
    private bool kanan;

    public Slider speed;
    public Slider zoom;

    float rotatespeed;
    float zoomamount;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("zoomAmount"))
        {
            PlayerPrefs.SetFloat("zoomAmount", 1);
            Loadzoom();
        }
        else
        {
            Loadzoom();
        }
        if (!PlayerPrefs.HasKey("rotationSpeed"))
        {
            PlayerPrefs.SetFloat("rotationSpeed", 10);
            Loadspeed();
        }
        else
        {
            Loadspeed();
        }
    }

    private void Update()
    {
        //move
        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKeyDown("t")) maju = true;
        else if (Input.GetKeyUp("t")) maju = false;
        if (Input.GetKeyDown("g")) mundur = true;
        else if (Input.GetKeyUp("g")) mundur = false;
        if (Input.GetKeyDown("f")) kiri = true;
        else if (Input.GetKeyUp("f")) kiri = false;
        if (Input.GetKeyDown("h")) kanan = true;
        else if (Input.GetKeyUp("h")) kanan = false;

        if(curz < 200)
        {
            if (maju == true)
            {
                moveDir.z += 1f;
                curz += 1f;
            }
        }
        if(curz > -50)
        {
            if (mundur == true)
            {
                moveDir.z -= 1f;
                curz -= 1f;
            }
        }
        
        if(curx < 100)
        {
            if (kiri == true)
            {
                moveDir.x -= 1f;
                curx += 1f;
            }
        }
        if(curx > -100)
        {
            if (kanan == true)
            {
                moveDir.x += 1f;
                curx -= 1f;
            }
        }
        

        float moveSpeed = 10f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        //rotate
        float rotateDir = 0f;

        if (Input.GetKeyDown("r")) isrotatingleft = true;
        else if (Input.GetKeyUp("r")) isrotatingleft = false;
        if (Input.GetKeyDown("y")) isrotatingright = true;
        else if (Input.GetKeyUp("y")) isrotatingright = false;

        if (isrotatingright == true)
        {
            Debug.Log("rotate r");
            rotateDir -= 1f;
        }
        if (isrotatingleft == true)
        {
            Debug.Log("rotate y");
            rotateDir += 1f;
        }

        
        transform.eulerAngles += new Vector3(0, rotateDir * rotatespeed * Time.deltaTime, 0);

        //zoom
        
        HandleCameraZoom(zoomamount);
    }

    private void HandleCameraZoom(float zmount)
    {
        
        if (Input.mouseScrollDelta.y > 0 && currentzoom > -45)
        {
            cmvc.m_Lens.FieldOfView -= zmount;
            currentzoom -= zmount;
        }
        if (Input.mouseScrollDelta.y < 0 && currentzoom < 50)
        {
            cmvc.m_Lens.FieldOfView += zmount;
            currentzoom += zmount;
        }
    }

    public void changezoom()
    {
        zoomamount = zoom.value;
        savezoom();
    }
    public void changerotate()
    {
        rotatespeed = speed.value;
        savespeed();
    }

    private void Loadzoom()
    {
        zoom.value = PlayerPrefs.GetFloat("zoomAmount");
        
    }

    private void Loadspeed()
    {
        speed.value = PlayerPrefs.GetFloat("rotationSpeed");
    }

    private void savezoom()
    {
        PlayerPrefs.SetFloat("zoomAmount", zoom.value);
    }
    private void savespeed()
    {
        
        PlayerPrefs.SetFloat("rotationSpeed", speed.value);
    }

}
