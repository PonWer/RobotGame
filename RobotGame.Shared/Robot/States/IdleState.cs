using System;
using System.ComponentModel.DataAnnotations;

namespace RobotGame.Shared.Robot.States
{
    public class IdleState : BaseState
    {
        public override void OnStateEnter(Robot inRobot)
        {
            Console.WriteLine($"Entering State {nameof(IdleState)}");
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

                return;
            }

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