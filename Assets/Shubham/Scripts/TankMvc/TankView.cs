using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankView : MonoBehaviour {
    
    Rigidbody rgbd;
    public float Spd = 1000;
    public float health = 0;
	// Use this for initialization
	void Start () {
        rgbd = GetComponent<Rigidbody>();
        Debug.Log("Spd "+Spd+"health "+health);
	}
	
	// Update is called once per frame
	void Update () {
        TankMove();
	}

    #region experiments
    //private void FixedUpdate()
    //{
    //    rgbd.MovePosition(rgbd.position + movespd * Time.deltaTime);
    //}

    //public void Moving()
    //{
    //    moveinp = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
    //    movespd = moveinp.normalized * Spd;
    //    Debug.Log(movespd);
    //}
    #endregion

    public void TankMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rgbd.AddForce(transform.forward * Spd, ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rgbd.AddForce(transform.forward * -Spd, ForceMode.Force);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            rgbd.AddTorque(Vector3.up*450);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rgbd.AddTorque(Vector3.up*-450);
        }
        
    }

    //public void FireBullet(){
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        BulletController Bullt_Controller = new BulletController();
    //    }
    //}
}
