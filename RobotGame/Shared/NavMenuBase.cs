using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace RobotGame.Shared
{
    public partial class NavMenuBase : ComponentBase
    {
        public bool collapseNavMenu = true;

        public string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        public void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }


    }
}
