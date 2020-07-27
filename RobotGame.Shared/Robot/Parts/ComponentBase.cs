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

        public string Material;
        public string Type;
        public int UnlockIndex;

        public Effect Effect;
        public Cost Cost;

    }

    public class Cost
    {
        public int ResearchPoints;
        public int Wood;
        public int Copper;
        public int Iron;
        public int Lithium;
    }

    public class Effect
    {
        public double EnergyConsumption;

        #region Battery
        public double MaxCharge;
        public double ChargingSpeed;
        #endregion

        #region Arm
        public double WoodcutterDamage;
        public double AttackDamage;
        #endregion

        #region Storage
        public double StorageSize;
        #endregion

        #region Mobility
        public double Speed;
        #endregion

        #region Frame
        public double FrameHealth;
        public double FrameDefense;
        #endregion
    }
}
