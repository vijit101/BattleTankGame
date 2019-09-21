using Tanks.Bullet;
using Tanks.ObjectPool;
using UnityEngine;

namespace Tanks.Tank
{
    public class TankController
    {

        public TankView TankView { get; set; }
        public TankModel TankModel { get; set; }
        public TankModel DefaultModel { get; set; }

        public TankController(TankModel tankModel, TankView tankView)
        {
            //instantiates the tank view prefab passed to it via service 
            TankView = GameObject.Instantiate<TankView>(tankView);
            TankModel = tankModel; // points to a refrence(address) of tankModel and even if defaultmodel = new tankmodel; default = tank model still points
            DefaultModel = new TankModel(tankModel.Type,(int)tankModel.Speed,(int)tankModel.Health);
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
                int lives = PlayerPrefs.GetInt("Lives");
                if (lives < 1)
                {
                    //Game Over
                    TankControllerPoolService.Instance.ReturnPooledObject(this);
                    LevelLoader.LoadAnyLevel(2);
                }
                else
                {
                    lives--;
                    PlayerPrefs.SetInt("Lives", lives);
                    PlayerPrefs.SetInt("Respawn", 1);
                }
            }
            else
            {
                TankModel.Health = TankModel.Health-damage;
                Debug.LogError("%%%%" + TankModel.Health);
                Debug.LogError("+++" + DefaultModel.Health);
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

