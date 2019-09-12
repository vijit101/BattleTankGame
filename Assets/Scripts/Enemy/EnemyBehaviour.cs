using Tanks.interfaces;
using Tanks.States;
using UnityEngine;
namespace Tanks.Enemy
{
    public class EnemyBehaviour : MonoBehaviour, IDamagable
    {

        float score;
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
                score = PlayerPrefs.GetFloat("Score");
                score++;
                PlayerPrefs.SetFloat("Score", score);
                //Enemy Death state
                Destroy(gameObject);
            }
            else
            {
                Health = Health - Damage;
            }
        }

        TankState currentState = null;
        float Health = 400, TimeElapsed = 0;
        public float speed = 20;
        public PatrollingState patrollingState;
        public ChasingState chasingState;

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


    }

}


