using System;
using Dungeon.Config.Items;

namespace Dungeon.Gameplay.Quests
{
    public sealed class ItemReward : Reward
    {
        public ItemData Item { get; }

        public ItemReward(PickupRewardDefinition definition) : base(definition)
        {
            Item = definition.Item != null ? definition.Item :
                throw new ArgumentException("An item reward needs an item.");
        }
    }
}
