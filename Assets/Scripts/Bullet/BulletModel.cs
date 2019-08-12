using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletModel
    {
        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            Damage = bulletScriptableObject.Damage;
            Speed = bulletScriptableObject.Speed;
            Type = bulletScriptableObject.bulletType;
        }
        public BulletModel(BulletType type,float BDmg, float BSpd)
        {
            Damage = BDmg;
            Speed = BSpd;
            Type = type;
        }

        public float Damage { get; set; }
        public float Speed { get; set; }
        public BulletType Type { get; private set; }
    }

}

