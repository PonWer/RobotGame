using System;
using System.Collections.Generic;
using System.Globalization;
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
            var xNamespace = reader.Name.Namespace;
            var worldVersion = reader.Element(xNamespace + "Version").Value;

            Console.WriteLine($"Reading WorldData.xml, version:{worldVersion}");
            foreach (var zone in reader.Element(xNamespace + "Zones").Elements("Zone"))
            {

                var zoneName = zone.Element("Name").Value;
                var enemyDamage = GetDoubleValue(zone, "EnemyDamage");
                var enemyDefense = GetDoubleValue(zone, "EnemyDefense");
                var enemyHealth = GetDoubleValue(zone, "EnemyHealth");


                var tree = zone.Element("Tree");
                var treeHealth = GetIntValue(tree, "FrameHealth");
                var treeQuantity = GetIntValue(tree, "Quantity");

                var oreVein = zone.Element("OreVein");
                var oreVeinHealth = GetDoubleValue(zone, "FrameHealth");
                var oreVeinCopper = GetDoubleValue(zone, "Copper"); 
                var oreVeinIron = GetDoubleValue(zone, "Iron");
                var oreVeinLithium = GetDoubleValue(zone, "Lithium");

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
