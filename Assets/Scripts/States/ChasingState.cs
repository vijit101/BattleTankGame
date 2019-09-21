using Tanks.Tank;
using UnityEngine;

namespace Tanks.States
{
    public class ChasingState : TankState
    {
        bool Enterstate;       
        float timelapse = 0;
        private void Update()
        {
            if (Enterstate)
            {
                enemyBehaviour.transform.position = Vector3.MoveTowards(enemyBehaviour.transform.position, enemyBehaviour.Playertarget.position, (enemyBehaviour.speed-5) * Time.deltaTime);
                if (timelapse > 2.2f)
                {
                    enemyBehaviour.ChangeState(enemyBehaviour.shootingState);
                }
                else
                {
                    timelapse += Time.deltaTime;
                }
            }

        }
        public override void Awake()
        {
            base.Awake();
            Enterstate = false;
        }
        public override void OnEnterState()
        {
            base.OnEnterState();
            Debug.LogError("Enter chase State");
            timelapse = 0;
            Enterstate = true;
        }
        public override void OnExitState()
        {
            Debug.LogError("Exit chase State");
            Enterstate = false;
            base.OnExitState();
        }
    }

}

