using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletController
    {

        public BulletController(BulletModel bulletModel, BulletView bulletView)
        {
            BulletView = GameObject.Instantiate<BulletView>(bulletView);
            BulletModel = bulletModel;
            BulletView.Speed = bulletModel.Speed;
            //BulletView.damage = bullet
            BulletView.bulletType = BulletModel.Type;
        }

        public BulletModel BulletModel { get; set; }
        public BulletView BulletView { get; set; }
    }

}

