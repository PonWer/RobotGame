using System;

namespace RobotGame.Shared.Robot.States
{
    public class WoodcutterState : BaseState
    {
        public static WoodcutterState Instance { get; } = new WoodcutterState();
        
        public override void OnStateEnter(Robot inRobot)
        {
            Console.WriteLine($"Entering State {nameof(WoodcutterState)}");

            if(inRobot.CurrentZone.Name != "Home")
                inRobot.CurrentProgress = new Progress(80,5,15,inRobot.CurrentZone);
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
                        inRobot.Frame.Storage.Wood += inRobot.CurrentZone.Tree.Quantity;
                        break;
                    case Progress.Obstacle.OreVein:
                        inRobot.Frame.Storage.Iron += inRobot.CurrentZone.OreVein.Iron;
                        inRobot.Frame.Storage.Copper += inRobot.CurrentZone.OreVein.Copper;
                        inRobot.Frame.Storage.Lithium += inRobot.CurrentZone.OreVein.Lithium;
                        break;
                    case Progress.Obstacle.Enemy:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (inRobot.Frame.Storage.IsFull)
                {
                    inRobot.ChangeState(IdleState.Instance);
                }
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
