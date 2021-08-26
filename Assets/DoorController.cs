using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorController : MonoBehaviour
{
    public int id;
    public float moveSpeed=1;
    public bool isActivated; //kapıların aboneliğini düzenlemek için
    void Start()
    {
        //tüm kapılar başlangıçta kırmızı
        GetComponent<Renderer>().material.color = Color.red;
        if(isActivated)
        {
            //sadece isActivated true olanlar register oldu yani abone oldu
            Register();
        }
    }


    //abonelik tanımlanıyor
    private void Register()
    {
        //abone olundu
        GameEvents.instance.onDoorTriggerEnterAction += DoorOpened; //bu tanımlandığında doorclosed metoduna girer.
        GameEvents.instance.onDoorTriggerExitAction += DoorClosed;  

        //abone olan kapı yeşil oldu
        GetComponent<Renderer>().material.color = Color.green;
    }

    private void UnRegister()
    {
       //abonelik silindi 
        GameEvents.instance.onDoorTriggerEnterAction -= DoorOpened; 
        GameEvents.instance.onDoorTriggerExitAction -= DoorClosed; 
        GetComponent<Renderer>().material.color = Color.red;
    }


    //fareye basıldığında
    private void OnMouseDown()
    {
        if(isActivated)
        {
            //aktifse fareyle bastığımızda unregister yapacak
            UnRegister();
        }
        else
        {
            //değilse register yapsın
            Register();
        }
        //statein değiştiğini göstermek için
        isActivated = !isActivated;
    }

    private void DoorOpened(DoorEventArgs args)
    {
        Debug.Log("A trial by:" + args.name +"at "+ args.dateTime.ToShortTimeString() );

        if(this.id == args.id)
        {
            if (current != null)
            {   
                StopCoroutine(current);
            }
            current = OpenDoor();
            StartCoroutine(OpenDoor());
            Debug.Log(" " + args.name +"at "+ args.dateTime.ToShortTimeString() + " opened the door" );
        }


    }

    private void DoorClosed(DoorEventArgs args)
    {
        Debug.Log(" close A trial by:" + args.name +"at "+ args.dateTime.ToShortTimeString() );
        
        //kapıya ait olan i, triggerdan gelen idye eşitse kapıyı aç
        if(this.id == args.id)
        {
            //current null değilse demek ki çalışan bir rutin var
            if (current != null)
            {   
                //çalışan rutini durdur
                StopCoroutine(current);
            }
            current = CloseDoor();
            StartCoroutine(CloseDoor());

            Debug.Log(" " + args.name +"at "+ args.dateTime.ToShortTimeString() + " closed the door" );
        }


    } 

    IEnumerator current;


    //IEnumerator kullanıyoruz çünkü yavaşça yukarı çıkıp insin istiyoruz.
    IEnumerator OpenDoor()
    {
        //kapının konumu 1.50den küüçük olduğu sürece arttır.
        while(transform.localPosition.y <= 1.51f)
        {
            //sadece y değerini arttırdık
            transform.position += new Vector3(0,Time.deltaTime *moveSpeed,0);
            yield return null;
        }
    }
    
    IEnumerator CloseDoor()
    {
        //0.50den büyük olduğu sürece değeri sürekli azaltıcaz.
        while(transform.localPosition.y >= 0.50f)
        {
            transform.position -= new Vector3(0, Time.deltaTime * moveSpeed , 0);
            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
