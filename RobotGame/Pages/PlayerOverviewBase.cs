using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared;
using RobotGame.Shared.Player;

namespace RobotGame.Pages
{
    public class PlayerOverviewBase : ComponentBase
    {
        public Data data = new Data();

        protected override Task OnInitializedAsync()
        {
            data.Name = "overriden";
            data.Logs = new List<LogEntry>()
            {
                new LogEntry()
                {
                    Text = "Yesterday",
                    Time = DateTime.Today.AddDays(-1)
                },
                new LogEntry()
                {
                    Text = "Today",
                    Time = DateTime.Today
                },
                new LogEntry()
                {
                    Text = "Tomorrow",
                    Time = DateTime.Today.AddDays(1)
                }
            };

            data.PlayerStatics = new Statics()
            {
                Ascended = 12,
                CollectedBolts = 1234
            };

            return base.OnInitializedAsync();
        }
    }
}
