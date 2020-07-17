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
                inRobot.CurrentProgress = new JobProgress(JobProgress.Obstacle.Tree, inRobot.CurrentZone.Tree.DamageNeededPerWood);
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
                ResourceManager.Instance.Wood+=inRobot.CurrentZone.Tree.WoodPerTree;
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
