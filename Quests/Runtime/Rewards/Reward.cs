using System;

namespace Dungeon.Gameplay.Quests
{
    public abstract class Reward : IReward
    {
        public string Id { get; }
        public int Amount { get; }

        protected Reward(RewardDefinition definition)
        {
            if (definition == null || string.IsNullOrWhiteSpace(definition.Id) || definition.Amount < 1)
                throw new ArgumentException("A reward needs an ID and a positive amount.");
            Id = definition.Id;
            Amount = definition.Amount;
        }
    }
}
