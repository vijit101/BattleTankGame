using Tanks.Bullet;
using Tanks.ObjectPool;
using UnityEngine;

namespace Tanks.Tank
{
    public class TankController
    {

        public TankView TankView { get; set; }
        public TankModel TankModel { get; set; }

        public TankController(TankModel tankModel, TankView tankView)
        {
            //instantiates the tank view prefab passed to it via service 
            TankView = GameObject.Instantiate<TankView>(tankView);
            TankModel = tankModel;
            // Setting the model to view
            TankView.Speed = tankModel.Speed;
            TankView.Health = tankModel.Health;
            TankView.Type = tankModel.Type;
            // Setting a refrence of this controller to its created view
            TankView.InitializeController(this);            

        }

        // Takes a bulelt from bullet service and fires a bullet 
        public void FireBullet()
        {
            BulletController bulletController = BulletService.Instance.GetBullet(TankModel.Type);
            Vector3 Bulletpos = TankView.transform.position;
            Bulletpos = Bulletpos.SetY(.2f);
            bulletController.SetPosition(Bulletpos,TankView.transform.rotation);
            
           
        }

        // Implementation of idamagable interface throught view calls in apply method
        public void ApplyDamage(float damage)
        {
            if (TankModel.Health - damage <= 0)
            {
                // If player dead return it to the pool 
                TankControllerPoolService.Instance.ReturnPooledObject(this);
                this.TankView.gameObject.SetActive(false);
                LevelLoader.LoadAnyLevel(2);
            }
            else
            {
                TankModel.Health = TankModel.Health-damage;
            }
        }
        // Sets model to view stats
        public void SetModelToView(TankView tank)
        {
            tank.Speed = TankModel.Speed;
            tank.Health = TankModel.Health;
        }
        public void SetModel(TankModel tankmodel)
        {
            TankModel = tankmodel;
        }
    }

}

