using System.IO;
using NUnit.Framework;
using RobotGame.Shared.Managers;

namespace RobotGame.Shared.Test
{
    public class RobotManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AccessToEmbeddedResource_RobotComponents()
        {
            var result = RobotManager.Instance.GetResourceFile("RobotComponents.xml");
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
    }
}