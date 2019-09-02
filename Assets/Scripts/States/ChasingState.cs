using UnityEngine;

public class ChasingState : TankState
{
    bool Enterstate = false;
    private void Update()
    {
        if (Enterstate)
        {
            
            float angle = 100;
            enemyBehaviour.transform.RotateAroundLocal(new Vector3(0, 1, 0), angle);
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
