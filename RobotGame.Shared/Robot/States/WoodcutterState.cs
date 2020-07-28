using System;
using RobotGame.Shared.Managers;

namespace RobotGame.Shared.Robot.States
{
    public class WoodcutterState : BaseState
    {
        public static WoodcutterState Instance { get; } = new WoodcutterState();
        
        public override void OnStateEnter(Robot inRobot)
        {
            Console.WriteLine($"Entering State {nameof(WoodcutterState)}");

            if(inRobot.CurrentZone.Name != "Home")
                inRobot.CurrentProgress = new Progress(inRobot.CurrentZone, WorldManager.Instance.WoodcuttingActivity);
        }

        public override void OnStateUpdate(Robot inRobot)
        {
            if (inRobot.BatteryCurrent <= 0 || inRobot.HealthCurrent <= 0)
            {
                inRobot.ChangeState(IdleState.Instance);
                return;
            }

            if (inRobot.CurrentZone.Name == "Home")
            {
                return;
            }

            inRobot.ProgressTheProgress();

            if (inRobot.StorageIsFull)
            {
                inRobot.ChangeState(IdleState.Instance);
            }
        }

        public override void OnStateLeave(Robot inRobot)
        {
            Console.WriteLine($"Leaving State {nameof(WoodcutterState)}");

            inRobot.CurrentProgress = null;
        }

        public override string Name()
        {
            return Enum.GetName(typeof(RobotJob), RobotJob.Woodcutter);
        }
    }
}
