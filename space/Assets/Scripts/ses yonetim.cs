using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesyonetim : MonoBehaviour
{

    void Start()
    {
        muzik = GetComponent<AudioSource>;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            sesaac();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            seskapa();
        }
    }
    void sesac()
    {
        muzik.mute = false;

    }
    void seskpa()
    {
        muzik.mute = true;
    }

}
