using System.Windows;
using System.Windows.Controls;

namespace ChestOrMonster.WPF.Pages;

public partial class GameOverPage : Page
{
    public GameOverPage()
    {
        InitializeComponent();
    }

    private void ReStartGameButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MainPage());
    }
}