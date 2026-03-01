using System.Text;
using System.Windows;
using System.Windows.Controls;
using ChestOrMonster.Interface;
using ChestOrMonster.Model;
using ChestOrMonster.Model.Item;
using ChestOrMonster.WPF.Pages;

namespace ChestOrMonster.WPF.Templates;

public partial class ChestControl : UserControl
{
    private MainPage _mainPage;
    private IBaseItem _item;
    
    public ChestControl(MainPage mainPage,  IBaseItem item)
    {
        InitializeComponent();
        _mainPage = mainPage;
        _item = item;
    }
    
    private void OpenChestButton_OnClick(object sender, RoutedEventArgs e)
    {
        HandleChest(_item);
        _mainPage.MoveStep();
    }
    
    public void HandleChest(IBaseItem item)
    {
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
    
    public void OfferHealingPotion(IBaseItem healingPotion)
    {
        int choice = _mainPage.MessageBoxUserChoice($"Хотите выпить зелье или выбросить его?");
        ItemAction action = choice == 1 ? ItemAction.Use : ItemAction.Discard;
        
        _mainPage.GameInstance.ProcessItemAction(healingPotion, action);
        
        if (action == ItemAction.Use)
        {
            _mainPage.Logger.Add("Вы восстановили HP до максимума!");
        }
        else
        {
            _mainPage.Logger.Add("Вы выкинули лечебное зелье.");
        }
    }

    public void OfferEquipmentChange(IBaseItem equipment)
    {
        StringBuilder stringBuilder = new StringBuilder();
        
        switch (equipment)
        {
            case Weapon weapon:
                stringBuilder.AppendLine(
                    $"Характеристики нового оружия: {weapon.Name}, {weapon.Damage}");
                stringBuilder.AppendLine("Хотите сменить оружие?");
                break;
                
            case Armor armor:
                stringBuilder.AppendLine(
                    $"Характеристики новых доспехов: {armor.Name}, {armor.Def}");
                stringBuilder.AppendLine("Хотите сменить доспехи?");
                break;
        }
        
        int choice = _mainPage.MessageBoxUserChoice(stringBuilder.ToString());
        ItemAction action = choice == 1 ? ItemAction.Use : ItemAction.Discard;
        
        _mainPage.GameInstance.ProcessItemAction(equipment, action);
        
        if (action == ItemAction.Discard)
        {
            _mainPage.Logger.Add($"Вы выкинули {equipment.Name}!");
        }
    }
}