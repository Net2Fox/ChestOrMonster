using ChestOrMonster.Model;
using ChestOrMonster.Model.Enemy;
using ChestOrMonster.Model.Item;

int passed = 0;

Run("Лук попадает при результате ниже точности", () =>
{
    var bow = new Bow("Тестовый лук", 10, 0.7);
    AssertEqual(10, bow.Attack(0.25).Amount);
});

Run("Лук промахивается при результате выше точности", () =>
{
    var bow = new Bow("Тестовый лук", 10, 0.7);
    AssertEqual(0, bow.Attack(0.75).Amount);
});

Run("Игрок хранит только одно оружие", () =>
{
    var player = new Player("Тест");
    var bow = new Bow("Тестовый лук", 10, 0.7);
    player.UseItem(bow);
    if (!ReferenceEquals(bow, player.Weapon))
    {
        throw new Exception("Лук не стал текущим оружием игрока.");
    }

    var sword = new Weapon("Тестовый меч", 8);
    player.UseItem(sword);
    if (!ReferenceEquals(sword, player.Weapon))
    {
        throw new Exception("Новое оружие не заменило лук.");
    }
});

Run("Берсерк удваивает атаку при половине здоровья", () =>
{
    var berserker = new Berserker();
    AssertEqual(6, berserker.Attack().Amount);
    berserker.TakeDamage(new DamageInfo(10, DamageType.Pure));
    AssertEqual(12, berserker.Attack().Amount);
});

Console.WriteLine($"Проверки пройдены: {passed}/4");

void Run(string name, Action test)
{
    try
    {
        test();
        passed++;
        Console.WriteLine($"[OK] {name}");
    }
    catch (Exception exception)
    {
        Console.WriteLine($"[ОШИБКА] {name}: {exception.Message}");
        Environment.ExitCode = 1;
    }
}

static void AssertEqual(double expected, double actual)
{
    if (Math.Abs(expected - actual) > 0.0001)
    {
        throw new Exception($"Ожидалось {expected}, получено {actual}.");
    }
}
