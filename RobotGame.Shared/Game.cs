﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;

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
        public int ListenerCountOnUpdated => Updated?.GetInvocationList()?.Length ?? 0;
        #endregion


        public Player Player { get; set; }

        public RobotManager RobotManager { get; private set; }
        
        #region GameLoop

        public event EventHandler Updated;
        private CancellationTokenSource cancellationTokenSource;
        private const int TICK_MS_INTERVAL = (1_000 / 4);
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
        }

        public void PostRenderUpdate()
        {
            FrameCount++;

            RobotManager.PostRenderUpdate();
        }

        public Game()
        {
            Player = new Player();

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
