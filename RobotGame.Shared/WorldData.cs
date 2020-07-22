using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared
{
    public class OreVein
    {
        public double Iron { get; set; }
        public double Copper { get; set; }
        public double Lithium { get; set; }
        public double Health { get; set; }
    }

    public class Tree
    {
        public int Health { get; set; }
        public int Quantity { get; set; }

    }

    public class Zone
    {
        public string Name { get; set; }

        public int EnemyDamage { get; set; }
        public int EnemyHealth { get; set; }
        public int EnemyDefense { get; set; }

        public OreVein OreVein { get; set; }
        public Tree Tree { get; set; }

    }
}
