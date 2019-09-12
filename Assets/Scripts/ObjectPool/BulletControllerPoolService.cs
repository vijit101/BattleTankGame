using System.Collections;
using System.Collections.Generic;
using Tanks.Bullet;
using Tanks.utils;
using UnityEngine;

namespace Tanks.ObjectPool
{
    public class BulletControllerPoolService : ObjectPoolGeneric<BulletController>
    {
        private BulletModel bulletModel;
        private BulletView bulletView;
        public BulletController GetBulletController(BulletModel model, BulletView view)
        {
            this.bulletModel = model;
            this.bulletView = view;
            return GetPoolItem();
        }

        protected override BulletController CreateItem()
        {
            BulletController bulletcontroller = new BulletController(bulletModel, bulletView);
            return bulletcontroller;
        }
    }
}

