using System;
using System.Collections.Generic;
using System.Text;
using RobotGame.Shared.Managers;

namespace RobotGame.Shared.Robot.Parts
{
    public abstract class ComponentBase
    {
        public enum ComponentType
        {
            Frame,
            Arm,
            Mobility,
            Storage,
            Battery
        }

        public abstract ComponentType GetComponentType();
        public int Id;

        public ResourceManager.Resource MadeOfResource { get; set; }

        public double EnergyConsumption { get; set; }

        public int ResearchPointCont;
        public int WoodCost;

    }
}
