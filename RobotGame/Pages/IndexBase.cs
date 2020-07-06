using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared;
using RobotGame.Shared.PlayerComponents;

namespace RobotGame.Pages
{
    public partial class IndexBase : PageBase
    {
        [Inject] public ISyncLocalStorageService LocalStorage { get; set; }

        protected override Task OnInitializedAsync()
        {
            Game.StartTickLoop();

            return base.OnInitializedAsync();
        }
    }
}
