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
            inRobot.EmptyStorage();
        }

        public static IdleState Instance { get; } = new IdleState();

        public override void OnStateUpdate(Robot inRobot)
        {
            if (inRobot.BatteryCurrent >= inRobot.Battery.Effect.MaxCharge)
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
                    inRobot.BatteryCurrent += ResourceManager.Instance.EnergyTransferenceRatio * 1;
                    ResourceManager.Instance.Energy -= 1;
                }
                else
                {
                    inRobot.BatteryCurrent += ResourceManager.Instance.EnergyGainedWithoutStoredEnergy;
                }
            }

            if (inRobot.HealthCurrent < inRobot.Frame.Effect.FrameHealth)
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