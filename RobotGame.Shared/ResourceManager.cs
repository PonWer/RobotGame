using System;
using System.Collections.Generic;

namespace RobotGame.Shared
{
    public partial class ResourceManager : IGameLoop
    {
        public static ResourceManager Instance { get; } = new ResourceManager();


        #region Basic Resources

        public double Wood { get; set; } = 100;

        public double Iron { get; set; }
        public double Lithium { get; set; }
        public double Copper { get; set; }

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

        public List<double> EnergyHistory = new List<double>();

        public void PreRenderUpdate()
        {
            if (Wood - WoodsBurningForEnergy < 0)
            {
                return;
            }

            Energy += WoodsBurningForEnergy * EnergyGainedFromWood;
            Wood -= WoodsBurningForEnergy;

            EnergyHistory.Add(Energy);
            if (EnergyHistory.Count > 200)
                EnergyHistory.RemoveAt(0);

        }

        public void PostRenderUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}

