using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float KarakterHiz;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float egim;
    float atesZamani = 0;
    public float atesGecenSure;
    public GameObject Kursun;
    public Transform KursunNeredenCiksin;
    AudioSource audio;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time>atesZamani){
            atesZamani = Time.time + atesGecenSure;
            Instantiate(Kursun, KursunNeredenCiksin.position,Quaternion.identity);   
            audio.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal"); //hareket etmesi için
        vertical= Input.GetAxis("Vertical");//hareket etmesi için
        vec = new Vector3(horizontal, 0, vertical);//hareket etmesi için

        fizik.velocity = vec*KarakterHiz; //hareket hizini arttırmak için

        fizik.position = new Vector3  //geminin sahnenin dışına çıkmamaması için gerekli kodlar
        (
            Mathf.Clamp(fizik.position.x, minX, maxX),
            0.0f,
            Mathf.Clamp(fizik.position.z, minZ, maxZ)
        );
        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x*-egim); //yukarıda bu değerleri public tanımladığımız için kendimiz girebiliyoruz oyunda
    }
}
