using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace RobotGame.Shared.Robot.Parts
{
    public class Battery : ComponentBase
    {
        public double Current { get; set; }
        public double Max => Effect.MaxCharge;
        public string BatteryPercentage => $"{(int)(Current / Effect.MaxCharge * 100)}%";
        public override ComponentType GetComponentType() => ComponentType.Battery;
    }
}
