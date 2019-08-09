using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletModel
    {
        public BulletModel(float BDmg, float BSpd)
        {
            Damage = BDmg;
            Speed = BSpd;
        }

        public float Damage { get; set; }
        public float Speed { get; set; }
    }

}

