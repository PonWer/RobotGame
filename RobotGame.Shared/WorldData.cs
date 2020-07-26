using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared
{
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

    public class Zone
    {
        public Zone(Tree inTree, OreVein inOreVein, string inName, double inEnemyDamage, double inEnemyHealth,
            double inEnemyDefense)
        {
            Tree = inTree;
            OreVein = inOreVein;
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

    }
}
