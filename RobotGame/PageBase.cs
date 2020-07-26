using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using RobotGame.Shared;

namespace RobotGame
{
    public class PageBase : ComponentBase
    {
        [Inject] public Game Game { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override Task OnInitializedAsync()
        {
            NavigationManager.LocationChanged += NavigationManagerOnLocationChanged;
            Game.Updated += GameOnUpdated;

            return base.OnInitializedAsync();
        }

        protected virtual void NavigationManagerOnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            NavigationManager.LocationChanged -= NavigationManagerOnLocationChanged;
            Game.Updated -= GameOnUpdated;
        }

        protected virtual void GameOnUpdated(object sender, EventArgs e)
        {
            StateHasChanged();
        }
    }
}
