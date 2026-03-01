using System.Windows;
using System.Windows.Controls;
using ChestOrMonster.Interface;
using ChestOrMonster.Model;
using ChestOrMonster.Model.Event.Enemy;
using ChestOrMonster.Model.Event.Player;
using ChestOrMonster.WPF.Pages;

namespace ChestOrMonster.WPF.Templates;

public partial class FightControl : UserControl
{
    private MainPage _mainPage;
    
    public FightControl(MainPage mainPage)
    {
        InitializeComponent();
        _mainPage = mainPage;
        
        LoadEnemies();
    }
    
    public void LoadEnemies()
    {
        EnemiesListBox.ItemsSource = _mainPage.GameInstance.Enemies;
        EnemiesListBox.Items.Refresh();
    }

    public void CheckEnemies()
    {
        if (_mainPage.GameInstance.Enemies.Count == 0 || _mainPage.GameInstance.IsGameOver)
        {
            _mainPage.MoveStep();
        }
        else
        {
            LoadEnemies();
        }
    }
    
    private void AttackButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (EnemiesListBox.SelectedItem is BaseEntity enemy)
        {
            HandleCombat(PlayerAction.Attack, enemy);
        }
        else
        {
            HandleCombat(PlayerAction.Nothing, null);
        }
    }

    private void DefendButton_OnClick(object sender, RoutedEventArgs e)
    {
        HandleCombat(PlayerAction.Defend, null);
    }

    public void HandleCombat(PlayerAction playerAction, BaseEntity? enemyToAttack)
    {
        List<IGameEvent> combatEvents = _mainPage.GameInstance.ProcessCombatAction(playerAction, enemyToAttack);
        
        _mainPage.PlayerHPBar.Value = _mainPage.GameInstance.Player.Hp;
        _mainPage.PlayerHPTextBlock.Text = $"HP: {_mainPage.GameInstance.Player.Hp}";
        _mainPage.Logger.Add("----------------------------------------------");
        foreach (var combatEvent in combatEvents)
        {
            DisplayCombatEvent(combatEvent);
        }
        
        if (_mainPage.GameInstance.Player.Effect == StatusEffect.Frozen)
        {
            HandleCombat(PlayerAction.Nothing, null);
        }
        
        CheckEnemies();
    }
    
    public void DisplayCombatEvent(IGameEvent combatEvent)
    {
        switch (combatEvent)
        {
            case PlayerFrozenEvent:
                _mainPage.Logger.Add("Вы заморожены! Пропуск вашего хода...");
                break;
                
            case PlayerAttackEvent attackEvent:
                _mainPage.Logger.Add($"Вы нанесли {attackEvent.Enemy.Name} {attackEvent.Damage.Amount:F2} урона!");
                break;
                
            case PlayerDodgedEvent:
                _mainPage.Logger.Add("Вы уклонились от атаки врага!");
                break;
                
            case PlayerDodgeFailedEvent:
                _mainPage.Logger.Add("Вы не смогли уклониться!");
                break;
                
            case EnemyAttackEvent enemyAttack:
                _mainPage.Logger.Add($"{enemyAttack.Enemy.Name} нанёс вам {enemyAttack.Damage.Amount:F2}!");
                break;
                
            case EnemyDefeatedEvent defeatedEnemy:
                _mainPage.Logger.Add($"Вы убили {defeatedEnemy.EnemyName}!");
                break;
                
            case PlayerDefeatedEvent playerDefeat:
                _mainPage.Logger.Add($"Вас убил {playerDefeat.EnemyName}! Вы проиграли, GGWP :(");
                break;
        }
    }
}