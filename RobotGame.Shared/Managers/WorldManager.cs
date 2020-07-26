using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace RobotGame.Shared.Managers
{
    public class WorldManager : ManagerBase
    {
        public static WorldManager Instance { get; } = new WorldManager();
        public readonly List<Zone> Zones;
        public WorldManager()
        {
            Zones = new List<Zone>();

            ReadWorldDataXml();
        }

        public void ReadWorldDataXml()
        {
            var reader = XElement.Parse(GetResourceFile("WorldData.xml"));
            var df = reader.Name.Namespace;
            var worldVersion = reader.Element(df + "Version").Value;

            Console.WriteLine($"Reading WorldData.xml, version:{worldVersion}");
            foreach (var zone in reader.Element(df + "Zones").Elements("Zone"))
            {
                var zoneName = zone.Element("Name").Value;
                var enemyDamage = double.Parse(zone.Element("EnemyDamage").Value);
                var enemyDefense = double.Parse(zone.Element("EnemyDefense").Value);
                var enemyHealth = double.Parse(zone.Element("EnemyHealth").Value);


                var tree = zone.Element("Tree");
                var treeHealth = int.Parse(tree.Element("Health").Value);
                var treeQuantity = int.Parse(tree.Element("Quantity").Value);

                var oreVein = zone.Element("OreVein");
                var oreVeinHealth = double.Parse(oreVein.Element("Health").Value);
                var oreVeinCopper = double.Parse(oreVein.Element("Copper").Value);
                var oreVeinIron = double.Parse(oreVein.Element("Iron").Value);
                var oreVeinLithium = double.Parse(oreVein.Element("Lithium").Value);

                Zones.Add(
                    new Zone(
                        new Tree(treeHealth, treeQuantity),
                        new OreVein(oreVeinCopper, oreVeinIron, oreVeinLithium, oreVeinHealth),
                        zoneName,
                        enemyDamage,
                        enemyHealth,
                        enemyDefense
                    ));
            }
        }

        public List<string> AllZoneNames => Zones.Select(x => x.Name).ToList();

        public override void PreRenderUpdate()
        {
            throw new NotImplementedException();
        }

        public override void PostRenderUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
