using System.Collections.Generic;
using Tanks.ObjectPool;
using UnityEngine;

namespace Tanks.Enemy
{
    public class EnemyService : MonoSingletongeneric<EnemyService>
    {
        public List<GameObject> EnemyTankViews;
        public List<Vector3> EnemyTankPositions;
        EnemyPoolService enemyPoolService;
        //public List<GameObject> InstantiatedEnemyTanks;
        // Start is called before the first frame update

        protected override void Awake()
        {
            base.Awake();
            enemyPoolService = GetComponent<EnemyPoolService>();
        }

        // Update is called once per frame  
        void Update()
        {
            CheckInput();
        }

        //Added an Extension method for the under purpose
        //public Vector3 SetRandomPos()
        //{
        //    float x = Random.Range(-39,39);
        //    float z = Random.Range(-39,39);
        //    Vector3 pos = new Vector3(x,-3.68f, z);
        //    return pos;
        //}
        public void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                SpawnEnemyTank();
            }

        }
        public void SpawnEnemyTank()
        {
            Vector3 enemySpawnPos = Vector3.zero;
            enemySpawnPos = enemySpawnPos.SetRandomVectorXYZ(-39, 39, 0, 10, -39, 39);
            enemySpawnPos = enemySpawnPos.SetY(-3.68f);
            EnemyTankPositions.Add(enemySpawnPos);
            GameObject enemyTank = enemyPoolService.GetEnemyTank(EnemyTankViews[Random.Range(0, EnemyTankViews.Count)]);
            enemyTank.transform.position = enemySpawnPos;
            enemyTank.transform.rotation = Quaternion.identity;
            enemyTank.SetActive(true);
            //GameObject enemyTank = Instantiate(EnemyTankViews[Random.Range(0, EnemyTankViews.Count)], enemySpawnPos, Quaternion.identity) as GameObject;
            //InstantiatedEnemyTanks.Add(enemyTank);
        }
    }

}

