using System;

namespace RobotGame.Shared.Robot.States
{
    public class MinerState : BaseState
    {
        public static MinerState Instance { get; } = new MinerState();
        
        public override void OnStateEnter(Robot inRobot)
        {
            Console.WriteLine($"Entering State {nameof(MinerState)}");

            if (inRobot.CurrentZone.Name != "Home")
                inRobot.CurrentProgress = new JobProgress(JobProgress.Obstacle.OreVein, inRobot.CurrentZone.OreVein.Health);
        }

        public override void OnStateUpdate(Robot inRobot)
        {
            if (inRobot.Battery_Current <= 0)
            {
                inRobot.ChangeState(IdleState.Instance);
                return;
            }

            if (inRobot.CurrentZone.Name == "Home")
            {
                return;
            }

            inRobot.Battery_Current--;

            if (inRobot.CurrentProgress.AttackAndMove(1))
            {
                ResourceManager.Instance.Iron += inRobot.CurrentZone.OreVein.Iron;
                ResourceManager.Instance.Copper += inRobot.CurrentZone.OreVein.Copper;
                ResourceManager.Instance.Lithium += inRobot.CurrentZone.OreVein.Lithium;
            }
        }

        public override void OnStateLeave(Robot inRobot)
        {
            Console.WriteLine($"Leaving State {nameof(MinerState)}");

            inRobot.CurrentProgress = null;
        }

        public override string Name()
        {
            return Enum.GetName(typeof(RobotJob), RobotJob.Miner);
        }
    }
}
