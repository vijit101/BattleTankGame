using Tanks.Tank;
using UnityEngine;

public class PatrollingState : TankState
{
    Vector3 moveto;
    float timeelasped = 3;
    bool enterState = false;
    Transform target = GameObject.FindGameObjectWithTag("Player").transform;
    private void Update()
    {
        //print(enterState);
        if(enterState)
        {
            MovePatroll();
        }
        if(Vector3.Distance(enemyBehaviour.transform.position,target.position) < 2.5f)
        {
            enemyBehaviour.ChangeState(enemyBehaviour.chasingState);
        }
    }
    public override void Awake()
    {
        base.Awake();
        print("Test"+target.position);
        
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
        PatrollPos = PatrollPos.SetRandomVectorXYZ(-30, 30, 0, 10, -30, 30);
        return PatrollPos;
    }
    private void MovePatroll()
    {
        
        if (timeelasped<0)
        {            
            timeelasped = 3;
            PatrollingPos();
            
            
        }
        else
        {
            Debug.LogError(moveto);
            enemyBehaviour.transform.position = Vector3.MoveTowards(enemyBehaviour.transform.position,moveto,enemyBehaviour.speed*Time.deltaTime);
            enemyBehaviour.transform.position = enemyBehaviour.transform.position.SetY(-3.68f);
            timeelasped = timeelasped-Time.deltaTime;
            
        }
       
    }
    private void StopPatroll()
    {
        Vector3 MyCurrentPos = enemyBehaviour.transform.position;
        enemyBehaviour.transform.position = MyCurrentPos;
    }

}
