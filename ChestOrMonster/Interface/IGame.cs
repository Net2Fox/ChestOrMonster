using ChestOrMonster.Model;

namespace ChestOrMonster.Interface;

public interface IGame
{
    public int CurrentStep { get; }
    public StepType CurrentStepType { get; }
    public Player Player { get; }
    
    public void MoveStep();
}