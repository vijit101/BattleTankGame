﻿using Tanks.interfaces;
using Tanks.ObjectPool;
using Tanks.States;
using UnityEngine;
namespace Tanks.Enemy
{
    public class EnemyBehaviour : MonoBehaviour, IDamagable
    {

        float EnemiesKilled;
        TankState currentState = null;
        float Health = 400, TimeElapsed = 0;
        public float speed = 20;
        public PatrollingState patrollingState;
        public ChasingState chasingState;
        public ShootingState shootingState;
        [HideInInspector]
        public Transform Playertarget;
        bool changeToChase = false;

        private void OnCollisionEnter(Collision collision)
        {
            IDamagable damagableComponent = collision.gameObject.GetComponent<IDamagable>();
            if (damagableComponent != null)
            {
                damagableComponent.TakeDamage(10); // damages eveyone with Idamagable on collision with them
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                Playertarget = other.gameObject.transform;
                changeToChase = true;
            }    
        }

        public void TakeDamage(float Damage)
        {
            if (Health - Damage <= 0)
            {
                //ScoreUpdate(); called via event
                //Enemy Death state  
                EventService.Instance.FireOnDeathEvent();
                ScoreUpdate();
                this.gameObject.SetActive(false);  //return the enemy to the pool
                EnemyPoolService.Instance.ReturnPooledObject(this);
            }
            else
            {
                Health = Health - Damage;
            }
        }
        // no need can be done using kill count as high score
        private void ScoreUpdate()
        {
            EnemiesKilled = PlayerPrefs.GetFloat("Score");
            EnemiesKilled++;
            PlayerPrefs.SetFloat("Score", EnemiesKilled);
        }

       private void Update()
       {
            if (currentState == null)
            {
                TimeElapsed = TimeElapsed + Time.deltaTime;
                if (TimeElapsed > Random.Range(2, 4.5f))
                {
                    //Debug.LogError("state Change");
                    ChangeState(patrollingState);
                }

            }
            if (changeToChase && currentState != chasingState)
            {

                ChangeState(chasingState);
                changeToChase = false;
            }

       }
        //State Code
        public void ChangeState(TankState newState)
        {
            if (currentState != null)
            {
                currentState.OnExitState();
                currentState = newState;
                currentState.OnEnterState();
            }
            else
            {
                currentState = newState;
                currentState.OnEnterState();
            }
        }

        public void ResetEnemyTank(Vector3 spawnPos)
        {
            transform.position = spawnPos;
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(true);
        }
        public void AddHealth(int health)
        {
            this.Health += health; 
        }

    }

}


