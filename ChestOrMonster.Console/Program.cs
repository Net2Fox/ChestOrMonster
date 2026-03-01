using System.Text;
using ChestOrMonster.Factory;
using ChestOrMonster.Interface;
using ChestOrMonster.Model;
using ChestOrMonster.Model.Enemy;
using ChestOrMonster.Model.Enemy.Boss;
using ChestOrMonster.Model.Event;
using ChestOrMonster.Model.Event.Enemy;
using ChestOrMonster.Model.Event.Player;
using ChestOrMonster.Model.Item;

namespace ChestOrMonster;

class Program
{
    private static Random _random = Random.Shared;

    private static Game _gameInstance;
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в игру \"Сундуки и Монстры\"!");
        StartMenu();
    }

    static void StartMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в игру \"Сундуки и Монстры\"!");
            Console.WriteLine("1. Начать");
            Console.WriteLine("2. Об игре");
            Console.WriteLine("0. Выйти");

            int playerChoice = UserChoice(0, 2);
            switch (playerChoice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Введите имя: ");
                    string playerName = Console.ReadLine() ?? string.Empty;
                    while (string.IsNullOrWhiteSpace(playerName))
                    {
                        Console.Write("Введите имя: ");
                        playerName = Console.ReadLine() ?? string.Empty;
                    }
                    StartGame(playerName);
                    break;
                case 2:
                    WriteHelp();
                    break;
                case 0:
                    Console.WriteLine("Прощай!");
                    return;
            }
        }
    }

    static void WriteHelp()
    {
        Console.Clear();
        Console.WriteLine("Игра \"Сундуки и Монстры\" представляет собой пошаговую текстовую игру рогалик.\nПрактические все элементы игры генерируются случайно.");
        Console.WriteLine("Вы искатель приключений и бродите по миру в поиске приключений на свою голову.\nНа каждом ходу вам может попасться *сундук* или *монстр*.");
        Console.WriteLine("Из сундука вам может выпасть предмет - лечебное зелье, оружие или доспех.\n\tОт оружия зависит сила атаки.\n\tОт доспехов зависит защита.");
        Console.WriteLine("Если вы наткнулись на врага, то начинается бой. Вы можете атаковать и защищаться. При выбора защиты, есть шанс до 40% полностью уклониться от атаки.");
        Console.WriteLine("\nПосле прочтения, нажмите любую кнопку.");
        Console.ReadKey();
    }

    static void StartGame(string playerName)
    {
        _gameInstance = new Game(playerName);
        
        while (!_gameInstance.IsGameOver)
        {
            IGameEvent stepEvent = _gameInstance.MoveStep();
            Console.WriteLine($"Сейчас {_gameInstance.CurrentStep} ход.");
            
            HandleGameEvent(stepEvent);
            
            Thread.Sleep(1000);
        }
    }

    static void HandleGameEvent(IGameEvent gameEvent)
    {
        switch (gameEvent)
        {
            case ChestFoundEvent chestEvent:
                HandleChest(chestEvent.Item);
                break;
                
            case EnemyEncounteredEvent enemyEvent:
                HandleCombat(enemyEvent.Enemy, enemyEvent.IsBoss);
                break;
        }
    }

    static void HandleChest(IBaseItem item)
    {
        Console.WriteLine($"Вам выпал {item.Name}!");
        
        switch (item)
        {
            case Weapon or Armor:
                OfferEquipmentChange(item);
                break;
            case HealingPotion:
                OfferHealingPotion(item);
                break;
        }
    }

    static void HandleCombat(BaseEntity enemy, bool isBoss)
    {
        Console.WriteLine($"Вы наткнулись на {enemy.Name}!" + (isBoss ? " Это БОСС!" : ""));
        
        while (_gameInstance.CurrentEnemy != null && !_gameInstance.IsGameOver)
        {
            DisplayCombatStats(enemy);
            
            PlayerAction action = GetPlayerCombatAction();
            
            List<IGameEvent> combatEvents = _gameInstance.ProcessCombatAction(action);
            
            foreach (var combatEvent in combatEvents)
            {
                DisplayCombatEvent(combatEvent);
            }
            
            Thread.Sleep(1000);
        }
    }

    static void DisplayCombatStats(BaseEntity enemy)
    {
        Console.WriteLine($"Характеристики врага:\n\tИмя: {enemy.Name}\n\tHP: {enemy.Hp:F0}\n\tАтака: {enemy.Atk}\n\tЗащита: {enemy.Def}");
        Console.WriteLine($"Ваши характеристики:\n\tHP: {_gameInstance.Player.Hp:F0}\n\tАтака: {_gameInstance.Player.Weapon?.Damage}\n\tЗащита: {_gameInstance.Player.Armor?.Def}");
    }

    static PlayerAction GetPlayerCombatAction()
    {
        if (_gameInstance.Player.Effect == StatusEffect.Frozen)
        {
            return PlayerAction.Nothing;
        }
        
        Console.WriteLine("Выберите действие:\n\t1. Атаковать\n\t2. Защищаться");
        int choice = UserChoice(1, 2);
        return choice == 1 ? PlayerAction.Attack : PlayerAction.Defend;
    }

    static void DisplayCombatEvent(IGameEvent combatEvent)
    {
        switch (combatEvent)
        {
            case PlayerFrozenEvent:
                Console.WriteLine("Вы заморожены! Пропуск вашего хода...");
                break;
                
            case PlayerAttackEvent attackEvent:
                Console.WriteLine($"Вы нанесли врагу {attackEvent.Damage.Amount:F2} урона!");
                break;
                
            case PlayerDodgedEvent:
                Console.WriteLine("Вы уклонились от атаки врага!");
                break;
                
            case PlayerDodgeFailedEvent:
                Console.WriteLine("Вы не смогли уклониться!");
                break;
                
            case EnemyAttackEvent enemyAttack:
                Console.WriteLine($"Враг нанёс вам {enemyAttack.Damage.Amount:F2}!");
                break;
                
            case EnemyDefeatedEvent defeatedEnemy:
                Console.WriteLine($"Вы убили {defeatedEnemy.EnemyName}!");
                break;
                
            case PlayerDefeatedEvent playerDefeat:
                Console.WriteLine($"Вас убил {playerDefeat.EnemyName}! Вы проиграли, GGWP :(");
                Thread.Sleep(15000);
                break;
        }
    }

    static void OfferHealingPotion(IBaseItem healingPotion)
    {
        Console.WriteLine($"У вас сейчас {_gameInstance.Player.Hp:F0} HP. Хотите выпить зелье или выбросить его?\n\t1. Выпить\t2. Выбросить");
        int choice = UserChoice(1, 2);
        ItemAction action = choice == 1 ? ItemAction.Use : ItemAction.Discard;
        
        _gameInstance.ProcessItemAction(healingPotion, action);
        
        if (action == ItemAction.Use)
        {
            Console.WriteLine("Вы восстановили HP до максимума!");
        }
        else
        {
            Console.WriteLine("Вы выкинули лечебное зелье.");
        }
    }

    static void OfferEquipmentChange(IBaseItem equipment)
    {
        StringBuilder stringBuilder = new StringBuilder();
        
        switch (equipment)
        {
            case Weapon weapon:
                stringBuilder.AppendLine(
                    $"Ваши характеристики сейчас:\n{_gameInstance.Player.Weapon.Name}, {_gameInstance.Player.Weapon.Damage}.");
                stringBuilder.AppendLine(
                    $"Характеристики нового оружия: {weapon.Name}, {weapon.Damage}");
                stringBuilder.AppendLine("Хотите сменить оружие или оставить текущее?");
                break;
                
            case Armor armor:
                stringBuilder.AppendLine(
                    $"Ваши характеристики сейчас:\n{_gameInstance.Player.Armor.Name}, {_gameInstance.Player.Armor.Def}.");
                stringBuilder.AppendLine(
                    $"Характеристики новых доспехов: {armor.Name}, {armor.Def}");
                stringBuilder.AppendLine("Хотите сменить доспехи или оставить текующие?");
                break;
        }
        
        stringBuilder.AppendLine("\t1. Сменить\t2. Оставить");
        Console.WriteLine(stringBuilder.ToString());
        
        int choice = UserChoice(1, 2);
        ItemAction action = choice == 1 ? ItemAction.Use : ItemAction.Discard;
        
        _gameInstance.ProcessItemAction(equipment, action);
        
        if (action == ItemAction.Discard)
        {
            Console.WriteLine($"Вы выкинули {equipment.Name}!");
        }
    }

    static int UserChoice(int minChoice, int maxChoice)
    {
        while (true)
        {
            string choice = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(choice, out var choiceNumber))
            {
                continue;
            }

            if (choiceNumber < minChoice || choiceNumber > maxChoice)
            {
                continue;
            }
            return choiceNumber;
        }
    }
}