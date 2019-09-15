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
                if (timelapse > 3.5f)
                {
                    Debug.LogError("Change Back To Patrolling State");
                    enemyBehaviour.ChangeState(enemyBehaviour.patrollingState);
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

