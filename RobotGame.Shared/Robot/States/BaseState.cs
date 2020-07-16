using System;

namespace RobotGame.Shared.Robot.States
{
    public abstract class BaseState
    {
        public enum RobotJob
        {
            Idle,
            Woodcutter,
            Miner,
            Scavenger
        }

        public static BaseState GetState(string inState)
        {
            return GetState((RobotJob)Enum.Parse(typeof(RobotJob), inState));
        }

        public static BaseState GetState(RobotJob inState)
        {
            switch (inState)
            {
                case RobotJob.Woodcutter:
                    return WoodcutterState.Instance;
                case RobotJob.Idle:
                    return IdleState.Instance;
                case RobotJob.Miner:
                    return MinerState.Instance;
                case RobotJob.Scavenger:
                    return ScavengerState.Instance;
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