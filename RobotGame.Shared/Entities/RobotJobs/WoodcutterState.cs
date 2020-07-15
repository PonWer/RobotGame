using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Entities.RobotJobs
{
    public class WoodcutterState : BaseState
    {
        public static WoodcutterState Instance { get; } = new WoodcutterState();
        
        public override void OnStateEnter(Robot inRobot)
        {
            throw new NotImplementedException();
        }

        public override void OnStateUpdate(Robot inRobot)
        {
            inRobot.Battery_Current--;
            ResourceManager.Instance.Wood++;
        }

        public override void OnStateLeave(Robot inRobot)
        {
            throw new NotImplementedException();
        }

        public override string Name()
        {
            return nameof(WoodcutterState);
        }
    }
}
