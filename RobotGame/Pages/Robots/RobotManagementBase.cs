using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RobotGame.Shared;
using RobotGame.Shared.Managers;
using RobotGame.Shared.Robot;
using RobotGame.Shared.Robot.States;

namespace RobotGame.Pages.Robots
{
    public partial class RobotManagementBase : PageBase
    {
        public void AddRobot(MouseEventArgs e)
        {
            var frame = RobotManager
                .Instance
                .BuiltComponents
                .First(x => x.Type == Component.ComponentType.Frame);

            var storage = RobotManager
                .Instance
                .BuiltComponents
                .First(x => x.Type == Component.ComponentType.Storage);

            var battery = RobotManager
                .Instance
                .BuiltComponents
                .First(x => x.Type == Component.ComponentType.Battery);

            var mobility = RobotManager
                .Instance
                .BuiltComponents
                .First(x => x.Type == Component.ComponentType.Mobility);

            var arm = RobotManager
                .Instance
                .BuiltComponents
                .First(x => x.Type == Component.ComponentType.Arm);


            var robot = new Robot()
            {
                Frame = frame,
                Storage = storage,
                Arms = new List<Component>(){arm},
                Battery = battery,
                Mobility = mobility,
                CurrentZone = WorldManager.Instance.Zones[0]
            };
            //todo
            robot.ChangeState(IdleState.Instance);

            Game.RobotManager.Robots.Add(robot);
            
        }

        public List<string> AllJobs => 
            Enum.GetNames(typeof(BaseState.RobotJob)).ToList();

    }
}
