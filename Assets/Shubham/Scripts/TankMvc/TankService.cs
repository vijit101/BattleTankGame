using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour {

    public TankView TView;
    public BulletView BView;
    bool tk1 = false, tk2 = false, tk3 = false;
	// Use this for initialization
	void Start ()
    {
        
    }
    private void Update()
    {
        TankSpawner();
        BulletFire();
    }

    private void TankSpawner()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {            
            CreateTank(500, 1000);
            tk1 = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CreateTank(1000, 500);
            tk2 = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CreateTank(700, 700);
            tk3 = true;
        }
    }

    public void BulletFire()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(tk1)
            {
                CreateBullet(10, 50);
            }
            if (tk2)
            {
                CreateBullet(20, 40);
            }
            if (tk3)
            {
                CreateBullet(30, 30);
            }
        }
    }
    private void CreateTank(int tankspeed, int tankhealth)
    {
        TankModel TMdl = new TankModel(tankspeed, tankhealth);
        TankController TController = new TankController(TMdl, TView);
    }
    private void CreateBullet(float Bspeed, float Dmg)
    {
        BulletModel BMdl = new BulletModel(Bspeed, Dmg);
        BulletController BController = new BulletController(BMdl, BView);
    }
}
