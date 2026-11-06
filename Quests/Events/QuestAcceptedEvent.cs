using Dungeon.Core.Events;

namespace Dungeon.Gameplay.Quests
{
    public sealed class QuestAcceptedEvent : IGameplayEvent
    {
        public QuestRuntime Quest { get; }
        public QuestAcceptedEvent(QuestRuntime quest) => Quest = quest;
    }
}