using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace RobotGame.Shared
{
    public class Game
    {
        public int FrameCount { get; set; }

        public Player Player { get; set; }

        public event EventHandler Updated;
        public int ListenerCountOnUpdated => Updated?.GetInvocationList()?.Length ?? 0;

        private CancellationTokenSource cancellationTokenSource;
        private const int TICK_MS_INTERVAL = (1_000/4);
        private bool GameStarted = false;

        public async Task StartTickLoop()
        {
            if(GameStarted)
                return;
            GameStarted = true;

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            var task = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(TICK_MS_INTERVAL);

                    FrameCount++;
                    Updated?.Invoke(this, new EventArgs());
                }
            }, token);

            await task;
        }
        
        public Game()
        {
            Player = new Player();
        }

        public void Load(ISyncLocalStorageService localStorage)
        {
            Player.Statics.Ascended = localStorage.GetItem<int>("AscendedCount");
        }

        public void Save(ISyncLocalStorageService localStorage)
        {
            localStorage.SetItem<int>("AscendedCount", Player.Statics.Ascended);
        }

        public void FullReset(ISyncLocalStorageService localStorage)
        {
            Player.Statics.Ascended = 0;

            Save(localStorage);
        }
    }
}
