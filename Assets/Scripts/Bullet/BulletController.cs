using Tanks.ObjectPool;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletController
    {
        public BulletModel BulletModel { get; set; }
        public BulletView BulletView { get; set; }

        public BulletController(BulletModel bulletModel, BulletView bulletView)
        {
            BulletView = GameObject.Instantiate<BulletView>(bulletView);
            BulletModel = bulletModel;
            BulletView.Speed = bulletModel.Speed;
            BulletView.bulletType = BulletModel.Type;
            BulletView.InitializeController(this);
        }
        
        public void SetPosition(Vector3 transformArg,Quaternion rotation)
        {
            BulletView.transform.position = transformArg;
            BulletView.transform.rotation = rotation;
        }
        public void ReturnToPool()
        {
            BulletControllerPoolService.Instance.ReturnPooledObject(this);
        }
    }


}

