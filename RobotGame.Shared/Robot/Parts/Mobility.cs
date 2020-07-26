using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Robot.Parts
{
    public class Mobility : ComponentBase
    {
        public double Speed { get; set; }

        public override ComponentType GetComponentType() => ComponentType.Mobility;
    }
}
