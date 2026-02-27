using System.Windows;
using System.Windows.Controls;

namespace ChestOrMonster.WPF.Pages;

public partial class StartPage : Page
{
    public StartPage()
    {
        InitializeComponent();
    }

    private void StartGameButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MainPage());
    }
}