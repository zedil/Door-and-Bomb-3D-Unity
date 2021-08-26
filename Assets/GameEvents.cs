using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{

    //event tanımlama, System kütüphanesni kullanır
    public Action<DoorEventArgs> onDoorTriggerEnterAction;
    public Action<DoorEventArgs> onDoorTriggerExitAction; //bu olaylara birilerinin abone olması gerekir
    

    public static GameEvents instance;
    void Start()
    {
        instance = this;
    }

    public void DoorTriggerEnterHandler(DoorEventArgs args)
    {
        //olaya abone olan varsa bu olayı gerçekleştir
        //ifadenin daha basit yazılmış hali => onDoorTriggerEnterAction?.Invoke()
        if(onDoorTriggerEnterAction != null) //olaya biri abone mi bakıldı
        {
            onDoorTriggerEnterAction(args);
        }

        
    }
    public void DoorTriggerExitHandler(DoorEventArgs args)
    {
        //? işareti null mı değil mi bakıyor.
        onDoorTriggerExitAction?.Invoke(args);
        
    }

}
