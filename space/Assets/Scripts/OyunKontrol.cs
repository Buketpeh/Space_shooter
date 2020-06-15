using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OyunKontrol : MonoBehaviour
{
    // oyun açıldığında astroid metodu oluşucak
    public GameObject Astereoid;
    public Vector3 randomPos;
    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;
    public Text text;
    public Text oyunBittiText;
    public Text yenidenBaslaText;
    bool oyunBittiKontrol = false;
    bool yenidenBaslaKontrol = false;

    int score;
    void Start()
    {
        score = 0;
        text.text = "score =" + score;
       StartCoroutine(olustur());
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && yenidenBaslaKontrol)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    IEnumerator olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);//oyun başladıktan 2 sn sonra çalışması için
        while (true) { //süreklitaş gelmesi için 
        for (int i = 0; i < 10; i++) { 
        Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x),0,randomPos.z);
        Instantiate(Astereoid,vec, Quaternion.identity);//gameobject,pozisyon,
            yield return new WaitForSeconds(olusturmaBekleme); //1 saniyede bir oluşturmak için
                               }
          
            if (oyunBittiKontrol)
            {
                yenidenBaslaText.text = "Yeniden başlamak için R tuşuna basınız.";
                yenidenBaslaKontrol = true;
                break;
            }

            yield return new WaitForSeconds(donguBekleme);// döngü tamamlandıktan sonra 5 sn ara
        }
    }

    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        text.text = "score =" + score;
        Debug.Log(score);
    }
    public void oyunBitti()
    {
        oyunBittiText.text = "OYUN BİTTİ";
        oyunBittiKontrol = true;
    }

  
}
