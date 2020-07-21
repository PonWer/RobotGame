using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace RobotGame.Shared
{
    public partial class NavMenuBase : ComponentBase
    {
        [Inject] public Game Game { get; set; }
        
        protected override Task OnInitializedAsync()
        {
            Game.StartTickLoop();

            return base.OnInitializedAsync();
        }
    }
}
