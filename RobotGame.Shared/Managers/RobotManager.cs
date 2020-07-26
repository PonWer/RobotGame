using System;
using System.Collections.Generic;
using System.IO;
using RobotGame.Shared.Robot.Parts;

namespace RobotGame.Shared.Managers
{
    public class RobotManager : ManagerBase
    {
        public static RobotManager Instance { get; } = new RobotManager();

        public List<ComponentBase> AllComponents = new List<ComponentBase>();
        public List<ComponentBase> UnlockedComponents = new List<ComponentBase>();
        public List<ComponentBase> BuiltComponents = new List<ComponentBase>();

        public List<Robot.Robot> Robots { get; set; }

        public RobotManager()
        {
            Robots = new List<Robot.Robot>();


        }

        public override void PreRenderUpdate()
        {
            Console.WriteLine($"Robots.Count: {Robots.Count}");

            foreach (var robot in Robots)
            {
                robot.PreRenderUpdate();
            }
        }

        public override void PostRenderUpdate()
        {
            
        }
    }
}
