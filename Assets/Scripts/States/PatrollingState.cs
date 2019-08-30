using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : TankState
{
    private void Update()
    {
        enemyBehaviour.transform.Translate(PatrollingPos() * Time.deltaTime);
    }
    public override void Awake()
    {
        base.Awake();

    }

    public override void OnEnterState()
    {
        base.OnEnterState();
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }
    public Vector3 PatrollingPos()
    {
        Vector3 MoveTo =  CheckPos(SetPatrolPosition());
        return MoveTo;
    }

    private Vector3 SetPatrolPosition()
    {
        Vector3 MyCurrentPos = enemyBehaviour.transform.position;
        Vector3 PatrolPos = Vector3.zero;
        float minrandom = UnityEngine.Random.Range(-2.5f,2);
        float maxrandom = UnityEngine.Random.Range(0,3);

        PatrolPos = PatrolPos.SetRandomVectorXYZ(MyCurrentPos.x + minrandom, MyCurrentPos.x + maxrandom, MyCurrentPos.y, MyCurrentPos.y + .1f, MyCurrentPos.z + minrandom, MyCurrentPos.z + maxrandom);
        return PatrolPos;
    }
    private Vector3 CheckPos(Vector3 position)
    {
        if (position.x>=39 || position.x <=-39||position.z >=39 ||position.z <=-39 )
        {
            Vector3 Patrol = SetPatrolPosition();
            CheckPos(Patrol);
            return Vector3.zero;
        }
        else
        {
            return position;
        }
        
    }
    private void StopPatroll()
    {
        Vector3 MyCurrentPos = enemyBehaviour.transform.position;

    }
}
