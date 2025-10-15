using ChestOrMonster.Interface;

namespace ChestOrMonster.Model;

public class Game : IGame
{
    public int CurrentStep { get; private set; }
    public StepType CurrentStepType { get; private set; }
    public Player Player { get; private set; }
    
    private static Random _random = Random.Shared;

    public Game(string playerName)
    {
        CurrentStep = 0;
        Player = new Player(playerName);
    }
    
    public void MoveStep()
    {
        CurrentStep += 1;
        CurrentStepType = (StepType)_random.Next(1, 3);
    }
}