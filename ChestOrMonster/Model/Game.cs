using ChestOrMonster.Interface;

namespace ChestOrMonster.Model;

public class Game : IGame
{
    public int CurrentStep { get; set; }
    public StepType CurrentStepType { get; set; }
    public IPlayer Player { get; set; }
    
    private static Random _random = new Random(DateTime.Now.Millisecond);

    public Game(string playerName)
    {
        CurrentStep = 0;
        Player = new Player(playerName);
    }
    
    public void MoveStep()
    {
        CurrentStep++;
        CurrentStepType = (StepType)_random.Next(1, 3);
    }
}