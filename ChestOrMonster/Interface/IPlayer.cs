namespace ChestOrMonster.Interface;

public interface IPlayer : IBaseEntity
{
    IWeapon? Weapon  { get; set; }
    IArmor? Armor { get; set; }

    public void ChangeEquipment(IBaseItem item);
}