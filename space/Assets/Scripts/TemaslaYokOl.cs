using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOl : MonoBehaviour
{
    public GameObject patlama;
    public GameObject playerpatlama;
    GameObject OyunKontrol;
    OyunKontrol kontrol;
    void Start()
    {
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol");//oyun kontrol ün olduğu objeye ulaştım
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();// bu objenin içinde olan scripte ulaşmak için oyun kontrol objesinden componentini oluşturdum.

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag!= "Sinir")
        { 
        Destroy(col.gameObject);
        Destroy(gameObject);
        Instantiate(patlama, transform.position, transform.rotation);
            kontrol.ScoreArttir(10);
        }
        if (col.tag == "Player")
        {
            Instantiate(playerpatlama,col.transform.position, col.transform.rotation);
            kontrol.oyunBitti ();
        }
    }
}
