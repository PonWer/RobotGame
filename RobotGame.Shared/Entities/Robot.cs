using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Entities
{
    public class Robot
    {
        public int Health_Current { get; set; }
        public int Health_Max { get; set; }

        public int Battery_Current { get; set; }
        public int Battery_Max { get; set; }

        public int AttackBonus { get; set; }

        public int HealthPercentage => (int)(100 * Health_Current / (float)Health_Max);

        public void PreRenderUpdate()
        {
            if(Battery_Current > 0)
                Battery_Current--;
        }
    }
}
