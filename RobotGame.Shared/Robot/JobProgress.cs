using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Robot
{
    public class JobProgress
    {
        public JobProgress(Obstacle obstacle, float obstacleHealth)
        {
            ObstacleHealth = obstacleHealth;
            ClosestObjectHealth = ObstacleHealth;
            ObstacleType = obstacle;
            
            PlaceOccupied = new List<bool>();
            for (var i = 0; i < 10; i++)
            {
                PlaceOccupied.Add(i % 5 == 4);
            }
        }
        public enum Obstacle
        {
            Tree,
            OreVein,
            Enemy
        }

        public List<bool> PlaceOccupied;
        public int StepsTaken { get; set; }

        public Obstacle ObstacleType { get; set; }

        public readonly float ObstacleHealth;
        public float ClosestObjectHealth;

        public bool AttackAndMove(float Damage)
        {
            if (!PlaceOccupied[0])
            {
                MovePlayer();
                return false;
            }

            ClosestObjectHealth -= Damage;
            if (ClosestObjectHealth <= 0)
            {
                MovePlayer();
                ClosestObjectHealth = ObstacleHealth;
                return true;
            }

            return false;
        }
        
        public void MovePlayer()
        {
            StepsTaken++;
            PlaceOccupied.RemoveAt(0);
            PlaceOccupied.Add(StepsTaken % 5==4);
        }
    }
}
