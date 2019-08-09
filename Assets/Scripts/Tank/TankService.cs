using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Bullet;

namespace Tanks.Tank
{
    public class TankService : MonoBehaviour
    {

        public TankView tankview;
        public BulletView bulletview;
        // Use this for initialization

        private void Update()
        {
            SpawnTank();
            FireBullet();
        }

        private void SpawnTank()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CreateTank(500, 1000);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CreateTank(1000, 500);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CreateTank(700, 700);
            }
        }

        public void FireBullet()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //fire bullet if type A B C 
            }
        }
        private void CreateTank(int tankspeed, int tankhealth)
        {
            TankModel tankmodel = new TankModel(tankspeed, tankhealth);
            TankController TController = new TankController(tankmodel, tankview);
        }
        private void CreateBullet(float Bspeed, float Dmg)
        {
            BulletModel bulletmodel = new BulletModel(Bspeed, Dmg);
            BulletController BController = new BulletController(bulletmodel, bulletview);
        }
    }

}
