using System;
using System.Collections.Generic;
using System.Text;
using RobotGame.Shared.Entities.RobotJobs;
using RobotGame.Shared.PlayerComponents;

namespace RobotGame.Shared.Entities
{
    public class Robot
    {
        private BaseState _currentBase;
        public int Health_Current { get; set; }
        public int Health_Max { get; set; }

        public int Battery_Current { get; set; }
        public int Battery_Max { get; set; }

        public int AttackBonus { get; set; }

        public int HealthPercentage => (int)(100 * Health_Current / (float)Health_Max);

        public void PreRenderUpdate()
        {
            _currentBase.OnStateUpdate(this);
        }

        public void ChangeState(BaseState newState)
        {
            _currentBase?.OnStateLeave(this);

            _currentBase = newState;

            _currentBase.OnStateEnter(this);
        }


    }
}
