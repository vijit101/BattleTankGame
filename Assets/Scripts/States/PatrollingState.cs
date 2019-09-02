using UnityEngine;

public class PatrollingState : TankState
{
    Vector3 moveto;
    float timeelasped = 3;
    bool enterState = false,checkbound = false;
    private void Update()
    {
        print(enterState);
        if(enterState)
        {
            MovePatroll();
        }
        
    }
    public override void Awake()
    {
        base.Awake();
        
        
    }
  
    public override void OnEnterState()
    {
        base.OnEnterState();
        enterState = true;
    }

    public override void OnExitState()
    {
        StopPatroll();
        enterState = false;
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
        PatrollPos = PatrollPos.SetRandomVectorXYZ(-15, 15, 0, 10, -15, 15);
        return PatrollPos;
    }
    private void MovePatroll()
    {
        
        if (timeelasped<3)
        {            
            timeelasped = 6;
            if (checkbound)
            {
                PatrollingPos();
            }
            
        }
        else
        {          
            enemyBehaviour.transform.Translate(moveto * Time.deltaTime);
            enemyBehaviour.transform.position = enemyBehaviour.transform.position.SetY(-3.68f);
            timeelasped = timeelasped-Time.deltaTime;
            CheckEnemyBounds();
        }
       
    }

    private void CheckEnemyBounds()
    {
        if (enemyBehaviour.transform.position.x >= 30)
        {
            moveto = enemyBehaviour.transform.position + new Vector3(Random.Range(-15, -10), enemyBehaviour.transform.position.y, enemyBehaviour.transform.position.z);
            checkbound = false;
        }
        if (enemyBehaviour.transform.position.z >= 30)
        {
            checkbound = false;
            moveto = enemyBehaviour.transform.position+ new Vector3(enemyBehaviour.transform.position.x, enemyBehaviour.transform.position.y, Random.Range(-15, -10));
        }
        if (enemyBehaviour.transform.position.z <= -30)
        {
            moveto = enemyBehaviour.transform.position  + new Vector3(enemyBehaviour.transform.position.x, enemyBehaviour.transform.position.y, Random.Range(10, 15));
            checkbound = false;
        }
        if (enemyBehaviour.transform.position.x <= -30)
        {
            checkbound = false;
            moveto = enemyBehaviour.transform.position  + new Vector3(Random.Range(10, 15), enemyBehaviour.transform.position.y, enemyBehaviour.transform.position.z);
        }
        else
        {
            checkbound = true;
        }
    }

    private void StopPatroll()
    {
        Vector3 MyCurrentPos = enemyBehaviour.transform.position;
        enemyBehaviour.transform.position = MyCurrentPos;
    }
}
