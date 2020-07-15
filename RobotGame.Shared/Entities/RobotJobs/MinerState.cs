using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Entities.RobotJobs
{
    public class MinerState : BaseState
    {
        public static MinerState Instance { get; } = new MinerState();
        
        public override void OnStateEnter(Robot inRobot)
        {
            Console.WriteLine($"Entering State {nameof(MinerState)}");
        }

        public override void OnStateUpdate(Robot inRobot)
        {
            if (inRobot.Battery_Current <= 0)
            {
                inRobot.ChangeState(IdleState.Instance);
                return;
            }

            inRobot.Battery_Current--;
            ResourceManager.Instance.Iron++;
        }

        public override void OnStateLeave(Robot inRobot)
        {
            Console.WriteLine($"Leaving State {nameof(MinerState)}");
        }

        public override string Name()
        {
            return Enum.GetName(typeof(RobotJob), RobotJob.Miner);
        }
    }
}
