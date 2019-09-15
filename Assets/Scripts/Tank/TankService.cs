using System;
using Tanks.ObjectPool;
using UnityEngine;

namespace Tanks.Tank
{
    public class TankService : MonoSingletongeneric<TankService>
    {
        public event Action OnTankDeath;
        public TankView tankview;
        public TankScriptableObjectList tankScriptableObjectList;
        private TankControllerPoolService tankControllerPoolService;
        [HideInInspector]
        public TankController tank = null;

        protected override void Awake()
        {
            base.Awake();
            tankControllerPoolService = gameObject.GetComponent<TankControllerPoolService>();
        }
        private void Start()
        {
            PlayerPrefs.SetFloat("Score", 0);
            PlayerPrefs.SetInt("Lives", 3);
            PlayerPrefs.SetInt("Respawn", 0);
            OnTankDeath?.Invoke();
        }
        
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
            //TankController TController = new TankController(tankmodel, tankview);
            TankController TController = tankControllerPoolService.GetTankController(tankmodel, tankview);
            TController.TankView.gameObject.SetActive(true);
            TController.TankView.gameObject.transform.position = new Vector3(0, TController.TankView.gameObject.transform.position.y,0);
            // For reactivation the health be reset to teh model 
            TController.TankModel = tankmodel;
            tank = TController;
        }   
    }

}
