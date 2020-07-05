using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared;
using RobotGame.Shared.Player;

namespace RobotGame.Pages
{
    public class PlayerLogDetailBase : ComponentBase
    {
        [Parameter]
        public string LogId { get; set; }

        public LogEntry CurrentLogEntry { get; set; }

        protected override Task OnInitializedAsync()
        {
            CurrentLogEntry = new LogEntry()
            {
                Text = "Test",
                Time = DateTime.MinValue
            };



            return base.OnInitializedAsync();
        }
    }
}
