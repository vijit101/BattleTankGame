using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletController
    {

        public BulletController(BulletModel BMdl, BulletView BView)
        {
            Bullet_View = GameObject.Instantiate<BulletView>(BView);
            Bullet_Model = BMdl;
            Bullet_View.BSpeed = BMdl.Speed;
        }

        public BulletModel Bullet_Model { get; set; }
        public BulletView Bullet_View { get; set; }
    }

}

