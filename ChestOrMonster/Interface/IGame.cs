using ChestOrMonster.Model;

namespace ChestOrMonster.Interface;

public interface IGame
{
    public int CurrentStep { get; set; }
    public StepType CurrentStepType { get; set; }
    public IPlayer Player { get; set; }
    
    public void MoveStep();
}