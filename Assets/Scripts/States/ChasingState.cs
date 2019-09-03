using Tanks.Tank;
using UnityEngine;

public class ChasingState : TankState
{
    float speed = 10;
    bool Enterstate = false;
    Transform target = TankService.Instance.tank.TankView.transform;
    private void Update()
    {
        if (Enterstate)
        {
            enemyBehaviour.transform.position = Vector3.MoveTowards(enemyBehaviour.transform.position, target.position, 10 * Time.deltaTime);                       
        } 
        if(Vector3.Distance(enemyBehaviour.transform.position,target.position)>2.5f)
        {
            enemyBehaviour.ChangeState(enemyBehaviour.patrollingState);
        }
    }
    public override void Awake()
    {
        base.Awake();
    }
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("inside chase");
        Enterstate = true;       
    }
    public override void OnExitState()
    {
        enemyBehaviour.transform.rotation = Quaternion.identity;
        Enterstate = false;
        base.OnExitState();
        
    }
}
