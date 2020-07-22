using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Robot.Parts
{
    public class Storage
    {
        public double MaxStorage { get; set; } = 100;
        public bool IsFull => (Wood + Iron + Lithium + Copper + Scrap) >= MaxStorage;

        #region Collected

        public double Wood { get; set; }
        public string WoodPercentage => $"{Wood / MaxStorage * 100}%";
        public double Iron { get; set; }
        public string IronPercentage => $"{Iron / MaxStorage * 100}%";
        public double Lithium { get; set; }
        public string LithiumPercentage => $"{Lithium / MaxStorage * 100}%";
        public double Copper { get; set; }
        public string CopperPercentage => $"{Copper / MaxStorage * 100}%";
        public int Scrap { get; set; }
        public string ScrapPercentage => $"{Scrap / MaxStorage * 100}%";

        #endregion

        public void Empty()
        {
            ResourceManager.Instance.Wood += Wood;
            ResourceManager.Instance.Iron += Iron;
            ResourceManager.Instance.Lithium += Lithium;
            ResourceManager.Instance.Copper += Copper;
            ResourceManager.Instance.Scrap += Scrap;

            Wood = 0;
            Iron = 0;
            Lithium = 0;
            Copper = 0;
            Scrap = 0;
        }

    }
}
