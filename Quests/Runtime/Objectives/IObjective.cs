namespace Dungeon.Gameplay.Quests
{
    public interface IObjective
    {
        string Id { get; }
        int Progress { get; }
        int Target { get; }
        bool IsComplete { get; }
    }
}
