using System;
using RobotGame.Shared.Managers;

namespace RobotGame.Shared.Robot.States
{
    public class ScavengerState : BaseState
    {
        public static ScavengerState Instance { get; } = new ScavengerState();
        
        public override void OnStateEnter(Robot inRobot)
        {
            Console.WriteLine($"Entering State {nameof(ScavengerState)}");
        }

        public override void OnStateUpdate(Robot inRobot)
        {
            if (inRobot.BatteryCurrent <= 0)
            {
                inRobot.ChangeState(IdleState.Instance);
                return;
            }

            inRobot.BatteryCurrent--;
            ResourceManager.Instance.Scrap++;
        }

        public override void OnStateLeave(Robot inRobot)
        {
            Console.WriteLine($"Leaving State {nameof(ScavengerState)}");
        }

        public override string Name()
        {
            return Enum.GetName(typeof(RobotJob), RobotJob.Scavenger);
        }
    }
}
