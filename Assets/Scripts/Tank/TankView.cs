using System;
using System.Collections;
using System.Collections.Generic;
using Tanks.Bullet;
using UnityEngine;

namespace Tanks.Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankView : MonoBehaviour
    {
        [HideInInspector]
        public TankType Type;
        Rigidbody rgbd;
        [HideInInspector]
        public float Speed = 1000;
        [HideInInspector]
        public float Health = 0;
        public float TotTank = 0;
        public bool IsFire = false;
        
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
        }

        public void TankMove()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rgbd.AddForce(transform.forward * Speed, ForceMode.Force);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rgbd.AddForce(transform.forward * -Speed, ForceMode.Force);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rgbd.AddTorque(Vector3.up * 450);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                rgbd.AddTorque(Vector3.up * -450);
            }

        }
    }

}

