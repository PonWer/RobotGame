using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Entities
{
    public class Robot
    {
        public int Health_Current { get; set; }
        public int Health_Max { get; set; }

        public int AttackBonus { get; set; }

        public float HealthPercentage => Health_Current / (float)Health_Max;

    }
}
