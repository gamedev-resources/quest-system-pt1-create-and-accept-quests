using System;

namespace Dungeon.Gameplay.Quests
{
    public static class RewardFactory
    {
        public static IReward Create(RewardDefinition definition)
        {
            switch (definition)
            {
                case PickupRewardDefinition pickup:
                    return new ItemReward(pickup);
                case ExperienceRewardDefinition experience:
                    return new ExperienceReward(experience);
                default:
                    throw new ArgumentException("No runtime reward exists for this definition.");
            }
        }
    }
}