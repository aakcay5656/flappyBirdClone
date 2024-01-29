using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

public class kontrol1 : MonoBehaviour
{
   public Sprite []kusSprite;
   SpriteRenderer spriteRenderer;
   int kusSayac = 0; 
   bool hareketKont = true;
   float time=0;
   int puan;

   Rigidbody2D fizik;

   

   bool oyunDurdur =false;

   OyunControl oyunkont;

   AudioSource []sesler;

 
    void Start()
    {
        oyunkont =GameObject.FindGameObjectWithTag("OyunKontrol").GetComponent<OyunControl>();   
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        sesler = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0) && !oyunDurdur)
      {
        fizik.velocity = new Vector2(0,0);
        
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


 
}
