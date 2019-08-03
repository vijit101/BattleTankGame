using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public TankModel(int Speed,int Health)
    {
        TnkSpeed = Speed;
        TnkHealth = Health;
    }

    public int TnkSpeed { get; private set; }
    public int TnkHealth { get; private set; }
}
