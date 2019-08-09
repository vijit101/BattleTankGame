using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankView : MonoBehaviour
    {

        Rigidbody rgbd;
        public float Speed = 1000;
        public float Health = 0;
        // Use this for initialization
        void Start()
        {
            rgbd = GetComponent<Rigidbody>();
            Debug.Log("Spd " + Speed + "health " + Health);
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

