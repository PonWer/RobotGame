using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using RobotGame.Shared.Robot;

namespace RobotGame.Shared.Managers
{
    public class RobotManager : ManagerBase
    {
        public static RobotManager Instance { get; } = new RobotManager();

        public List<Component> AllComponents = new List<Component>();

        public List<Robot.Robot> Robots { get; set; }
        
        public RobotManager()
        {
            Robots = new List<Robot.Robot>();

            ReadRobotComponentsDataXml();
        }

        public void ReadRobotComponentsDataXml()
        {
            var reader = XElement.Parse(GetResourceFile("RobotComponents.xml"));
            var xNamespace = reader.Name.Namespace;
            var worldVersion = reader.Element(xNamespace + "Version").Value;
            

            Console.WriteLine($"Reading RobotComponents.xml, version:{worldVersion}");

            ReadArray(xNamespace, reader, "Arms", "Arm", Component.ComponentType.Arm);
            ReadArray(xNamespace, reader, "Batteries", "Battery", Component.ComponentType.Battery);
            ReadArray(xNamespace, reader, "Frames", "Frame", Component.ComponentType.Frame);
            ReadArray(xNamespace, reader, "Mobilities", "Mobility", Component.ComponentType.Mobility);
            ReadArray(xNamespace, reader, "Storages", "Storage", Component.ComponentType.Storage);

            foreach (var component in AllComponents.Where( x => x.UnlockIndex == 0))
            {
                component.Researched = true;
                component.QtyBuilt = 100;
            }
        }

        private void ReadArray(XNamespace inNamespace, XElement inNode, string inArrayName, string inItemName,
            Component.ComponentType inType)
        {
            foreach (var arm in inNode.Element(inNamespace + inArrayName).Elements(inItemName))
            {
                var subType = GetStringValue(arm, "SubType");
                var material = GetStringValue(arm, "Material");
                var unlockIndex = GetIntValue(arm, "UnlockIndex");
                var cost = GetCost(arm);
                var effect = GetEffect(arm);

                AllComponents.Add(
                    new Component()
                    {
                        Type = inType,
                        SubType = subType,
                        Material = material,
                        UnlockIndex = unlockIndex,
                        Cost = cost,
                        Effect = effect
                    });
            }
        }

        private Cost GetCost(XElement arm)
        {
            var cost = arm.Element("Cost");
            var costResearchPoints = GetIntValue(cost, "ResearchPoints");
            var costWood = GetIntValue(cost, "Wood");
            var costCopper = GetIntValue(cost, "Copper");
            var costIron = GetIntValue(cost, "Iron");
            var costLithium = GetIntValue(cost, "Lithium");

            return new Cost()
            {
                ResearchPoints = costResearchPoints,
                Copper = costCopper,
                Wood = costWood,
                Iron = costIron,
                Lithium = costLithium
            };
        }



        private Effect GetEffect(XElement arm)
        {
            var effect = arm.Element("Effect");
            var effectAttackDamage = GetDoubleValue(effect, "AttackDamage");
            var effectWoodcutterDamage = GetDoubleValue(effect, "WoodcutterDamage");
            var effectEnergyConsumption = GetDoubleValue(effect, "EnergyConsumption");
            var effectMaxCharge = GetDoubleValue(effect, "MaxCharge");
            var effectChargingSpeed = GetDoubleValue(effect, "ChargingSpeed");
            var effectStorageSize = GetDoubleValue(effect, "StorageSize");
            var effectSpeed = GetDoubleValue(effect, "Speed");
            var effectHealth = GetDoubleValue(effect, "FrameHealth");
            var effectDefense = GetDoubleValue(effect, "FrameDefense");

            return new Effect()
            {
                AttackDamage = effectAttackDamage,
                FrameHealth = effectHealth,
                FrameDefense = effectDefense,
                Speed = effectSpeed,
                StorageSize = effectStorageSize,
                ChargingSpeed = effectChargingSpeed,
                EnergyConsumption = effectEnergyConsumption,
                WoodcutterDamage = effectWoodcutterDamage,
                MaxCharge = effectMaxCharge
            };
        }

        public override void PreRenderUpdate()
        {
            Console.WriteLine($"Robots.Count: {Robots.Count}");

            foreach (var robot in Robots)
            {
                robot.PreRenderUpdate();
            }
        }

        public override void PostRenderUpdate()
        {
            
        }
    }
}
