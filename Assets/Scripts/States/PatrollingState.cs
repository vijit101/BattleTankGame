using UnityEngine;

public class PatrollingState : TankState
{
    Vector3 moveto;
    private void Update()
    {
        Debug.Log("here in patrolling State"+moveto);
        CheckEnemyBounds();
        enemyBehaviour.transform.Translate(moveto * Time.deltaTime);
        enemyBehaviour.transform.position = enemyBehaviour.transform.position.SetY(-3.68f);
    }
    public override void Awake()
    {
        base.Awake();
        PatrollingPos();
    }
  
    public override void OnEnterState()
    {
        base.OnEnterState();
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }
    public void PatrollingPos()
    {
         moveto = SetPatrolPosition();
        moveto = moveto.SetY(-3.68f);

    }
    private Vector3 SetPatrolPosition()
    {
        Vector3 MyCurrentPos = enemyBehaviour.transform.position;
        Vector3 PatrollPos = Vector3.zero;
        PatrollPos = PatrollPos.SetRandomVectorXYZ(-30, 30, 0, 10, -30, 30);
        PatrollPos = PatrollPos - MyCurrentPos;
        return PatrollPos;
    }
    private void CheckEnemyBounds()
    {
        if (enemyBehaviour.transform.position.x >= 30)
        {
            enemyBehaviour.transform.position = enemyBehaviour.transform.position.SetX(enemyBehaviour.transform.position.x + Random.Range(-15, -10));
            enemyBehaviour.transform.Translate(enemyBehaviour.transform.position * Time.deltaTime);
        }
        if(enemyBehaviour.transform.position.z >= 30)
        {
            enemyBehaviour.transform.position = enemyBehaviour.transform.position.SetZ(enemyBehaviour.transform.position.z + Random.Range(-15, -10));
            enemyBehaviour.transform.Translate(enemyBehaviour.transform.position * Time.deltaTime);
        }
        if (enemyBehaviour.transform.position.z <= -30 )
        {
            enemyBehaviour.transform.position = enemyBehaviour.transform.position.SetZ(enemyBehaviour.transform.position.z + Random.Range(15, 10));
            enemyBehaviour.transform.Translate(enemyBehaviour.transform.position * Time.deltaTime);
        }
        if(enemyBehaviour.transform.position.x <= -30)
        {
            enemyBehaviour.transform.position = enemyBehaviour.transform.position.SetX(enemyBehaviour.transform.position.x + Random.Range(15, 10));
            enemyBehaviour.transform.Translate(enemyBehaviour.transform.position * Time.deltaTime);
        }
    }

    //private Vector3 SetPatrolPosition()
    //{
    //    Vector3 MyCurrentPos = enemyBehaviour.transform.position;
    //    Vector3 PatrolPos = Vector3.zero;
    //    float minrandom = UnityEngine.Random.Range(-2.5f,2);
    //    float maxrandom = UnityEngine.Random.Range(0,3);

    //    PatrolPos = PatrolPos.SetRandomVectorXYZ(MyCurrentPos.x + minrandom, MyCurrentPos.x + maxrandom, MyCurrentPos.y, MyCurrentPos.y, MyCurrentPos.z + minrandom, MyCurrentPos.z + maxrandom);
    //    PatrolPos = PatrolPos.SetY(-3.68f);
    //    Debug.Log(PatrolPos);
    //    return PatrolPos;
    //}
    //private Vector3 CheckPos(Vector3 position)
    //{
    //    if (position.x>=39 || position.x <=-39||position.z >=39 ||position.z <=-39 )
    //    {
    //        Vector3 Patrol = SetPatrolPosition();
    //        CheckPos(Patrol);
    //        return Vector3.zero;
    //    }
    //    else
    //    {
    //        return position;
    //    }

    //}
    private void StopPatroll()
    {
        Vector3 MyCurrentPos = enemyBehaviour.transform.position;

    }
}
