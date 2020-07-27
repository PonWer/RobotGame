using System;
using System.ComponentModel.DataAnnotations;
using RobotGame.Shared.Managers;

namespace RobotGame.Shared.Robot.States
{
    public class IdleState : BaseState
    {
        public override void OnStateEnter(Robot inRobot)
        {
            Console.WriteLine($"Entering State {nameof(IdleState)}");
            inRobot.Storage.Empty();
        }

        public static IdleState Instance { get; } = new IdleState();

        public override void OnStateUpdate(Robot inRobot)
        {
            if (inRobot.Battery.Current >= inRobot.Battery.Effect.MaxCharge)
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
                    inRobot.Battery.Current += ResourceManager.Instance.EnergyTransferenceRatio * 1;
                    ResourceManager.Instance.Energy -= 1;
                }
                else
                {
                    inRobot.Battery.Current += ResourceManager.Instance.EnergyGainedWithoutStoredEnergy;
                }
            }

            if (inRobot.Frame.HealthCurrent < inRobot.Frame.Effect.FrameHealth)
            {
                inRobot.Frame.HealthCurrent += 1;
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