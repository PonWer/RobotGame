using RobotGame.Shared;
using RobotGame.Shared.Managers;

namespace RobotGame.Pages.DevDebug
{
    public class DebugBase : PageBase
    {
        public void OnAdd100ToAllResourcesButton()
        {
            ResourceManager.Instance.Energy += 100;
            ResourceManager.Instance.Wood += 100;
            ResourceManager.Instance.Iron += 100;
            ResourceManager.Instance.Copper += 100;
            ResourceManager.Instance.Lithium += 100;
            ResourceManager.Instance.Scrap += 100;
        }


    }
}
