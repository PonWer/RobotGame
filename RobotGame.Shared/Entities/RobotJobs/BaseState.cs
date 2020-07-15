using System;

namespace RobotGame.Shared.Entities.RobotJobs
{
    public abstract class BaseState
    {
        public enum RobotJob
        {
            Idle,
            Woodcutter
        }

        public BaseState GetState(RobotJob inState)
        {
            switch (inState)
            {
                case RobotJob.Woodcutter:
                    return WoodcutterState.Instance;
                case RobotJob.Idle:
                    return IdleState.Instance;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inState), inState, null);
            }
        }

        public abstract void OnStateEnter(Robot inRobot);

        public abstract void OnStateUpdate(Robot inRobot);

        public abstract void OnStateLeave(Robot inRobot);

        public abstract string Name();
    }
}