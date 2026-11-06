using System;

namespace Dungeon.Gameplay.Quests
{
    public static class ObjectiveFactory
    {
        public static IObjective Create(ObjectiveDefinition definition)
        {
            switch (definition)
            {
                case PickupObjectiveDefinition pickup:
                    return new PickupObjective(pickup);
                default:
                    throw new ArgumentException("No runtime objective exists for this definition.");
            }
        }
    }
}