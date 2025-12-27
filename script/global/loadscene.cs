using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadscene : MonoBehaviour
{
    public GameObject loadUI;
    public Slider loadbar;
    public float speed;

    //private static loadscene Instance;

    public void Awake()
    {
        /*
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        */

        loadUI.SetActive(false);

    }

    private void Start()
    {
        speed = 0.9f;

    }

    public void sceneload(int levelindex)
    {
        
        StartCoroutine(loadsceneprog(levelindex));

    }

    public IEnumerator loadsceneprog(int levelindex)
    {

        AsyncOperation op = SceneManager.LoadSceneAsync(levelindex);
        loadUI.SetActive(true);

        while (!op.isDone)
        {
            float progressvalue = Mathf.Clamp01(op.progress / speed);
            loadbar.value = progressvalue;
            yield return null;

            //mainm.Instance.opdone = false;


            if (op.progress >= 0.9f)
            {
                //mainm.Instance.opdone = true;

            }

        }
        if (op.progress >= 0.9f)
        {
            yield return new WaitForSeconds(1);
            //tip[tiprandom].gameObject.SetActive(false);
            loadUI.SetActive(false);
            //mainm.Instance.opdone = true;

        }
        yield return null;
    }
}

