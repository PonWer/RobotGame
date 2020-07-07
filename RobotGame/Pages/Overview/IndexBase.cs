using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace RobotGame.Pages.Overview
{
    public partial class IndexBase : PageBase
    {
        [Inject] public ISyncLocalStorageService LocalStorage { get; set; }

        protected override Task OnInitializedAsync()
        {
            

            return base.OnInitializedAsync();
        }
    }
}
