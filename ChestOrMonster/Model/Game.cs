using ChestOrMonster.Factory;
using ChestOrMonster.Interface;
using ChestOrMonster.Model.Event;
using ChestOrMonster.Model.Event.Enemy;
using ChestOrMonster.Model.Event.Player;

namespace ChestOrMonster.Model;

public class Game : IGame
{
    public bool IsGameOver { get; private set; }
    public int CurrentStep { get; private set; }
    public StepType CurrentStepType { get; private set; }
    public Player Player { get; private set; }
    public BaseEntity? CurrentEnemy { get; private set; }
    
    private static Random _random = Random.Shared;

    public Game(string playerName)
    {
        IsGameOver = false;
        CurrentStep = 0;
        Player = new Player(playerName);
    }
    
    public IGameEvent MoveStep()
    {
        CurrentStep += 1;

        if (CurrentStep % 10 == 0)
        {
            CurrentStepType = StepType.Enemy;
            CurrentEnemy = EnemyFactory.CreateRandomBoss();
            return new EnemyEncounteredEvent(CurrentEnemy, true);
        }
        
        CurrentStepType = (StepType)_random.Next(1, 3);
        switch (CurrentStepType)
        {
            case StepType.Enemy:
                CurrentEnemy = EnemyFactory.CreateRandomEnemy();
                return new EnemyEncounteredEvent(CurrentEnemy);
                break;
            case StepType.Chest:
                return new ChestFoundEvent(ItemFactory.CreateRandomItem());
                break;
            
            default:
                throw new InvalidOperationException();
        }
    }

    public List<IGameEvent> ProcessCombatAction(PlayerAction action)
    {
        List<IGameEvent> events = new List<IGameEvent>();
        bool dodged = false;
        
        switch (Player.Effect)
        {
            case StatusEffect.Frozen:
                events.Add(new PlayerFrozenEvent());
                Player.UpdateStatusEffect();
                break;
            case StatusEffect.None:
                switch (action)
                {
                    case PlayerAction.Attack:
                        DamageInfo playerAtk = Player.Attack();
                        playerAtk = CurrentEnemy.TakeDamage(playerAtk);
                        events.Add(new PlayerAttackEvent(playerAtk, CurrentEnemy.Hp));
                        break;
                    case PlayerAction.Defend:
                        dodged = Player.Dodge();
                        if (dodged)
                        {
                            events.Add(new PlayerDodgedEvent());
                        }
                        else
                        {
                            events.Add(new PlayerDodgeFailedEvent());
                        }
                        break;
                }
                break;
        }
        if (CurrentEnemy.Hp > 0 && !dodged)
        {
            DamageInfo enemyAtk = CurrentEnemy.Attack();
            enemyAtk = Player.TakeDamage(enemyAtk);
            Console.WriteLine($"Враг нанёс вам {enemyAtk.Amount:F2}!");
        }

        if (CurrentEnemy.Hp <= 0)
        {
            events.Add(new EnemyDefeatedEvent(CurrentEnemy.Name));
            CurrentEnemy = null;
            return events;
        }

        if (Player.Hp <= 0)
        {
            events.Add(new PlayerDefeatedEvent(CurrentEnemy.Name));
            IsGameOver = true;
            return events;
        }

        if (!dodged)
        {
            DamageInfo enemyDamage = CurrentEnemy.Attack();
            enemyDamage = Player.TakeDamage(enemyDamage);
            events.Add(new EnemyAttackEvent(enemyDamage, Player.Hp));
        }
        
        return events;
    }
    
    public void ProcessItemAction(IBaseItem item, ItemAction action)
    {
        if (action == ItemAction.Use)
        {
            Player.UseItem(item);
        }
    }
}