using System;
using System.Collections.Generic;
using System.Linq;

namespace Dungeon.Gameplay.Quests
{
    public sealed class QuestRuntime
    {
        public IReadOnlyList<IObjective> Objectives { get; }
        public IReadOnlyList<IReward> Rewards { get; }
        public QuestDefinition Definition { get; }
        public bool IsComplete => Objectives.All(objective => objective.IsComplete);
        public event Action<QuestRuntime> ProgressChanged;

        public QuestRuntime(QuestDefinition definition)
        {
            if (definition == null || string.IsNullOrWhiteSpace(definition.Id) ||
                definition.Objectives == null || definition.Objectives.Count == 0)
                throw new ArgumentException("A quest needs an ID and at least one objective.");

            if (definition.Rewards == null || definition.Rewards.Count == 0)
                throw new ArgumentException("A quest needs at least one reward.");

            Definition = definition;

            var objectives = new List<IObjective>(definition.Objectives.Count);
            var objectiveIds = new HashSet<string>();
            foreach (var data in definition.Objectives)
            {
                var objective = ObjectiveFactory.Create(data);
                if (!objectiveIds.Add(objective.Id))
                    throw new ArgumentException("Objective IDs must be unique within a quest.");
                objectives.Add(objective);
            }
            Objectives = objectives.AsReadOnly();

            var rewards = new List<IReward>(definition.Rewards.Count);
            var rewardIds = new HashSet<string>();
            foreach (var data in definition.Rewards)
            {
                var reward = RewardFactory.Create(data);
                if (!rewardIds.Add(reward.Id))
                    throw new ArgumentException("Reward IDs must be unique within a quest.");
                rewards.Add(reward);
            }
            Rewards = rewards.AsReadOnly();
        }
    }
}