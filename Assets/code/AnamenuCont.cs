using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnamenuCont : MonoBehaviour
{
    public GameObject gokyuzu1;
    public GameObject gokyuzu2;

    Rigidbody2D f1;
    Rigidbody2D f2;
    float uzunluk;

    public float arkaplnhiz = -1.5f;

    public GameObject engel;
    public int kacAdetEngel=5;

    GameObject []engeller;
   float degisimZamani; 
    bool OyunBitti=true;
   int sayac=0;

   public Text Score;
    void Start()
    {

    int enyuksekpuan = PlayerPrefs.GetInt("kayit");

    Score.text = "Score:"+enyuksekpuan;
     
     f1 = gokyuzu1.GetComponent<Rigidbody2D>();   
     f2 = gokyuzu2.GetComponent<Rigidbody2D>();

     f1.velocity = new Vector2(arkaplnhiz,0);
     f2.velocity = new Vector2(arkaplnhiz,0);
     

    uzunluk = gokyuzu1.GetComponent<BoxCollider2D>().size.x;

    engeller = new GameObject[kacAdetEngel];

    for (int i = 0; i < engeller.Length; i++)
    {
        engeller[i] = Instantiate(engel,new Vector2(-20,-20),Quaternion.identity);
        Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
        fizikEngel.gravityScale=0;
        fizikEngel.velocity = new Vector2(arkaplnhiz,0);   
    }

    }

    // Update is called once per frame
    void Update()
    {
        if(OyunBitti){
        
        if (gokyuzu1.transform.position.x <= -uzunluk)
        {
         gokyuzu1.transform.position += new Vector3(uzunluk*2,0);   
        }


        if (gokyuzu2.transform.position.x <= -uzunluk)
        {
         gokyuzu2.transform.position += new Vector3(uzunluk*2,0);   
        }

        //-----------------------------------------------------------------

        degisimZamani += Time.deltaTime;

        if(degisimZamani>5f){
            degisimZamani=0;
            float Yeksenim = Random.Range(-0.50f,1.10f);
            engeller[sayac].transform.position = new Vector3(18,Yeksenim);
            sayac++;

            if (sayac>=engeller.Length)
            {
             sayac=0;   
            }
        }
        
        }
        

    }

    public void OyunuGit(){
        SceneManager.LoadScene(0);
    }

    public void OyundanCik(){
        Application.Quit();
    }

   
}
