using System.Collections;
using System.Collections.Generic;
using Tanks.Tank;
using Tanks.utils;
using UnityEngine;

namespace Tanks.ObjectPool
{
    public class TankControllerPoolService : ObjectPoolGeneric<TankController>
    {
        private TankModel tankModel;
        private TankView tankView;
        public TankController GetTankController(TankModel model, TankView view)
        {
            this.tankView = view;
            this.tankModel = model;
            TankController getTank = GetPoolItem();
            if(getTank != null)
            {
                getTank.TankView.ResetController(tankModel);
                return getTank;
            }
            return GetPoolItem();
        }

        protected override TankController CreateItem()
        {
            TankController tankController = new TankController(tankModel, tankView);
            return tankController;
        }
    }

}


