using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class song : MonoBehaviour
{
    AudioSource ad;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        ad = GetComponent<AudioSource>();

        if (!ad.isPlaying)
        {
            ad.Play();
        }
        else if (ad.isPlaying)
        {
            ;
        }
    }
}
