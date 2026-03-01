using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ChestOrMonster.Interface;
using ChestOrMonster.Model;
using ChestOrMonster.Model.Event;
using ChestOrMonster.Model.Event.Enemy;
using ChestOrMonster.WPF.Templates;

namespace ChestOrMonster.WPF.Pages;

public partial class MainPage : Page
{
    private Random _random = Random.Shared;

    public Game GameInstance { get; private set; }
    
    public ObservableCollection<string> Logger { get; } = new ObservableCollection<string>();
    
    public MainPage()
    {
        InitializeComponent();
        DataContext = this;
        StartGame("Player");
        
        Logger.CollectionChanged += (_, _) =>
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, () =>
            {
                LogScroller.ScrollToEnd();
            });
        };
    }
    
    public void StartGame(string playerName)
    {
        GameInstance = new Game(playerName);
        
        MoveStep();
    }

    public void MoveStep()
    {
        if (!GameInstance.IsGameOver)
        {
            IGameEvent stepEvent = GameInstance.MoveStep();
            Logger.Add($"Сейчас {GameInstance.CurrentStep} ход.");
            StepTextBlock.Text = $"Этаж {GameInstance.CurrentStep}";
            PlayerHPBar.Value = GameInstance.Player.Hp;
            PlayerHPTextBlock.Text = $"HP: {GameInstance.Player.Hp:N0}";
            WeaponTextBlock.Text = $"{GameInstance.Player.Weapon.Name}, Урон: {GameInstance.Player.Weapon.Damage}";
            ArmorTextBlock.Text = $"{GameInstance.Player.Armor.Name}, Защита: {GameInstance.Player.Armor.Def}";
            HandleGameEvent(stepEvent);
        }
        else
        {
            NavigationService.Navigate(new GameOverPage());
        }
    }
    
    public void HandleGameEvent(IGameEvent gameEvent)
    {
        switch (gameEvent)
        {
            case ChestFoundEvent chestEvent: 
                Logger.Add($"Вы наткнулись на сундук!");
                MainControl.Content = new ChestControl(this, chestEvent.Item);
                break;
                
            case EnemyEncounteredEvent enemyEvent:
                StringBuilder stringBuilder = new StringBuilder();
                Logger.Add($"Вы наткнулись на {String.Join(", ", enemyEvent.Enemies.Select(e => e.Name))}!");
                MainControl.Content = new FightControl(this);
                break;
        }
    }

    public int MessageBoxUserChoice(string message)
    {
        var choice = MessageBox.Show(message, "Выбор", MessageBoxButton.YesNo, MessageBoxImage.Question);
        return choice == MessageBoxResult.Yes ? 1 : 2;
    }
}