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
    
    public List<BaseEntity>? Enemies { get; private set; }
    
    private static Random _random = Random.Shared;

    public Game(string playerName)
    {
        IsGameOver = false;
        CurrentStep = 0;
        Player = new Player(playerName);
        Enemies = new List<BaseEntity>();
    }
    
    public IGameEvent MoveStep()
    {
        CurrentStep += 1;

        if (CurrentStep % 10 == 0)
        {
            CurrentStepType = StepType.Enemy;
            var enemyCount = _random.Next(1, 3);
            Enemies.Add(EnemyFactory.CreateRandomBoss());
            for (int i = 1; i < enemyCount; i++)
            {
                var enemy = EnemyFactory.CreateRandomEnemy();
                Enemies.Add(enemy);
            }
            return new EnemyEncounteredEvent(Enemies, true);
        }

        CurrentStepType = (StepType)_random.Next(1, 3);
        switch (CurrentStepType)
        {
            case StepType.Enemy:
                var enemyCount = _random.Next(1, 4);
                for (int i = 0; i < enemyCount; i++)
                {
                    var enemy = EnemyFactory.CreateRandomEnemy();
                    Enemies.Add(enemy);
                }
                return new EnemyEncounteredEvent(Enemies);
                break;
            case StepType.Chest:
                return new ChestFoundEvent(ItemFactory.CreateRandomItem());
                break;
            
            default:
                throw new InvalidOperationException();
        }
    }

    public List<IGameEvent> ProcessCombatAction(PlayerAction action, BaseEntity? enemyToAttack)
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
                        playerAtk = enemyToAttack.TakeDamage(playerAtk);
                        events.Add(new PlayerAttackEvent(enemyToAttack, playerAtk, enemyToAttack.Hp));
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

        for (int i = Enemies.Count - 1; i >= 0; i--)
        {
            var enemy =  Enemies[i];
            
            if (enemy.Hp <= 0)
            {
                events.Add(new EnemyDefeatedEvent(enemy.Name));
                Enemies.Remove(enemy);
                continue;
            }
            
            if (enemy.Hp > 0 && !dodged)
            {
                DamageInfo enemyAtk = enemy.Attack();
                enemyAtk = Player.TakeDamage(enemyAtk);
            }
            
            if (Player.Hp <= 0)
            {
                events.Add(new PlayerDefeatedEvent(enemy.Name));
                IsGameOver = true;
                return events;
            }
            
            if (!dodged)
            {
                DamageInfo enemyDamage = enemy.Attack();
                enemyDamage = Player.TakeDamage(enemyDamage);
                events.Add(new EnemyAttackEvent(enemy, enemyDamage, Player.Hp));
            }
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