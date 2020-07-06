using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared;

namespace RobotGame.Pages
{
    public class PlayerOverviewBase : ComponentBase
    {
        [Inject] public Game Game { get; set; }

        protected override Task OnInitializedAsync()
        {


            return base.OnInitializedAsync();
        }
    }
}
