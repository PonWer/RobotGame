using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Routing;

namespace RobotGame.Shared
{
    public class TopBarBase : PageBase
    {
        public static TopBarBase Instance { get; private set; }

        protected override Task OnInitializedAsync()
        {
            if (Instance != null)
            {
                Game.Updated -= GameOnUpdated;
            }

            Instance = this;
            Game.Updated += GameOnUpdated;

            return base.OnInitializedAsync();
        }

        public string DoubleToTwoDecimals(double inValue)
        {
            return inValue.ToString("0.##");
        }
    }
}
