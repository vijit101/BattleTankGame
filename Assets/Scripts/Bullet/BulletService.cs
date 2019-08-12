using UnityEngine;
using System.Collections;
using Tanks.Tank;

namespace Tanks.Bullet
{
    public class BulletService : MonoBehaviour
    {
        private TankView tankview;
        private TankType tankType;

        public BulletScriptableObjectList bulletScriptableObjectList;
        public BulletView bulletView;

        private void Update()
        {
            FireBullet();
        }
        private void FireBullet()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(tankview.Type == TankType.LowHealth)
                {
                    BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[0]);
                    BulletController bulletController = new BulletController(bulletModel, bulletView,tankview.transform.position);
                }
                if(tankview.Type == TankType.MediumHealth)
                {
                    BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[1]);
                    BulletController bulletController = new BulletController(bulletModel, bulletView, tankview.transform.position);
                }
                if (tankview.Type == TankType.MediumHealth)
                {
                    BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[1]);
                    BulletController bulletController = new BulletController(bulletModel, bulletView, tankview.transform.position);
                }
                tankview.IsFire = false;
            }
        }
        
    }
}

