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

        public ActivityChances WoodcuttingActivity;
        public ActivityChances MiningActivity;
        public ActivityChances ScavengingActivity;

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
            var activities = reader.Element(xNamespace + "Activities");

            var wA = activities.Element("Woodcutting");
            var waEmpty = GetIntValue(wA, "EmptyChance");
            var waEnemy = GetIntValue(wA, "EnemyChance");
            var waTree = GetIntValue(wA, "TreeChance");
            var waOreVein = GetIntValue(wA, "OreVeinChance");
            var waScrap = GetIntValue(wA, "ScrapChance");
            WoodcuttingActivity = new ActivityChances(waEmpty,waTree,waOreVein,waScrap,waEnemy);

            var mA = activities.Element("Mining");
            var maEmpty = GetIntValue(mA, "EmptyChance");
            var maEnemy = GetIntValue(mA, "EnemyChance");
            var maTree = GetIntValue(mA, "TreeChance");
            var maOreVein = GetIntValue(mA, "OreVeinChance");
            var maScrap = GetIntValue(mA, "ScrapChance");
            MiningActivity = new ActivityChances(maEmpty, maTree, maOreVein, maScrap, maEnemy);

            var sA = activities.Element("Scavenging");
            var saEmpty = GetIntValue(sA, "EmptyChance");
            var saEnemy = GetIntValue(sA, "EnemyChance");
            var saTree = GetIntValue(sA, "TreeChance");
            var saOreVein = GetIntValue(sA, "OreVeinChance");
            var saScrap = GetIntValue(sA, "ScrapChance");
            ScavengingActivity = new ActivityChances(saEmpty, saTree, saOreVein, saScrap, saEnemy);

            Console.WriteLine($"Reading WorldData.xml, version:{worldVersion}");
            foreach (var zone in reader.Element(xNamespace + "Zones").Elements("Zone"))
            {
                var zoneName = zone.Element("Name").Value;

                var enemy = zone.Element("Enemy");
                var enemyDamage = GetDoubleValue(enemy, "Damage");
                var enemyDefense = GetDoubleValue(enemy, "Defense");
                var enemyHealth = GetDoubleValue(enemy, "Health");

                var tree = zone.Element("Tree");
                var treeHealth = GetIntValue(tree, "Health");
                var treeQuantity = GetIntValue(tree, "Quantity");

                var scrap = zone.Element("Scrap");
                var scrapHealth = GetIntValue(scrap, "Health");
                var scrapQuantity = GetIntValue(scrap, "Quantity");

                var oreVein = zone.Element("OreVein");
                var oreVeinHealth = GetDoubleValue(oreVein, "Health");
                var oreVeinCopper = GetDoubleValue(oreVein, "Copper"); 
                var oreVeinIron = GetDoubleValue(oreVein, "Iron");
                var oreVeinLithium = GetDoubleValue(oreVein, "Lithium");

                Zones.Add(
                    new Zone(
                        new Tree(treeHealth, treeQuantity),
                        new OreVein(oreVeinCopper, oreVeinIron, oreVeinLithium, oreVeinHealth),
                        new Scrap(scrapHealth,scrapQuantity), 
                        zoneName,
                        enemyDamage,
                        enemyHealth,
                        enemyDefense
                    ));
            }
        }

        private List<string> _allZoneNames;
        public List<string> AllZoneNames()
        {
            return _allZoneNames ?? (_allZoneNames = Zones.Select(x => x.Name).ToList());
        }

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
