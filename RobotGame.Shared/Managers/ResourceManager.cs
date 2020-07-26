using System;
using System.Collections.Generic;

namespace RobotGame.Shared.Managers
{
    public partial class ResourceManager : ManagerBase
    {
        public static ResourceManager Instance { get; } = new ResourceManager();
        
        public enum Resource
        {
            Wood,
            Copper,
            Iron,
            Lithium,
            Scrap
        }

        #region Basic Resources

        public double Wood { get; set; } = 100;

        public double Iron { get; set; }
        public double Lithium { get; set; }
        public double Copper { get; set; }

        public double Scrap { get; set; }

        public double Energy { get; set; } = 150;
        #endregion

        #region Comsumption

        public int WoodsBurningForEnergy { get; set; }
        public double EnergyGainedFromWood { get; set; } = 2.5f;
        public double EnergyTransferenceRatio { get; set; } = 0.9f;
        public double EnergyGainedWithoutStoredEnergy { get; set; } = 0.1f;

        #endregion

        public List<double> EnergyHistory;
        public List<double> WoodHistory;
        public List<double> IronHistory;

        public ResourceManager()
        {
            EnergyHistory = new List<double>();
            for (var i = 0; i < 200; i++)
            {
                EnergyHistory.Add(0);
            }

            IronHistory = new List<double>();
            for (var i = 0; i < 200; i++)
            {
                IronHistory.Add(0);
            }

            WoodHistory = new List<double>();
            for (var i = 0; i < 200; i++)
            {
                WoodHistory.Add(0);
            }
        }

        public override void PreRenderUpdate()
        {
            if (Wood - WoodsBurningForEnergy < 0)
            {
                Energy += Wood * EnergyGainedFromWood;
                Wood = 0;
            }
            else
            {
                Energy += WoodsBurningForEnergy * EnergyGainedFromWood;
                Wood -= WoodsBurningForEnergy;
            }



            EnergyHistory.Add(Energy);
            if (EnergyHistory.Count > 200)
                EnergyHistory.RemoveAt(0);

            WoodHistory.Add(Wood);
            if (WoodHistory.Count > 200)
                WoodHistory.RemoveAt(0);

            IronHistory.Add(Iron);
            if (IronHistory.Count > 200)
                IronHistory.RemoveAt(0);

        }

        public override void PostRenderUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void AddResource(Resource inResource, double amount)
        {
            switch (inResource)
            {
                case Resource.Wood:
                    Wood += amount;
                    break;
                case Resource.Copper:
                    Copper += amount;
                    break;
                case Resource.Iron:
                    Iron += amount;
                    break;
                case Resource.Lithium:
                    Lithium += amount;
                    break;
                case Resource.Scrap:
                    Scrap += amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inResource), inResource, null);
            }
        }

        public void AddResource(double inWood, double inCopper, double inIron, double inLithium, double inScrap)
        {
            Wood += inWood;
            Copper += inCopper;
            Iron += inIron;
            Lithium += inLithium;
            Scrap += inScrap;
        }
    }
}

