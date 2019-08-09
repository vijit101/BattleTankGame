using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Tank
{
    public class TankController
    {
        public TankController(TankModel tankmodel, TankView tankView)
        {

            TankView = GameObject.Instantiate<TankView>(tankView);
            TankModel = tankmodel;
            TankView.Speed = tankmodel.Speed;
            TankView.Health = tankmodel.Health;
        }

        public TankView TankView { get; set; }
        public TankModel TankModel { get; set; }
    }

}

