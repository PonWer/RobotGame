using System;
using System.Collections.Generic;
using System.Linq;
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
                    Name = "Home"
                },

                new Zone()
                {
                    Name = "StartingZone",

                    EnemyDamage = 1,
                    EnemyDefense = 0,
                    EnemyHealth = 2,

                    OreVein = new OreVein()
                    {
                        Health = 3,
                        Copper = 0.1f,
                        Iron = 0.9f,
                        Lithium = 0.0f
                    },

                    Tree = new Tree()
                    {
                        Health = 6,
                        Quantity = 5
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
                        Health = 5,
                        Copper = 0.6f,
                        Iron = 0.3f,
                        Lithium = 0.1f
                    },

                    Tree = new Tree()
                    {
                        Health = 10,
                        Quantity = 20
                    }
                },
            };
        }

        public List<string> AllZoneNames => Zones.Select(x => x.Name).ToList();

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
