using System;
using System.Collections;
using System.Collections.Generic;
using Tanks.interfaces;
using Tanks.Bullet;
using UnityEngine;

namespace Tanks.Tank
{
    [RequireComponent(typeof(Rigidbody))]
    // Implements Idamagable as it can be damaged by bullets 
    public class TankView : MonoBehaviour ,IDamagable
    {
        // Implemented interface function 
        public void TakeDamage(float Damage)
        {
            tankcontroller.ApplyDamage(Damage);
            tankcontroller.SetModelToView(this);
        }

        [HideInInspector]
        public TankType Type; // holds an enum as a type
        Rigidbody rgbd; 
        [HideInInspector]
        public float Speed = 1000;
        [HideInInspector]
        public float Health = 0;
        public float TotTank = 0;
        private TankController tankcontroller;

        // Use this for initialization
        void Start()
        {
            transform.position = transform.position.SetY(-3.74f);
            EventService.Instance.EnemyOnDeath += AddTankHealth; // Sub to event when enemy dies it gets health
            rgbd = GetComponent<Rigidbody>();
            Debug.Log("Spd " + Speed + "health " + Health +"Type "+Type + "Count"+TotTank);
        }

        // Update is called once per frame
        void Update()
        {
            TankMove();
            CheckRespawn();
            TankFire();
        }
        public void InitializeController(TankController tankController)
        {
            this.tankcontroller = tankController;
        }
        public void TankMove()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rgbd.velocity = Vector3.zero;
                rgbd.AddForce(transform.forward * Speed, ForceMode.Force);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rgbd.velocity = Vector3.zero;
                rgbd.AddForce(transform.forward * -Speed, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rgbd.angularVelocity = Vector3.zero;
                transform.Rotate(new Vector3(0,90,0)*Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rgbd.angularVelocity = Vector3.zero;
                //rgbd.AddTorque(Vector3.up * -45);
                transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime);
            }

        }
        public void TankFire()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                tankcontroller.FireBullet();
            }
        }

        public void CheckRespawn()
        {
            if(PlayerPrefs.GetInt("Respawn") ==1)
            {
                gameObject.SetActive(false);
                RespawnPlayer();         
            }
        }
        public void RespawnPlayer()
        {
            rgbd.velocity = Vector3.zero;
            rgbd.angularVelocity = Vector3.zero;
            Vector3 RespawnPos = Vector3.zero;
            RespawnPos = RespawnPos.SetRandomVectorXYZ(-38, 38, 0, 5, -38, 38);
            RespawnPos = RespawnPos.SetY(-3.74f);
            gameObject.transform.position = RespawnPos;
            gameObject.SetActive(true);
            PlayerPrefs.SetInt("Respawn", 0);
        }
        public void AddTankHealth()
        {
            //Adds health to tank when it kills an enemy tank so subscribe to enemyondeath event
            tankcontroller.TankModel.Health += 200;
            tankcontroller.SetModelToView(this);
            Debug.LogError("Tank Health After Killing Enemy" + tankcontroller.TankModel.Health);
        }

        private void OnDisable()
        {
            EventService.Instance.EnemyOnDeath -= AddTankHealth;
        }
    }

}

