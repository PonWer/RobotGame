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
        public Storage Storage { get; set; }

        #region Stats
        public int ArmSlots { get; set; }
        public float EnergyConsumption { get; set; }

        #endregion
    }
}
