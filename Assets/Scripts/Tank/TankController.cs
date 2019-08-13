using System.Collections;
using System.Collections.Generic;
using Tanks.Bullet;
using UnityEngine;

namespace Tanks.Tank
{
    public class TankController
    {
        public TankController(TankModel tankModel, TankView tankView)
        {
            TankView = GameObject.Instantiate<TankView>(tankView);
            TankModel = tankModel;
            TankView.Speed = tankModel.Speed;
            TankView.Health = tankModel.Health;
            TankView.Type = tankModel.Type;
            BulletService = new BulletService(TankView);
            
        }
        public BulletService BulletService { get; set; }
        public TankView TankView { get; set; }
        public TankModel TankModel { get; set; }
    }

}

