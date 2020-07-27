using System;
using System.Collections.Generic;
using System.Text;
using RobotGame.Shared.Managers;

namespace RobotGame.Shared.Robot.Parts
{
    public class Storage : ComponentBase
    {
        public double MaxStorage => Effect.StorageSize;
        public bool IsFull => (Wood + Iron + Lithium + Copper + Scrap) >= Effect.StorageSize;

        #region Collected

        public double Wood { get; set; }
        public string WoodPercentage => $"{Wood / Effect.StorageSize * 100}%";
        public double Iron { get; set; }
        public string IronPercentage => $"{Iron / Effect.StorageSize * 100}%";
        public double Lithium { get; set; }
        public string LithiumPercentage => $"{Lithium / Effect.StorageSize * 100}%";
        public double Copper { get; set; }
        public string CopperPercentage => $"{Copper / Effect.StorageSize * 100}%";
        public int Scrap { get; set; }
        public string ScrapPercentage => $"{Scrap / Effect.StorageSize * 100}%";

        #endregion

        public void Empty()
        {
            ResourceManager.Instance.AddResource(Wood,Copper,Iron,Lithium,Scrap);

            Wood = 0;
            Iron = 0;
            Lithium = 0;
            Copper = 0;
            Scrap = 0;
        }

        public override ComponentType GetComponentType() => ComponentType.Storage;
    }
}
