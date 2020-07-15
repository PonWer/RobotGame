using System;

namespace RobotGame.Shared.Entities.RobotJobs
{
    public class IdleState : BaseState
    {
        public override void OnStateEnter(Robot inRobot)
        {
            throw new NotImplementedException();
        }

        public static IdleState Instance { get; } = new IdleState();

        public override void OnStateUpdate(Robot inRobot)
        {
            inRobot.Battery_Current++;
        }

        public override void OnStateLeave(Robot inRobot)
        {
            throw new NotImplementedException();
        }

        public override string Name()
        {
            return nameof(IdleState);
        }
    }
}