using Tanks.interfaces;
using Tanks.ObjectPool;
using Tanks.States;
using UnityEngine;
namespace Tanks.Enemy
{
    public class EnemyBehaviour : MonoBehaviour, IDamagable
    {

        float score;
        TankState currentState = null;
        float Health = 400, TimeElapsed = 0;
        public float speed = 20;
        public PatrollingState patrollingState;
        public ChasingState chasingState;

        private void OnTriggerEnter(Collider other)
        {
            //if (other.gameObject.tag == "Bullet")
            //{
            //    Destroy(gameObject);
            //}
            // Can add if idamagable for player too and remove tag logic
            // ifplayer touch or in trigger with enemy tank -- player health
            //EventService.Instance.OnUpdateScore += UpdateScore;  


        }
        private void Start()
        {
            EventService.Instance.EnemyOnDeath += ScoreUpdate;
        }

        private void UpdateScore(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                int lives = PlayerPrefs.GetInt("Lives");
                if (lives < 1)
                {
                    //Game Over
                    Debug.Log("Player Dead");
                }
                else
                {
                    lives--;
                    PlayerPrefs.SetInt("Lives", lives);
                    PlayerPrefs.SetInt("Respawn", 1);
                }
            }
        }

        public void TakeDamage(float Damage)
        {
            if (Health - Damage <= 0)
            {
                //ScoreUpdate(); called via event
                //Enemy Death state  
                EventService.Instance.FireOnDeathEvent();  //Here I fire the on death event as the enemy is dead
                this.gameObject.SetActive(false);  //return the enemy to the pool
                EnemyPoolService.Instance.ReturnPooledObject(this.gameObject);
            }
            else
            {
                Health = Health - Damage;
            }
        }
        // no need can be done using kill count as high score
        private void ScoreUpdate()
        {
            score = PlayerPrefs.GetFloat("Score");
            score++;
            PlayerPrefs.SetFloat("Score", score);
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

        }
        //State Code
        public void ChangeState(TankState newState)
        {
            if (currentState != null)
            {
                currentState.OnExitState();
            }
            else
            {
                currentState = newState;
                currentState.OnEnterState();
            }
        }

        private void OnDisable()
        {
            EventService.Instance.EnemyOnDeath -= ScoreUpdate;
        }

    }

}


