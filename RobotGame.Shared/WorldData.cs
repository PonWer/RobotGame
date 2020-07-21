using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared
{
    public class OreVein
    {
        public float Iron { get; set; }
        public float Copper { get; set; }
        public float Lithium { get; set; }
        public float Health { get; set; }
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
