using System;
using System.Collections;
using System.Collections.Generic;
using Tanks.Bullet;
using UnityEngine;

namespace Tanks.Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankView : MonoBehaviour ,IDamagable
    {
        public void TakeDamage(int Damage)
        {
            throw new NotImplementedException();
        }

        [HideInInspector]
        public TankType Type;
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
            if (Input.GetKeyDown(KeyCode.D))
            {
                rgbd.angularVelocity = Vector3.zero;
                rgbd.AddTorque(Vector3.up * 450);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                rgbd.angularVelocity = Vector3.zero;
                rgbd.AddTorque(Vector3.up * -450);
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

        
    }

}

