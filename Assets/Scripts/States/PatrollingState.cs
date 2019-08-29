using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : TankState
{
    protected override void Awake()
    {
        base.Awake();

    }

    protected override void OnEnterState()
    {
        base.OnEnterState();
        
    }

    protected override void OnExitState()
    {
        base.OnExitState();
    }
    public void Patrolling()
    {
        enemyBehaviour.transform.Translate(SetPatrolPosition());
    }

    private Vector3 SetPatrolPosition()
    {
        Vector3 MyCurrentPos = enemyBehaviour.transform.position;
        Vector3 PatrolPos = Vector3.zero;
        PatrolPos = PatrolPos.SetRandomVectorXYZ(MyCurrentPos.x + 2, MyCurrentPos.x + 5, MyCurrentPos.y, MyCurrentPos.y + .1f, MyCurrentPos.z + 2, MyCurrentPos.z + 5);
        return PatrolPos;
    }
}
