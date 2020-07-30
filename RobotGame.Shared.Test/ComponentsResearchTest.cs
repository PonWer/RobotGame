using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RobotGame.Pages.Components;
using RobotGame.Shared.Managers;

namespace RobotGame.Shared.Test
{
    public class ComponentsResearchTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ResearchTree_Built()
        {
            ComponentsResearchBase test = new ComponentsResearchBase();
            test.BuildTreeList();

            Assert.AreEqual(5,test.Items.Count);
        }
    }
}
