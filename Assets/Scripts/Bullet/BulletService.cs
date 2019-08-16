using UnityEngine;
using System.Collections;
using Tanks.Tank;

namespace Tanks.Bullet
{
    public class BulletService : MonoBehaviour
    {
        private static BulletService instance;
        public BulletService Instance { get { return instance; } }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        public BulletService(TankView tankView)
        {
            tankview = tankView;
        }
        public void SetTankView(TankView tank)
        {
            tankview = tank;
        }
        private TankType tankType;

        public BulletScriptableObjectList bulletScriptableObjectList;
        public BulletView bulletView;

        public TankView tankview { get; private set; }

        private void Update()
        {
            SpawnBullet();
        }
        private void SpawnBullet()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(tankview.Type == TankType.LowHealth)
                {
                    BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[0]);
                    BulletController bulletController = new BulletController(bulletModel, bulletView,tankview.transform);
                }
                if(tankview.Type == TankType.MediumHealth)
                {
                    BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[1]);
                    BulletController bulletController = new BulletController(bulletModel, bulletView, tankview.transform);
                }
                if (tankview.Type == TankType.HeavyHealth)
                {
                    BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[2]);
                    BulletController bulletController = new BulletController(bulletModel, bulletView, tankview.transform);
                }
            }
        }
        
    }
}

