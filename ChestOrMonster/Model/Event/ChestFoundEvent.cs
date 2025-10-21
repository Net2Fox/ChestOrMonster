using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Event;

public class ChestFoundEvent : IGameEvent
{
    public IBaseItem Item { get; }

    public ChestFoundEvent(IBaseItem item)
    {
        Item = item;
    }
}