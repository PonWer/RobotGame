using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace RobotGame.Shared.Robot.Parts
{
    public class Battery : ComponentBase
    {
        public double CurrentValue { get; set; }
        public double MaxValue { get; set; }

        public override ComponentType GetComponentType() => ComponentType.Battery;
    }
}
