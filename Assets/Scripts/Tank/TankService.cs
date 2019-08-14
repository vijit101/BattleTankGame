using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Bullet;

namespace Tanks.Tank
{
    public class TankService : MonoBehaviour
    {
        private void Start()
        {
            PlayerPrefs.SetFloat("Score", 0);
        }

        public TankView tankview;
        public BulletService bulletService;
        //public Object[] TanksSpawned;
        //public TankScriptableObject[] tankConfigurations;
        public TankScriptableObjectList tankScriptableObjectList;
        private void Update()
        {
            SpawnTank();
        }

        private void SpawnTank()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {    
                
                TankModel tankModel = new TankModel(tankScriptableObjectList.tanks[0]);
                CreateTank(tankModel);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TankModel tankModel = new TankModel(tankScriptableObjectList.tanks[1]);
                CreateTank(tankModel);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                TankModel tankModel = new TankModel(tankScriptableObjectList.tanks[2]);
                CreateTank(tankModel);
            }
        }

        private void CreateTank(TankModel tankmodel)
        {
            TankController TController = new TankController(tankmodel, tankview,bulletService);

        }
    }

}
