using Tanks.Tank;
using UnityEngine;

public class ChasingState : TankState
{
    float speed = 10;
    bool Enterstate = false;
    Transform target;
    float timelapse = 0;
    private void Update()
    {
        if (Enterstate)
        {
            enemyBehaviour.transform.position = Vector3.MoveTowards(enemyBehaviour.transform.position, target.position, speed * Time.deltaTime);
            if (timelapse > 3)
            {
                Debug.LogError("Change To Patrolling State");
                enemyBehaviour.ChangeState(enemyBehaviour.patrollingState);
            }
            else
            {
                timelapse += Time.deltaTime;
            }
        }
        
    }
    public override void Awake()
    {
        base.Awake();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.LogError("Change To Chasing State " + target.position);
    }
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.LogError("inside chase State");
        Enterstate = true;        
    }
    public override void OnExitState()
    {
        Enterstate = false;
        base.OnExitState();        
    }
}
