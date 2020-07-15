using System;
using System.Collections.Generic;
using System.Text;
using RobotGame.Shared.PlayerComponents;

namespace RobotGame.Shared
{
    public class Player
    {
        

        public Statics Statics { get; private set; }

        public List<LogEntry> LogEntries { get; private set; }

        public Player()
        {
            Statics = new Statics()
            {
                Ascended = 1,
                CollectedBolts = 2
            };

            LogEntries = new List<LogEntry>()
            {
                new LogEntry()
                {
                    Text = "PlayerLogEntries1",
                    Time = DateTime.Today.AddDays(-1)
                },
                new LogEntry()
                {
                    Text = "PlayerLogEntries2",
                    Time = DateTime.Today.AddDays(0)
                },
                new LogEntry()
                {
                    Text = "PlayerLogEntries3",
                    Time = DateTime.Today.AddDays(1)
                }
            };
        }
    }
}
