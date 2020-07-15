using System;
using System.Collections.Generic;
using System.Text;
using RobotGame.Shared.Entities;

namespace RobotGame.Shared
{
    public class RobotManager : IGameLoop
    {
        public static RobotManager Instance { get; } = new RobotManager();

        public List<Robot> Robots { get; set; }

        public RobotManager()
        {
            Robots = new List<Robot>();
        }

        public void PreRenderUpdate()
        {
            foreach (var robot in Robots)
            {
                robot.PreRenderUpdate();
            }
        }

        public void PostRenderUpdate()
        {
            
        }
    }
}
