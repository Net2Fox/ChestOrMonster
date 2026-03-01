using ChestOrMonster.Model;

namespace ChestOrMonster.Interface;

public interface IGame
{
    public bool IsGameOver { get; }
    public int CurrentStep { get; }
    public StepType CurrentStepType { get; }
    public Player Player { get; }
    public List<BaseEntity>? Enemies { get; }
    
    public IGameEvent MoveStep();
    public List<IGameEvent> ProcessCombatAction(PlayerAction action, BaseEntity enemyToAttack);
    public void ProcessItemAction(IBaseItem item, ItemAction action);
}