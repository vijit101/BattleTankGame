using UnityEngine;
using Tanks.Tank;

namespace Tanks.Bullet
{
    public class BulletService : Singletongeneric<BulletService>
    {
        
        protected override void Awake()
        {
            base.Awake();
        }
       
        private TankType tankType,ViewType;        
        public BulletScriptableObjectList bulletScriptableObjectList;
        public BulletView bulletView;

        public TankView tankview { get; private set; }
        public BulletController GetBullet(TankType tankType)
        {
            if (tankType == TankType.LowHealth)
            {
                BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[0]);
                BulletController bulletController = new BulletController(bulletModel, bulletView);
                return bulletController;
            }
            if (tankType == TankType.MediumHealth)
            {
                BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[1]);
                BulletController bulletController = new BulletController(bulletModel, bulletView);
                return bulletController;
            }
            if (tankType == TankType.HeavyHealth)
            {
                BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[2]);
                BulletController bulletController = new BulletController(bulletModel, bulletView);
                return bulletController;
            }
            return null;
        }
        //public void SetBulletPosition(Transform Tanktransform)
        //{
        //    Vector3 Bulletpos = Tanktransform.position.SetY(.2f);
        //    transform.position = Bulletpos;
        //}

    }
}

