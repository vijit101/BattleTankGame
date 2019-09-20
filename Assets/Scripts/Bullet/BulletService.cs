using Tanks.ObjectPool;

namespace Tanks.Bullet
{
    public class BulletService : MonoSingletongeneric<BulletService>
    {
        //private BulletControllerPoolService bulletControllerPoolService;
        private TankType tankType, ViewType;
        public BulletScriptableObjectList bulletScriptableObjectList;
        public BulletView bulletView;

        protected override void Awake()
        {
            base.Awake();
            //bulletControllerPoolService = GetComponent<BulletControllerPoolService>();
        }
        
        public BulletController GetBullet(TankType tankType)
        {
            if (tankType == TankType.LowHealth)
            {
                BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[0]);
                BulletController bulletController = BulletControllerPoolService.Instance.GetComponent<BulletControllerPoolService>().GetBulletController(bulletModel, bulletView);
                return bulletController;
            }
            if (tankType == TankType.MediumHealth)
            {
                BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[1]);
                BulletController bulletController = BulletControllerPoolService.Instance.GetComponent<BulletControllerPoolService>().GetBulletController(bulletModel, bulletView);
                return bulletController;
            }
            if (tankType == TankType.HeavyHealth)
            {
                BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.Bullets[2]);
                BulletController bulletController = BulletControllerPoolService.Instance.GetComponent<BulletControllerPoolService>().GetBulletController(bulletModel, bulletView);
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

