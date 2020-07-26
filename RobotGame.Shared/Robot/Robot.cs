using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared.Managers;
using RobotGame.Shared.Robot.Parts;
using RobotGame.Shared.Robot.States;

namespace RobotGame.Shared.Robot
{
    public class Robot
    {
        public BaseState CurrentState { get; private set; }
        public BaseState PreviousState { get; private set; }

        public Zone CurrentZone { get; set; }
        public Progress CurrentProgress { get; set; }
        public Frame Frame { get; set; } = new Frame();

        public double AttackDamage { get; set; } = 1.2f;
        public double HealthCurrent { get; set; }
        public double Health_Max { get; set; }

        public double Battery_Current { get; set; }
        public double Battery_Max { get; set; }
        public string BatteryPercentage => $"{(int)(Battery_Current / Battery_Max * 100)}%";
        public bool ReturnToPreviousStateOnMaxBattery;
        public string HealthPercentage => $"{(int)(HealthCurrent / Health_Max * 100)}%";

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
                    Frame.Storage.Wood += CurrentZone.Tree.Quantity;
                    break;
                case Progress.Obstacle.OreVein:
                    Frame.Storage.Iron += CurrentZone.OreVein.Iron;
                    Frame.Storage.Copper += CurrentZone.OreVein.Copper;
                    Frame.Storage.Lithium += CurrentZone.OreVein.Lithium;
                    break;
                case Progress.Obstacle.Enemy:
                    //Todo
                    Frame.Storage.Scrap += CurrentZone.Tree.Quantity;
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
                Battery_Current -= 0.1f;
                return;
            }

            Battery_Current -= 0.5f;
            if (CurrentProgress.Path[0] == Progress.Obstacle.Enemy)
            {
                var damage = AttackDamage - CurrentZone.EnemyDefense;
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