using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Robot.Parts
{
    public class Frame : ComponentBase
    {
        public double HealthCurrent;
        public double FrameHealthMax => Effect.FrameHealth;
        public override ComponentType GetComponentType() => ComponentType.Frame;
        public string HealthPercentage => $"{(int)(HealthCurrent / Effect.FrameHealth * 100)}%";
    }
}
