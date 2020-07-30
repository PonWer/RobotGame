using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared.Managers;
using RobotGame.Shared.Robot.States;

namespace RobotGame.Shared.Robot
{
    public class Robot
    {
        public BaseState CurrentState { get; private set; }
        public BaseState PreviousState { get; private set; }

        public Zone CurrentZone { get; set; }
        public Progress CurrentProgress { get; set; }

        #region Body
        private Component _frame;
        public Component Frame
        {
            get => _frame;
            set
            {
                _frame.Detach(this);
                _frame = value;
                _frame.Attach(this);
            }
        }

        private List<Component> _arms;
        public List<Component> Arms
        {
            get => _arms;
            set
            {
                _arms?.ForEach(x => x.Detach(this));
                _arms = value;
                _arms?.ForEach( x => x.Attach(this));
            }
        }

        private Component _mobility;
        public Component Mobility
        {
            get => _mobility;
            set
            {
                _mobility.Detach(this);
                _mobility = value;
                _mobility.Attach(this);
            }
        }

        private Component _battery;
        public Component Battery
        {
            get => _battery;
            set
            {
                _battery.Detach(this);
                _battery = value;
                _battery.Attach(this);
            }
        }

        private Component _storage;
        public Component Storage
        {
            get => _storage;
            set
            {
                _storage.Detach(this);
                _storage = value;
                _storage.Attach(this);
            }
        }
        #endregion

        #region Battery
        public double BatteryCurrent { get; set; }
        public double BatteryMax => Battery.Effect.MaxCharge;
        public string BatteryPercentage => $"{(int)(BatteryCurrent / BatteryMax * 100)}%";
        #endregion

        #region Health
        public double HealthCurrent;
        public double HealthMax => Frame.Effect.FrameHealth;
        public string HealthPercentage => $"{(int)(HealthCurrent / HealthMax * 100)}%";
        #endregion

        #region Storage
        public double MaxStorage => Storage.Effect.StorageSize;
        public bool StorageIsFull => (Wood + Iron + Lithium + Copper + Scrap) >= MaxStorage;

        public double Wood { get; set; }
        public string WoodPercentage => $"{Wood / MaxStorage * 100}%";
        public double Iron { get; set; }
        public string IronPercentage => $"{Iron / MaxStorage * 100}%";
        public double Lithium { get; set; }
        public string LithiumPercentage => $"{Lithium / MaxStorage * 100}%";
        public double Copper { get; set; }
        public string CopperPercentage => $"{Copper / MaxStorage * 100}%";
        public int Scrap { get; set; }
        public string ScrapPercentage => $"{Scrap / MaxStorage * 100}%";

        public void EmptyStorage()
        {
            ResourceManager.Instance.AddResource(Wood, Copper, Iron, Lithium, Scrap);

            Wood = 0;
            Iron = 0;
            Lithium = 0;
            Copper = 0;
            Scrap = 0;
        }
        #endregion

        public bool ReturnToPreviousStateOnMaxBattery;
        
        public void PreRenderUpdate()
        {
            CurrentState?.OnStateUpdate(this);
        }

        public void ChangeState(BaseState newState)
        {
            CurrentState?.OnStateLeave(this);

            PreviousState = CurrentState;
            CurrentState = newState;

            CurrentState.OnStateEnter(this);
        }

        public void OnSelectedJobChange(ChangeEventArgs e)
        {
            var selectedString = e.Value.ToString();

            ChangeState(BaseState.GetState(selectedString));
        }

        public void OnSelectedZoneChange(ChangeEventArgs e)
        {
            var selectedString = e.Value.ToString();

            CurrentZone = WorldManager.Instance.Zones.First(x => x.Name == selectedString);
            ChangeState(CurrentState);
        }

        public void AddLootToStorage(Progress.Obstacle inObstacle)
        {
            switch (inObstacle)
            {
                case Progress.Obstacle.Empty:
                    break;
                case Progress.Obstacle.Tree:
                    Wood += CurrentZone.Tree.Quantity;
                    break;
                case Progress.Obstacle.OreVein:
                    Iron += CurrentZone.OreVein.Iron;
                    Copper += CurrentZone.OreVein.Copper;
                    Lithium += CurrentZone.OreVein.Lithium;
                    break;
                case Progress.Obstacle.Enemy:
                    break;
                case Progress.Obstacle.Scrap:
                    Scrap += CurrentZone.Scrap.Quantity;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ProgressTheProgress()
        {
            if (CurrentProgress.Path[0] == Progress.Obstacle.Empty)
            {
                CurrentProgress.Move();
                BatteryCurrent -= 0.1f;
                return;
            }

            BatteryCurrent -= 0.5f;
            if (CurrentProgress.Path[0] == Progress.Obstacle.Enemy)
            {
                var damage = Arms[0].Effect.AttackDamage - CurrentZone.EnemyDefense;
                CurrentProgress.ClosestObjectHealth -= damage > 0 ? damage : 0;
                HealthCurrent -= CurrentZone.EnemyDamage;
            }
            else
            {
                CurrentProgress.ClosestObjectHealth -= 1;
            }

            if (CurrentProgress.ClosestObjectHealth < 0)
            {
                AddLootToStorage(CurrentProgress.Path[0]);
                CurrentProgress.Path[0] = Progress.Obstacle.Empty;
            }
        }
    }
}