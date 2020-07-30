using System;
using System.Collections.Generic;

namespace RobotGame.Shared.Robot
{
    public class Component
    {
        public enum ComponentType
        {
            Frame,
            Arm,
            Mobility,
            Storage,
            Battery
        }

        public ComponentType Type;

        public string Material;
        public string SubType;
        public int UnlockIndex;

        public Effect Effect;
        public Cost Cost;

        public int QtyBuilt;
        public bool Researched;

        private readonly List<Robot> _assignedRobots = new List<Robot>();
        public void Attach(Robot inRobot)
        {
            //More logic?
            _assignedRobots.Add(inRobot);
        }

        public void Detach(Robot inRobot)
        {
            //More logic?
            _assignedRobots.Remove(inRobot);
        }
        public bool Available()
        {
            return _assignedRobots.Count < QtyBuilt;
        }
    }

    public class Cost
    {
        public int ResearchPoints;
        public int Wood;
        public int Copper;
        public int Iron;
        public int Lithium;

        public List<string> GetCosts()
        {
            var content = new List<string>();
            if (ResearchPoints > 0)
                content.Add($"{nameof(ResearchPoints)}: {ResearchPoints}" + Environment.NewLine);

            if (Wood > 0)
                content.Add($"{nameof(Wood)}: {Wood}" + Environment.NewLine);

            if (Copper > 0)
                content.Add($"{nameof(Copper)}: {Copper}" + Environment.NewLine);

            if (Iron > 0)
                content.Add($"{nameof(Iron)}: {Iron}" + Environment.NewLine);

            if (Lithium > 0)
                content.Add($"{nameof(Lithium)}: {Lithium}" + Environment.NewLine);

            return content;
        }
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

        public List<string> GetEffects()
        {
            var content = new List<string>();
            if (MaxCharge > 0)
                content.Add($"{nameof(MaxCharge)}: {MaxCharge}" + Environment.NewLine);

            if (ChargingSpeed > 0)
                content.Add($"{nameof(ChargingSpeed)}: {ChargingSpeed}" + Environment.NewLine);

            if (WoodcutterDamage > 0)
                content.Add($"{nameof(WoodcutterDamage)}: {WoodcutterDamage}" + Environment.NewLine);

            if (AttackDamage > 0)
                content.Add($"{nameof(AttackDamage)}: {AttackDamage}" + Environment.NewLine);

            if (StorageSize > 0)
                content.Add($"{nameof(StorageSize)}: {StorageSize}" + Environment.NewLine);

            if (Speed > 0)
                content.Add($"{nameof(Speed)}: {Speed}" + Environment.NewLine);

            if (FrameHealth > 0)
                content.Add($"{nameof(FrameHealth)}: {FrameHealth}" + Environment.NewLine);

            if (FrameDefense > 0)
                content.Add($"{nameof(FrameDefense)}: {FrameDefense}" + Environment.NewLine);

            return content;
        }
    }
}
