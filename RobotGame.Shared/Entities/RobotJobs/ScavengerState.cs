using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Entities.RobotJobs
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
            if (inRobot.Battery_Current <= 0)
            {
                inRobot.ChangeState(IdleState.Instance);
                return;
            }

            inRobot.Battery_Current--;
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
