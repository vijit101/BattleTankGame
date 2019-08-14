using System.Collections;
using System.Collections.Generic;
using Tanks.Bullet;
using UnityEngine;

namespace Tanks.Tank
{
    public class TankController
    {
        public TankController(TankModel tankModel, TankView tankView,BulletService bulletService)
        {
            
            TankView = GameObject.Instantiate<TankView>(tankView);
            TankModel = tankModel;
            TankView.Speed = tankModel.Speed;
            TankView.Health = tankModel.Health;
            TankView.Type = tankModel.Type;
            BulletService = bulletService;
            bulletService.SetTankView(TankView);
        }
        public BulletService BulletService;
        public TankView TankView { get; set; }
        public TankModel TankModel { get; set; }

    }

}

