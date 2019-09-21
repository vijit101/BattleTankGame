using Tanks.Bullet;
using UnityEngine;

namespace Tanks.States
{
    public class ShootingState : TankState
    {
        bool Enterstate;
        float timelapse = 0;
        private void Update()
        {
            if (Enterstate)
            {
                if (timelapse > .05f)
                {
                    enemyBehaviour.ChangeState(enemyBehaviour.patrollingState);
                    // add rotate and fire later
                }
                else
                {  
                    FireBullets();
                    timelapse = timelapse + Time.deltaTime;
                }

            }  
        }

        private void FireBullets()
        {
            enemyBehaviour.AddHealth(100);
            BulletController EnemyBullet = BulletService.Instance.GetBullet(TankType.LowHealth);
            enemyBehaviour.AddHealth((int)EnemyBullet.BulletModel.Damage);
            EnemyBullet.SetPosition(enemyBehaviour.transform.position, enemyBehaviour.transform.rotation);
        }

        public override void Awake()
        {
            base.Awake();
        }
        public override void OnEnterState()
        {
            base.OnEnterState();
            timelapse = 0;
            Enterstate = true;
        }
        public override void OnExitState()
        {
            Enterstate = false;
            base.OnExitState();
        }
        
    }

}

