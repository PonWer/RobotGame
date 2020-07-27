using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using RobotGame.Shared.Robot.Parts;

namespace RobotGame.Shared.Managers
{
    public class RobotManager : ManagerBase
    {
        public static RobotManager Instance { get; } = new RobotManager();

        public List<ComponentBase> AllComponents = new List<ComponentBase>();
        public List<ComponentBase> UnlockedComponents = new List<ComponentBase>();
        public List<ComponentBase> BuiltComponents = new List<ComponentBase>();

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
            foreach (var arm in reader.Element(xNamespace + "Arms").Elements("Arm"))
            {
                var type = GetStringValue(arm, "Type");
                var material = GetStringValue(arm, "Material");
                var unlockIndex = GetIntValue(arm, "UnlockIndex");
                var cost = GetCost(arm);
                var effect = GetEffect(arm);

                AllComponents.Add(
                    new Arm()
                    {
                        Type = type,
                        Material = material,
                        UnlockIndex = unlockIndex,
                        Cost = cost,
                        Effect = effect
                    });
            }

            foreach (var battery in reader.Element(xNamespace + "Batteries").Elements("Battery"))
            {
                var type = GetStringValue(battery, "Type");
                var material = GetStringValue(battery, "Material");
                var unlockIndex = GetIntValue(battery, "UnlockIndex");
                var cost = GetCost(battery);
                var effect = GetEffect(battery);

                AllComponents.Add(
                    new Battery()
                    {
                        Type = type,
                        Material = material,
                        UnlockIndex = unlockIndex,
                        Cost = cost,
                        Effect = effect
                    });
            }

            foreach (var frame in reader.Element(xNamespace + "Frames").Elements("Frame"))
            {
                var type = GetStringValue(frame, "Type");
                var material = GetStringValue(frame, "Material");
                var unlockIndex = GetIntValue(frame, "UnlockIndex");
                var cost = GetCost(frame);
                var effect = GetEffect(frame);

                AllComponents.Add(
                    new Frame()
                    {
                        Type = type,
                        Material = material,
                        UnlockIndex = unlockIndex,
                        Cost = cost,
                        Effect = effect
                    });
            }

            foreach (var mobility in reader.Element(xNamespace + "Mobilities").Elements("Mobility"))
            {
                var type = GetStringValue(mobility, "Type");
                var material = GetStringValue(mobility, "Material");
                var unlockIndex = GetIntValue(mobility, "UnlockIndex");
                var cost = GetCost(mobility);
                var effect = GetEffect(mobility);

                AllComponents.Add(
                    new Mobility()
                    {
                        Type = type,
                        Material = material,
                        UnlockIndex = unlockIndex,
                        Cost = cost,
                        Effect = effect
                    });
            }

            foreach (var storage in reader.Element(xNamespace + "Storages").Elements("Storage"))
            {
                var type = GetStringValue(storage, "Type");
                var material = GetStringValue(storage, "Material");
                var unlockIndex = GetIntValue(storage, "UnlockIndex");
                var cost = GetCost(storage);
                var effect = GetEffect(storage);

                AllComponents.Add(
                    new Storage()
                    {
                        Type = type,
                        Material = material,
                        UnlockIndex = unlockIndex,
                        Cost = cost,
                        Effect = effect
                    });
            }

            UnlockedComponents = AllComponents.Where(x => x.UnlockIndex == 0).ToList();
            BuiltComponents = AllComponents.Where(x => x.UnlockIndex == 0).ToList();
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
