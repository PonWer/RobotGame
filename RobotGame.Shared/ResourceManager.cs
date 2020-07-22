using System;
using System.Collections.Generic;

namespace RobotGame.Shared
{
    public partial class ResourceManager : IGameLoop
    {
        public static ResourceManager Instance { get; } = new ResourceManager();


        #region Basic Resources

        public float Wood { get; set; } = 100;

        public float Iron { get; set; }
        public float Lithium { get; set; }
        public float Copper { get; set; }

        public int Scrap { get; set; }

        public double Energy { get; set; } = 150;
        //public List<double> EnergyHistory { get; set; }
        #endregion

        #region Comsumption

        public int WoodsBurningForEnergy { get; set; }
        public double EnergyGainedFromWood { get; set; } = 2.5f;
        public double EnergyTransferenceRatio { get; set; } = 0.9f;
        public double EnergyGainedWithoutStoredEnergy { get; set; } = 0.1f;


        #endregion


        public void PreRenderUpdate()
        {
            if (Wood - WoodsBurningForEnergy < 0)
            {
                return;
            }

            Energy += WoodsBurningForEnergy * EnergyGainedFromWood;
            Wood -= WoodsBurningForEnergy;

            //EnergyHistory.Add(Energy);
            //if(EnergyHistory.Count > 10)
            //    EnergyHistory.RemoveAt(0);

        }

        public void PostRenderUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}

