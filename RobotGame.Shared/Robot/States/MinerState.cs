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
                inRobot.CurrentProgress = new Progress(5,80,15,inRobot.CurrentZone);
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
            var obstacleOnPathDestroyed =
                inRobot.CurrentProgress.AttackAndMove(inRobot.AttackDamage, out var damageTaken, out var obstacle);
            inRobot.HealthCurrent -= damageTaken;
            if (obstacleOnPathDestroyed)
            {
                switch (obstacle)
                {
                    case Progress.Obstacle.Empty:
                        break;
                    case Progress.Obstacle.Tree:
                        ResourceManager.Instance.Wood += inRobot.CurrentZone.Tree.Quantity;
                        break;
                    case Progress.Obstacle.OreVein:
                        ResourceManager.Instance.Iron += inRobot.CurrentZone.OreVein.Iron;
                        ResourceManager.Instance.Copper += inRobot.CurrentZone.OreVein.Copper;
                        ResourceManager.Instance.Lithium += inRobot.CurrentZone.OreVein.Lithium;
                        break;
                    case Progress.Obstacle.Enemy:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
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
