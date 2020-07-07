using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared.PlayerComponents;

namespace RobotGame.Pages.Statistics
{
    public partial class PlayerLogDetailBase : PageBase
    {
        [Parameter] public string LogId { get; set; }
        [Inject] public ISyncLocalStorageService LocalStorage { get; set; }
        
        public LogEntry CurrentLogEntry { get; set; }

        protected override Task OnInitializedAsync()
        {
            var count = LocalStorage.GetItem<string>("count");

            CurrentLogEntry = new LogEntry()
            {
                Text = count??="A",
                Time = DateTime.MinValue
            };

            count += "A";

            LocalStorage.SetItem("count", count);
            

            return base.OnInitializedAsync();
        }
    }
}
