using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : Singletongeneric<EnemyService>
{
    public List<GameObject> EnemyTankViews;
    public List<Vector3> EnemyTankPositions;
    public List<GameObject> InstantiatedEnemyTanks;
    // Start is called before the first frame update

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
        enemySpawnPos = enemySpawnPos.SetRandomVectorXYZ(-39,39,0,10,-39,39);
        enemySpawnPos = enemySpawnPos.SetY(-3.68f);
        EnemyTankPositions.Add(enemySpawnPos);
        GameObject enemyTank = Instantiate(EnemyTankViews[Random.Range(0, EnemyTankViews.Count)], enemySpawnPos, Quaternion.identity) as GameObject;
        InstantiatedEnemyTanks.Add(enemyTank);
    }
}
