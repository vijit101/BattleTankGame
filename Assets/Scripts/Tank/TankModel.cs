using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Tank
{
    public class TankModel
    {
        public TankModel(int speed, int health)
        {
            Speed = speed;
            Health = health;
        }

        public int Speed { get; private set; }
        public int Health { get; private set; }
    }
}

