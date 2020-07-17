﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared.Robot.Parts;
using RobotGame.Shared.Robot.States;

namespace RobotGame.Shared.Robot
{
    public class Robot
    {
        public BaseState CurrentState { get; private set; }
        public Zone CurrentZone { get; set; }
        public JobProgress CurrentProgress { get; set; }
        public Frame Frame { get; set; }
        public int HealthCurrent { get; set; }
        public int Health_Max { get; set; }

        public int Battery_Current { get; set; }
        public int Battery_Max { get; set; }

        public int AttackBonus { get; set; }


        public int HealthPercentage => (int)(100 * HealthCurrent / (float)Health_Max);

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
        }

        public void OnSelectedZoneChange(ChangeEventArgs e)
        {
            var selectedString = e.Value.ToString();

            CurrentZone = WorldManager.Instance.Zones.First(x => x.Name == selectedString);
            ChangeState(CurrentState);
        }

    }
}
