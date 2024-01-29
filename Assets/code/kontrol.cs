using System;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

public class kontrol : MonoBehaviour
{
   public Sprite []kusSprite;
   SpriteRenderer spriteRenderer;
   int kusSayac = 0; 
   bool hareketKont = true;
   float time=0;
   int puan;
   int enyuksekpuan;
   Rigidbody2D fizik;

   public Text puanT;

   bool oyunDurdur =false;

   OyunControl oyunkont;

   AudioSource []sesler;

 
    void Start()
    {
        oyunkont =GameObject.FindGameObjectWithTag("OyunKontrol").GetComponent<OyunControl>();   
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        sesler = GetComponents<AudioSource>();
        enyuksekpuan = PlayerPrefs.GetInt ("kayit");

         Debug.Log(enyuksekpuan);
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0) && !oyunDurdur)
      {
        fizik.velocity = new Vector2(0,0);
        fizik.AddForce(new Vector2(0,200));    
        sesler[0].Play();
        
      }
      if(fizik.velocity.y>0){
        transform.eulerAngles = new Vector3(0,0,30);
      }
      if (fizik.velocity.y<0)
      {
        transform.eulerAngles = new Vector3(0,0,-30);
      }
      animasyon();
       
    }
public void animasyon(){
    time+=Time.deltaTime;
        if (time>0.1f)
        {
           if (hareketKont)
        {
            spriteRenderer.sprite = kusSprite[kusSayac];
            kusSayac++;
            if (kusSayac==kusSprite.Length)
            {
                kusSayac--;
                hareketKont=false;
            }
        }
        else
        {
            kusSayac--;
            spriteRenderer.sprite = kusSprite[kusSayac];
            if (kusSayac==0)
            {
                kusSayac++;
                hareketKont=true;
            }
        }    

         time=0;   
        }
}
/*
    public IEnumerator  a(){
        
     
      spriteRenderer.sprite = kusSprite[0];
      yield return new WaitForSecondsRealtime(3f);
      spriteRenderer.sprite = kusSprite[1];

      yield return new WaitForSecondsRealtime(3f);
      spriteRenderer.sprite = kusSprite[2];

       yield return new WaitForSecondsRealtime(3f);
      spriteRenderer.sprite = kusSprite[1];



    }

    IEnumerator wait(float waitTime)
{
    float counter = 0;

    while (counter < waitTime)
    {
        //Increment Timer until counter >= waitTime
        counter += Time.deltaTime;
     
       
        //Wait for a frame so that Unity doesn't freeze
        yield return null;
    }
}
*/


 void OnTriggerEnter2D(Collider2D other)
{
  if (other.gameObject.tag=="Puan")
  {
      sesler[2].Play();
      puan++;
      puanT.text = "Score:"+puan;
    }

  if (other.gameObject.tag=="Engel")
  {
    oyunDurdur=true;
    if (puan>enyuksekpuan)
    {
      PlayerPrefs.SetInt("kayit",puan); 
    }
    
    oyunkont.oyunBitti();
  
    sesler[1].Play();
    GetComponent<CircleCollider2D>().enabled = false;

    
  }  
}
}
