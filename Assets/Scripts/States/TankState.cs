using System.Collections;
using System.Collections.Generic;
using Tanks.Enemy;
using Tanks.Tank;
using UnityEngine;

namespace Tanks.States
{
    [RequireComponent(typeof(EnemyBehaviour))]
    public class TankState : MonoBehaviour
    {
        [HideInInspector]
        public EnemyBehaviour enemyBehaviour;
        public virtual void Awake()
        {
            enemyBehaviour = GetComponent<EnemyBehaviour>();
        }

        public virtual void OnEnterState()
        {
            this.enabled = true;
        }
        public virtual void OnExitState()
        {
            this.enabled = false;
        }
        protected virtual void tick()
        {

        }

    }

}

