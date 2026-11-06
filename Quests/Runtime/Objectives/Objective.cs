using System;

namespace Dungeon.Gameplay.Quests
{
    public abstract class Objective : IObjective
    {
        public string Id { get; }
        public int Progress { get; private set; }
        public int Target { get; }
        public bool IsComplete => Progress >= Target;

        internal bool AddProgress(int amount)
        {
            if (amount <= 0 || IsComplete) return false;
            Progress += Math.Min(amount, Target - Progress);
            return true;
        }

        protected Objective(ObjectiveDefinition definition)
        {
            if (definition == null || string.IsNullOrWhiteSpace(definition.Id) || definition.Amount < 1)
                throw new ArgumentException("An objective needs an ID and a positive amount.");
            Id = definition.Id;
            Target = definition.Amount;
            Progress = 0;
        }
    }
}
