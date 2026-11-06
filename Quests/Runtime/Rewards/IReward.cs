namespace Dungeon.Gameplay.Quests
{
    public interface IReward
    {
        string Id { get; }
        int Amount { get; }
    }
}
