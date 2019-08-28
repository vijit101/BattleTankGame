using System.Collections;
using System.Collections.Generic;
using Tanks.Tank;
using UnityEngine;

[RequireComponent(typeof(TankView))]
public class TankState : MonoBehaviour
{
    protected TankView tankview;
    protected virtual void Awake()
    {
        tankview = GetComponent<TankView>();
    }
    
    public virtual void OnEnterState()
    {

    }
    public virtual void OnExitState()
    {

    }
    public virtual void tick()
    {

    }

}
