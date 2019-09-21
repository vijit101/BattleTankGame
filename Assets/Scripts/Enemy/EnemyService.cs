using System.Collections.Generic;
using Tanks.ObjectPool;
using UnityEngine;

namespace Tanks.Enemy
{
    public class EnemyService : MonoSingletongeneric<EnemyService>
    {
        public List<Vector3> EnemyTankPositions;
        public List<EnemyBehaviour> EnemyTankViews;
     
        protected override void Awake()
        {
            base.Awake();
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
            EnemyBehaviour enemyTank = EnemyPoolService.Instance.GetComponent<EnemyPoolService>().GetEnemyTank(EnemyTankViews[Random.Range(0, EnemyTankViews.Count)]);
            enemyTank.ResetEnemyTank(enemySpawnPos);
        }
    }

}

