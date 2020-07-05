using System.Collections.Generic;

namespace RobotGame.Shared.Player
{
    public partial class Data
    {
        public string Name { get; set; }

        public int Points { get; set; }

        public List<LogEntry> Logs { get; set; }

        public Statics PlayerStatics { get; set; }
    }
}

