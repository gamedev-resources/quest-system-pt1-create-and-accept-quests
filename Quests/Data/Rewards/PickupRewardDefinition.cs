using System;
using Dungeon.Config.Items;

namespace Dungeon.Gameplay.Quests {

    [Serializable]
    public class PickupRewardDefinition : RewardDefinition {
        public ItemData Item;
    }

}
