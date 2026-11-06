using System.Collections.Generic;
using Dungeon.Core.Events;
using Dungeon.Core.Events.Inventory;
using Dungeon.Gameplay.Items;
using UnityEngine;

namespace Dungeon.Gameplay.Quests
{
    public sealed class QuestJournal : MonoBehaviour
    {
        private readonly List<QuestRuntime> _accepted = new();
        private readonly HashSet<QuestRuntime> _rewarded = new();
        public IReadOnlyList<QuestRuntime> Accepted => _accepted.AsReadOnly();

        public bool Contains(QuestDefinition definition) =>
            definition != null && _accepted.Exists(quest => quest.Definition.Id == definition.Id);

        public bool TryAccept(QuestDefinition definition)
        {
            if (!isActiveAndEnabled || definition == null || Contains(definition)) return false;

            var quest = new QuestRuntime(definition);
            _accepted.Add(quest);
            GameplayEventBus.Raise(new QuestAcceptedEvent(quest));
            TryGrantRewards(quest);
            return true;
        }

        private void TryGrantRewards(QuestRuntime quest)
        {
            if (!quest.IsComplete || !_rewarded.Add(quest)) return;

            foreach (var reward in quest.Rewards)
            {
                if (reward is not ItemReward itemReward) continue;
                for (int i = 0; i < itemReward.Amount; i++)
                {
                    var item = ItemFactory.CreateItem(itemReward.Item);
                    GameplayEventBus.Raise(new InventoryChangedEvent(
                        InventoryChangedEvent.ChangeEvents.Added, item, transform.position));
                }
            }

            Debug.Log($"Quest complete: {quest.Definition.Title}. Rewards granted.");
        }
    }
}