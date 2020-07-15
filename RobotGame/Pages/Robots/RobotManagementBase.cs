﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RobotGame.Shared.Entities;
using RobotGame.Shared.Entities.RobotJobs;

namespace RobotGame.Pages.Robots
{
    public partial class RobotManagementBase : PageBase
    {
        public void AddRobot(MouseEventArgs e)
        {
            var rand = new Random();
            var robot = new Robot()
            {
                Health_Max = rand.Next(100),
                Health_Current = rand.Next(100),
                Battery_Max = 100,
                Battery_Current = 100
            };
            //todo
            robot.ChangeState(IdleState.Instance);

            Game.RobotManager.Robots.Add( robot);
            
        }

        public List<string> AllJobs => 
            Enum.GetNames(typeof(BaseState.RobotJob)).ToList();

    }
}