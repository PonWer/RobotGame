using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using RobotGame.Shared.Entities;

namespace RobotGame.Pages.Robots
{
    public partial class RobotManagementBase : PageBase
    {
        public void AddRobot(MouseEventArgs e)
        {
            var rand = new Random();
            Game.RobotManager.Robots.Add( new Robot()
            {
                Health_Max = rand.Next(100),
                Health_Current = rand.Next(100),
                Battery_Max = 100,
                Battery_Current = 100
            });
        }
    }
}
