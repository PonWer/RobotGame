using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using RobotGame.Shared.Managers;
using RobotGame.Shared.PlayerComponents;

namespace RobotGame.Shared
{
    public interface IGameLoop
    {
        void PreRenderUpdate();
        void PostRenderUpdate();
    }

    public class Game : IGameLoop
    {
        #region DebugInfo
        public int FrameCount { get; set; }
        public List<string> ListenerOnUpdated => Updated?.GetInvocationList()?.Select( x => x.Target.ToString()).ToList();
        #endregion


        public Player Player { get; set; }

        public ResourceManager ResourceManager { get; private set; }

        public RobotManager RobotManager { get; private set; }
        
        #region GameLoop

        public event EventHandler Updated;
        private CancellationTokenSource cancellationTokenSource;
        private const int TICK_MS_INTERVAL = (1_000 / 5);
        private bool GameStarted = false;

        public async Task StartTickLoop()
        {
            if (GameStarted)
                return;
            GameStarted = true;

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            var task = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(TICK_MS_INTERVAL);

                    PreRenderUpdate();
                    Updated?.Invoke(this, new EventArgs());
                    PostRenderUpdate();
                }
            }, token);

            await task;
        }

        #endregion

        public void PreRenderUpdate()
        {
            RobotManager.PreRenderUpdate();
            ResourceManager.PreRenderUpdate();
        }

        public void PostRenderUpdate()
        {
            FrameCount++;

            RobotManager.PostRenderUpdate();
        }

        public Game()
        {
            Player = new Player();

            ResourceManager = ResourceManager.Instance;
            RobotManager = RobotManager.Instance;
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
