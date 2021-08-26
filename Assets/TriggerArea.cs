using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;

    //kapıya çarpıp çarpmadığına bu şekilde bakıyoruz.
    private void OnTriggerEnter(Collider other)
    {
        //id gönderiyoruz çünkü hangi kapının açılacağını kontrol etsin
        DoorEventArgs args = new DoorEventArgs(id, other.name);
        GameEvents.instance.DoorTriggerEnterHandler(args); //tanımlanan gameevent burada çağırıldı
    }

    private void OnTriggerExit(Collider other)
    {
        //id gönderiyoruz çünkü hangi kapının kapanacağını kontrol etsin
        DoorEventArgs args = new DoorEventArgs(id, other.name);
        GameEvents.instance.DoorTriggerExitHandler(args); //tanımlanan gameevent burada çağırıldı
    }
}