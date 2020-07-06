using System;
using System.Collections.Generic;
using System.Text;
using Blazored.LocalStorage;

namespace RobotGame.Shared
{
    public class Game
    {
        public Player Player { get; set; }

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
