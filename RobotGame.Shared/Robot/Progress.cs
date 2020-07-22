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

        public int TreeChance { get; private set; }
        public int OreVeinChance { get; private set; }
        public int EnemyChance { get; private set; }

        private Zone CurrentZone { get; set; }


        public Progress(int treeChance, int oreVeinChance, int enemyChance, Zone inZone)
        {
            if (treeChance + oreVeinChance + enemyChance != 100)
            {
                throw new Exception("All chances dont equal 100");
            }

            TreeChance = treeChance;
            OreVeinChance = oreVeinChance;
            EnemyChance = enemyChance;
            CurrentZone = inZone;
            
            Path = new List<Obstacle>();
            for (var i = 0; i < 20; i++)
            {
                Path.Add(GetNextPathItem());
            }
        }

        private Obstacle GetNextPathItem()
        {
            var rand = new Random();

            if (rand.Next(100) >= 30) 
                return Obstacle.Empty;

            var chance = rand.Next(100);
            if (chance < TreeChance)
            {
                return Obstacle.Tree;
            }
            return chance < TreeChance + OreVeinChance ? 
                Obstacle.OreVein : 
                Obstacle.Enemy;
        }

        public enum Obstacle
        {
            Empty,
            Tree,
            OreVein,
            Enemy
        }



        public bool AttackAndMove(double inDamage, out double DamageTaken, out Obstacle outObstacle)
        {
            outObstacle = Path[0];
            DamageTaken = 0;

            if (Path[0] == Obstacle.Empty)
            {
                StepsTaken++;
                Path.RemoveAt(0);
                Path.Add(GetNextPathItem());
                return false;
            }

            if (ClosestObjectHealth <= 0 && outObstacle != Obstacle.Empty)
            {
                //New obstacle
                switch (outObstacle)
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
                    default:
                        throw new ArgumentOutOfRangeException(nameof(outObstacle), outObstacle, null);
                }
            }

            ClosestObjectHealth -= inDamage;

            if (outObstacle == Obstacle.Enemy)
            {
                DamageTaken = CurrentZone.EnemyDamage;
            }

            if (ClosestObjectHealth <= 0)
            {
                Path[0] = Obstacle.Empty;
                return true;
            }
            return false;
        }
    }
}
