using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGame.Shared
{
    public class WorldManager : IGameLoop
    {
        public static WorldManager Instance { get; } = new WorldManager();
        public readonly List<Zone> Zones;
        public WorldManager()
        {
            Zones = new List<Zone>()
            {
                new Zone()
                {
                    Name = "StartingZone",

                    EnemyDamage = 1,
                    EnemyDefense = 0,
                    EnemyHealth = 2,

                    OreVein = new OreVein()
                    {
                        Copper = 0.1f,
                        Iron = 0.9f,
                        Lithium = 0.0f
                    },

                    Tree = new Tree()
                    {
                        DamageNeededPerWood = 1,
                        WoodPerTree = 3
                    }
                },

                new Zone()
                {
                    Name = "NoobieZone",

                    EnemyDamage = 5,
                    EnemyDefense = 2,
                    EnemyHealth = 10,

                    OreVein = new OreVein()
                    {
                        Copper = 0.6f,
                        Iron = 0.3f,
                        Lithium = 0.1f
                    },

                    Tree = new Tree()
                    {
                        DamageNeededPerWood = 2,
                        WoodPerTree = 5
                    }
                },
            };
        }

        public void PreRenderUpdate()
        {
            throw new NotImplementedException();
        }

        public void PostRenderUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
