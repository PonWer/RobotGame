﻿namespace RobotGame.Shared
{
    public partial class ResourceManager : IGameLoop
    {
        public static ResourceManager Instance { get; } = new ResourceManager();


        #region Basic Resources
        public float Wood { get; set; }

        public float Iron { get; set; }
        public float Lithium { get; set; }
        public float Copper { get; set; }

        public int Scrap { get; set; }

        public float Energy { get; set; }
        #endregion

        #region Comsumption

        public int WoodsBurningForEnergy { get; set; }
        public float EnergyGainedFromWood { get; set; } = 0.5f;

        #endregion


        public void PreRenderUpdate()
        {
            if (Wood - WoodsBurningForEnergy < 0)
            {
                //Stop burning?
                WoodsBurningForEnergy = 0;
            }

            Energy += WoodsBurningForEnergy * EnergyGainedFromWood;
            Wood -= WoodsBurningForEnergy;

        }

        public void PostRenderUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}

