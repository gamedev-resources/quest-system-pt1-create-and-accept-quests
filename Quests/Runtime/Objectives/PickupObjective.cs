using System;
using Dungeon.Config.Items;

namespace Dungeon.Gameplay.Quests
{
    public sealed class PickupObjective : Objective
    {
        public ItemData Item { get; }

        public PickupObjective(PickupObjectiveDefinition definition) : base(definition)
        {
            Item = definition.Item != null ? definition.Item :
                throw new ArgumentException("A pickup objective needs an item.");
        }
    }
}
