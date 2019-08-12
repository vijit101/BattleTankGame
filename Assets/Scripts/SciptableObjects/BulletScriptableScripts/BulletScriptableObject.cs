using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSciptableObjects",menuName = "ScriptableObjects/BulletScriptables/NewBulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType bulletType;
    public float Speed;
    public float Damage;
}
[CreateAssetMenu(fileName = "BulletScriptableObjectLists",menuName = "ScriptableObjects/BulletScriptables/NewBulletScriptableObjectList")]
public class BulletScriptableObjectList : ScriptableObject
{
    public BulletScriptableObject[] Bullets;
}

