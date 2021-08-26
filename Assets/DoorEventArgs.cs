using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorEventArgs : EventArgs
{
    //private set yaptığımızda değiştirilemez oluyo
    public int id {get; private set;}
    public string name {get; private set;}
    public DateTime dateTime{get; set;}

    //dışarıdan erişmek istersek public yapmnalıyız
    public DoorEventArgs(int id, string name)
    {
        this.id = id;
        this.name = name;
        dateTime = DateTime.Now;
    }

}
