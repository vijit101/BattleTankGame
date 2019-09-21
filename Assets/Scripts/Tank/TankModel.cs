namespace Tanks.Tank
{
    public class TankModel
    {
        public TankModel(TankScriptableObject tankscriptableobject)
        {
            Speed = tankscriptableobject.Speed;
            Health = tankscriptableobject.Health;
            Type = tankscriptableobject.tankType;
        }
        public TankModel(TankType type,int speed, int health)
        {
            Speed = speed;
            Health = health;
            Type = type;
        }
        public TankModel() { }

        public float Speed { get; private set; }
        public float Health { get; set; }
        public TankType Type { get; private set; }
    }
}

