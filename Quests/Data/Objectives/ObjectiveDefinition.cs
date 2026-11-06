using System;
using UnityEngine;

namespace Dungeon.Gameplay.Quests {

    [Serializable]
    public abstract class ObjectiveDefinition
    {
        public string Id = Guid.NewGuid().ToString();
        [Min(1)] public int Amount = 1;
    }

}
