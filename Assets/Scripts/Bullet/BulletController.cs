using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletController
    {

        public BulletController(BulletModel bulletModel, BulletView bulletView,Transform TankViewTransform)
        {
            Vector3 Bulletpos = TankViewTransform.position.SetY(.2f);
            BulletView = GameObject.Instantiate<BulletView>(bulletView, Bulletpos, TankViewTransform.rotation);
            BulletModel = bulletModel;
            BulletView.Speed = bulletModel.Speed;
            //BulletView.damage = bullet
            BulletView.bulletType = BulletModel.Type;
        }

        public BulletModel BulletModel { get; set; }
        public BulletView BulletView { get; set; }
    }

}

