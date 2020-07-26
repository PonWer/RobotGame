﻿using System;
using System.ComponentModel.DataAnnotations;
using RobotGame.Shared.Managers;

namespace RobotGame.Shared.Robot.States
{
    public class IdleState : BaseState
    {
        public override void OnStateEnter(Robot inRobot)
        {
            Console.WriteLine($"Entering State {nameof(IdleState)}");
            inRobot.Frame.Storage.Empty();
        }

        public static IdleState Instance { get; } = new IdleState();

        public override void OnStateUpdate(Robot inRobot)
        {
            if (inRobot.Battery_Current >= inRobot.Battery_Max)
            {
                if (inRobot.ReturnToPreviousStateOnMaxBattery && inRobot.PreviousState != null)
                {
                    inRobot.ChangeState(inRobot.PreviousState);
                }
            }
            else
            {
                if (ResourceManager.Instance.Energy > 1)
                {
                    inRobot.Battery_Current += ResourceManager.Instance.EnergyTransferenceRatio * 1;
                    ResourceManager.Instance.Energy -= 1;
                }
                else
                {
                    inRobot.Battery_Current += ResourceManager.Instance.EnergyGainedWithoutStoredEnergy;
                }
            }

            if (inRobot.HealthCurrent < inRobot.Health_Max)
            {
                inRobot.HealthCurrent += 1;
            }
        }

        public override void OnStateLeave(Robot inRobot)
        {
            Console.WriteLine($"Leaving State {nameof(IdleState)}");
        }

        public override string Name()
        {
            return Enum.GetName(typeof(RobotJob), RobotJob.Idle);
        }
    }
}