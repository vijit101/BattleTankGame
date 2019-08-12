using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletController
    {

        public BulletController(BulletModel bulletModel, BulletView bulletView,Vector3 BulletPosition)
        {
            BulletPosition.SetY(.15f);
            BulletView = GameObject.Instantiate<BulletView>(bulletView,BulletPosition,Quaternion.identity);
            BulletModel = bulletModel;
            BulletView.Speed = bulletModel.Speed;
            //BulletView.damage = bullet
            BulletView.bulletType = BulletModel.Type;
        }

        public BulletModel BulletModel { get; set; }
        public BulletView BulletView { get; set; }
    }

}

