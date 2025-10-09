namespace ChestOrMonster.Interface;

public interface IPlayer : IBaseEntity
{
    IBaseItem? Weapon  { get; set; }
    IBaseItem? Armor { get; set; }

    public void ChangeEquipment(IBaseItem item);
}