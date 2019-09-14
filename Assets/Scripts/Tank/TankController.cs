﻿using Tanks.Bullet;
using Tanks.ObjectPool;
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
            TankView.InitializeController(this);            
            //BulletService = bulletService;
            //bulletService.SetTankView(TankView);
        }
        //public BulletService BulletService;
        public TankView TankView { get; set; }
        public TankModel TankModel { get; set; }

        public void FireBullet()
        {
            BulletController bulletController = BulletService.Instance.GetBullet(TankModel.Type);
            Vector3 Bulletpos = TankView.transform.position;
            Bulletpos = Bulletpos.SetY(.2f);
            bulletController.SetPosition(Bulletpos,TankView.transform.rotation);
        }
        public void ApplyDamage(float damage)
        {
            if (TankModel.Health - damage <= 0)
            {
                //EventService.Instance.OnDeath += DeathEvent;
                TankControllerPoolService.Instance.ReturnPooledObject(this);
                this.TankView.gameObject.SetActive(false);
            }
            else
            {
                TankModel.Health = TankModel.Health-damage;
            }
        }
        public void SetModelToView(TankView tank)
        {
            tank.Speed = TankModel.Speed;
            tank.Health = TankModel.Health;
        }
        //public void DeathEvent()
        //{
        //    Debug.Log("Enemy player Dead");
        //}

    }

}

