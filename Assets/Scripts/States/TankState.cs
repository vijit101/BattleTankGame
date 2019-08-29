using System.Collections;
using System.Collections.Generic;
using Tanks.Tank;
using UnityEngine;

[RequireComponent(typeof(EnemyBehaviour))]
public class TankState : MonoBehaviour
{
    protected EnemyBehaviour enemyBehaviour;
    protected virtual void Awake()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }
    
    protected virtual void OnEnterState()
    {
        this.enabled = true;
    }
    protected virtual void OnExitState()
    {
        this.enabled = false;
    }
    protected virtual void tick()
    {

    }

}
