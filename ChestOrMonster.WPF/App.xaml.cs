using System.Configuration;
using System.Data;
using System.Windows;
using ChestOrMonster.WPF.Model;
using Microsoft.Extensions.DependencyInjection;

namespace ChestOrMonster.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
   public new static App Current => (App)Application.Current;
   
   public IServiceProvider Services { get; }

   public App()
   {
      Services = ConfigureServices();
      
      this.InitializeComponent();
   }

   public IServiceProvider ConfigureServices()
   {
      var services = new ServiceCollection();

      services.AddSingleton<GameScript>();
      
      return services.BuildServiceProvider();
   }
}