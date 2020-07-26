using System;
using System.IO;
using System.Xml.Linq;
using NUnit.Framework;
using RobotGame.Shared.Managers;

namespace RobotGame.Shared.Test
{
    public class WorldManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void AccessToEmbeddedResource_WorldData()
        {
            var result = WorldManager.Instance.GetResourceFile("WorldData.xml");
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [Test]
        public void ZonesLoaded()
        {
            Assert.IsNotNull(WorldManager.Instance.Zones);
            Assert.IsTrue(WorldManager.Instance.Zones.Count > 0);
        }
    }
}