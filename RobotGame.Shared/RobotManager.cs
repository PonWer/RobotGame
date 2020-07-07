using System;
using System.Collections.Generic;
using System.Text;
using RobotGame.Shared.Entities;

namespace RobotGame.Shared
{
    public class RobotManager : IGameLoop
    {
        private static readonly RobotManager instance = new RobotManager();

        public static RobotManager Instance => instance;

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
