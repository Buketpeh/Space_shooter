using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuYonetim : MonoBehaviour
{
    public string oyun;

    public void SahneGecisOyun()
    {
        SceneManager.LoadScene(oyun);
    }
    public void OyundanCik()
    {
        Application.Quit();
    }
    
}
