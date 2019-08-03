using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankController(TankModel TnkMdl , TankView TnkView)
    {

        Tank_View = GameObject.Instantiate<TankView>(TnkView);
        Tank_Model = TnkMdl;
        Tank_View.Spd = TnkMdl.TnkSpeed;
        Tank_View.health = TnkMdl.TnkHealth;
    }

    public TankView Tank_View { get; set; }
    public TankModel Tank_Model { get; set; }
}
