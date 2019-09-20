using System;
using Tanks.ObjectPool;
using UnityEngine;

namespace Tanks.Tank
{
    public class TankService : MonoSingletongeneric<TankService>
    {
        public TankView tankview; // Holds a reference to the view be instantiated
        public TankScriptableObjectList tankScriptableObjectList; // list of data to be input to model

        protected override void Awake()
        {
            base.Awake();
        }
        private void Start()
        {
            PlayerPrefs.SetFloat("Score", 0);
            PlayerPrefs.SetInt("Lives", 3);
            PlayerPrefs.SetInt("Respawn", 0);
        }
        
        private void Update()
        {
            SpawnTank(); 

        }

        private void SpawnTank()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {                    
                TankModel tankModel = new TankModel(tankScriptableObjectList.tanks[0]); // takes the input of data from scriptable objects
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
            //Gets the tank controller from pool and if not returns a new object then object is activated
            TankController TController = TankControllerPoolService.Instance.GetComponent<TankControllerPoolService>().GetTankController(tankmodel, tankview);    
        }   
    }

}
