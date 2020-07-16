using System;

namespace RobotGame.Shared.Robot.States
{
    public class IdleState : BaseState
    {
        public override void OnStateEnter(Robot inRobot)
        {
            Console.WriteLine($"Entering State {nameof(IdleState)}");
        }

        public static IdleState Instance { get; } = new IdleState();

        public override void OnStateUpdate(Robot inRobot)
        {
            if (inRobot.Battery_Current >= inRobot.Battery_Max)
            {
                return;
            }

            inRobot.Battery_Current++;
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