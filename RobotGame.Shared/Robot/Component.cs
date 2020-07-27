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

        public Robot AssignedRobot;
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
