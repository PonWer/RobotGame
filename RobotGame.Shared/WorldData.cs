using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared
{
    public class ActivityChances
    {
        public readonly int Empty;
        public readonly int Tree;
        public readonly int OreVein;
        public readonly int Scrap;
        public readonly int Enemy;

        public ActivityChances(int inEmpty, int inTree, int inOreVein, int inScrap, int inEnemy)
        {
            Empty = inEmpty;

            Tree = inTree;
            OreVein = inOreVein;
            Scrap = inScrap;
            Enemy = inEnemy;

            if (Tree + OreVein + Scrap + Enemy != 100)
            {
                throw new Exception("Tree + OreVein + Scrap + Enemy chance must equal 100");
            }
        }
    }

    public class OreVein
    {
        public OreVein(double inCopper, double inIron, double inLithium, double inHealth)
        {
            Copper = inCopper;
            Iron = inIron;
            Lithium = inLithium;
            Health = inHealth;
        }

        public readonly double Copper;
        public readonly double Iron;
        public readonly double Lithium;
        public readonly double Health;
    }

    public class Tree
    {
        public Tree(int inHealth, int inQuantity)
        {
            Health = inHealth;
            Quantity = inQuantity;
        }

        public readonly int Health;
        public readonly int Quantity;

    }

    public class Scrap
    {
        public Scrap(int inHealth, int inQuantity)
        {
            Health = inHealth;
            Quantity = inQuantity;
        }

        public readonly int Health;
        public readonly int Quantity;

    }

    public class Zone
    {
        public Zone(Tree inTree, OreVein inOreVein, Scrap inScrap, string inName, double inEnemyDamage, double inEnemyHealth,
            double inEnemyDefense)
        {
            Tree = inTree;
            OreVein = inOreVein;
            Scrap = inScrap;
            Name = inName;
            EnemyDamage = inEnemyDamage;
            EnemyHealth = inEnemyHealth;
            EnemyDefense = inEnemyDefense;

        }

        public readonly string Name;

        public readonly double EnemyDamage;
        public readonly double EnemyHealth;
        public readonly double EnemyDefense;

        public readonly OreVein OreVein;
        public readonly Tree Tree;
        public readonly Scrap Scrap;

    }
}
