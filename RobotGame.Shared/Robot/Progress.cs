using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared.Robot
{
    public class Progress
    {
        public List<Obstacle> Path;
        public int StepsTaken { get; set; }

        public double ClosestObjectHealth;

        private Zone CurrentZone { get; set; }

        private ActivityChances Chance { get; set; }

        public Progress(Zone inZone, ActivityChances inChances)
        {
            CurrentZone = inZone;
            Chance = inChances;
            
            Path = new List<Obstacle>();
            for (var i = 0; i < 20; i++)
            {
                Path.Add(Obstacle.Empty);
            }
        }

        private Obstacle GetNextPathItem()
        {
            var rand = new Random();

            if (rand.Next(100) < Chance.Empty) 
                return Obstacle.Empty;

            var chance = rand.Next(100);
            if (chance < Chance.Tree)
            {
                return Obstacle.Tree;
            }

            if (chance < Chance.Tree + Chance.OreVein)
                return Obstacle.OreVein;

            return chance < Chance.Tree + Chance.OreVein + Chance.Scrap ? 
                Obstacle.Scrap : 
                Obstacle.Enemy;
        }

        public enum Obstacle
        {
            Empty,
            Tree,
            OreVein,
            Scrap,
            Enemy
        }


        public void Move()
        {
            StepsTaken++;
            Path.RemoveAt(0);
            Path.Add(GetNextPathItem());

            switch (Path[0])
            {
                case Obstacle.Empty:
                    break;
                case Obstacle.Tree:
                    ClosestObjectHealth = CurrentZone.Tree.Health;
                    break;
                case Obstacle.OreVein:
                    ClosestObjectHealth = CurrentZone.OreVein.Health;
                    break;
                case Obstacle.Enemy:
                    ClosestObjectHealth = CurrentZone.EnemyHealth;
                    break;
                case Obstacle.Scrap:
                    ClosestObjectHealth = CurrentZone.Scrap.Health;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
