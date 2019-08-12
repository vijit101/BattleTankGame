using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObjects",menuName ="ScriptableObjects/TankScriptables/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public string TankName;
    public float Speed;
    public float Health;
}
[CreateAssetMenu(fileName = "TankScriptableObjectLists",menuName = "ScriptableObjects/TankScriptables/NewTankScriptableObjectList")]
public class TankScriptableObjectList :ScriptableObject
{
    public TankScriptableObject[] tanks;
}
