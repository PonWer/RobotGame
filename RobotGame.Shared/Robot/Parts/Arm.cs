using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Robot.Parts
{
    public class Arm : ComponentBase
    {
        public double MiningDamage { get; set; }
        public override ComponentType GetComponentType() => ComponentType.Arm;
    }
}
