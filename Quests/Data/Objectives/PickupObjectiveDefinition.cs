using System;
using Dungeon.Config.Items;

namespace Dungeon.Gameplay.Quests {

    [Serializable]
    public class PickupObjectiveDefinition : ObjectiveDefinition {
        public ItemData Item;
    }

}
