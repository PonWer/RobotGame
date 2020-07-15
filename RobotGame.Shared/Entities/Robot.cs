using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared.Entities.RobotJobs;
using RobotGame.Shared.PlayerComponents;

namespace RobotGame.Shared.Entities
{
    public class Robot
    {
        public BaseState CurrentState { get; private set; }
        public int Health_Current { get; set; }
        public int Health_Max { get; set; }

        public int Battery_Current { get; set; }
        public int Battery_Max { get; set; }

        public int AttackBonus { get; set; }

        public int HealthPercentage => (int)(100 * Health_Current / (float)Health_Max);

        public void PreRenderUpdate()
        {
            CurrentState?.OnStateUpdate(this);
        }

        public void ChangeState(BaseState newState)
        {
            CurrentState?.OnStateLeave(this);

            CurrentState = newState;

            CurrentState.OnStateEnter(this);
        }

        public void OnSelectedJobChange(ChangeEventArgs e)
        {
            var selectedString = e.Value.ToString();

            ChangeState(BaseState.GetState(selectedString));

            Console.WriteLine("It is definitely: " + CurrentState.Name());
        }

    }
}
