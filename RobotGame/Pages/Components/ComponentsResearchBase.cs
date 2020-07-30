using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RobotGame.Shared.Managers;
using RobotGame.Shared.Robot;

namespace RobotGame.Pages.Components
{
    public class Item
    {
        public string Text { get; set; }
        public List<Item> Children { get; set; }
        public Component Component { get; set; }
        public int Step { get; set; }
    }

    public class ComponentsResearchBase : PageBase
    {
        protected override Task OnInitializedAsync()
        {
            BuildTreeList();

            return base.OnInitializedAsync();
        }

        public void BuildTreeList()
        {
            Items = new List<Item>();

            var researchedComponents =
                RobotManager
                    .Instance
                    .AllComponents
                    //.Where(x => x.Researched)
                    .GroupBy(x => x.Type);

            foreach (var types in researchedComponents)
            {
                var rootType = new Item()
                {
                    Text = types.Key.ToString(),
                    Children = new List<Item>()
                };
                Items.Add(rootType);
                ExpandedNodes.Add(rootType);

                foreach (var subType in types.GroupBy(x => x.SubType))
                {
                    var itemSubType = new Item()
                    {
                        Text = subType.Key,
                        Children = new List<Item>(),
                        Step = 1
                    };
                    rootType.Children.Add(itemSubType);

                    AddPlaceholder(itemSubType, subType);
                }
            }
        }

        private void AddPlaceholder(Item inParent, IEnumerable<Component> inChildren)
        {
            var newChildren = new List<Item>();
            foreach (var c in inChildren)
            {
                newChildren.Add(new Item()
                {
                    Text = $"{c.Material}",
                    Component = c,
                    Step = 2
                });
            }

            inParent.Children = newChildren;
        }

        public List<Item> Items;

        public IList<Item> ExpandedNodes = new List<Item>();

        public Item SelectedNode;
    }


}
