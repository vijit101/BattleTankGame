using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Bullet;

namespace Tanks.Tank
{
    public class TankService : MonoBehaviour
    {
        private void Start()
        {
            PlayerPrefs.SetFloat("Score", 0);
        }

        public TankView tankview;
        public BulletView bulletview;
        //public TankScriptableObject[] tankConfigurations;
        public TankScriptableObjectList tankScriptableObjectList;
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
                TankModel tankModel = new TankModel(tankScriptableObjectList.tanks[0]);
                CreateTank(tankModel);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TankModel tankModel = new TankModel(tankScriptableObjectList.tanks[1]);
                CreateTank(tankModel);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                TankModel tankModel = new TankModel(tankScriptableObjectList.tanks[2]);
                CreateTank(tankModel);
            }
        }

        public void FireBullet()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //fire bullet if type A B C 
            }
        }
        private void CreateTank(TankModel tankmodel)
        {
            TankController TController = new TankController(tankmodel, tankview);
        }
        private void CreateBullet(float Bspeed, float Dmg)
        {
            BulletModel bulletmodel = new BulletModel(BulletType.None,Bspeed, Dmg);
            BulletController BController = new BulletController(bulletmodel, bulletview);
        }
    }

}
