using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Robot.Parts
{
    public class Frame
    {
        
        public List<Arm> Arms { get; set; }
        public Mobility Mobility { get; set; }
        public Battery Battery { get; set; }
        public Storage Storage { get; set; } = new Storage();

        #region Stats
        public int ArmSlots { get; set; }
        public double EnergyConsumption { get; set; }

        #endregion
    }
}
