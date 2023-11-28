public class Character
{
    public int Health { get; set; } = 100;
    public int Energy { get; set; } = 500;
    public int MovesSinceLastHealing { get; set; } = 0;
}

public class Maze
{
    public class Medicine
    {
        public int HealingPercentage { get; } = 5;
    }

    public class CoffeeCup
    {
        public int EnergyBoost { get; } = 25;
    }

    public static void CollectMedicine(Character character, Medicine medicine)
    {
        if (character.Health < 100)
        {
            character.Health = Math.Min(100, character.Health + medicine.HealingPercentage);
            MessageBox.Show($"Собрано лекарство! Здоровье восстановлено на {medicine.HealingPercentage}%.");
        }
        else
        {
            MessageBox.Show("Здоровье уже на максимуме. Лекарство нельзя подобрать.");
        }

        character.MovesSinceLastHealing = 0;

        if (character.Health == 0)
        {
            MessageBox.Show("Поражение - закончилось здоровье.");
        }
    }

    public static void CollectCoffeeCup(Character character, CoffeeCup coffeeCup)
    {
        if (character.MovesSinceLastHealing >= 10)
        {
            character.Energy += coffeeCup.EnergyBoost;
            MessageBox.Show($"Собрана чашка кофе! Запас энергии повышен на {coffeeCup.EnergyBoost} единиц.");
        }
        else
        {
            MessageBox.Show("Вы не можете выпить кофе, так как совершили менее 10 перемещений после последнего лекарства.");
        }

        if (character.Energy == 0)
        {
            MessageBox.Show("Поражение - закончилась энергия.");
        }
    }

    public static void UseJediSword(Character character)
    {
        if (character.Energy >= 10)
        {
            character.Energy -= 10;
            // Здесь можно добавить логику для обработки врагов в радиусе
            MessageBox.Show("Применено джедаевское меч!");
        }
        else
        {
            MessageBox.Show("Недостаточно энергии для применения джедаевского меча.");
        }

        if (character.Energy == 0)
        {
            MessageBox.Show("Поражение - закончилась энергия.");
        }
    }

    public static void UseSpartanKick(Character character)
    {
        if (character.Energy >= 10)
        {
            character.Energy -= 10;
            // Здесь можно добавить логику для обработки врагов в радиусе
            MessageBox.Show("Применен пинок спартанца!");
        }
        else
        {
            MessageBox.Show("Недостаточно энергии для применения пинка спартанца.");
        }

        if (character.Energy == 0)
        {
            MessageBox.Show("Поражение - закончилась энергия.");
        }
    }
}

public partial class Form1 : Form
{
    private Character player = new Character();
    private Maze.Medicine medicine = new Maze.Medicine();
    private Maze.CoffeeCup coffeeCup = new Maze.CoffeeCup();

    public Form1()
    {
        InitializeComponent();
        UpdateEnergyLabel();
    }

    private void buttonCollectMedicine_Click(object sender, EventArgs e)
    {
        Maze.CollectMedicine(player, medicine);
        UpdateEnergyLabel();
    }

    private void buttonCollectCoffee_Click(object sender, EventArgs e)
    {
        Maze.CollectCoffeeCup(player, coffeeCup);
        UpdateEnergyLabel();
    }

    private void buttonUseJediSword_Click(object sender, EventArgs e)
    {
        Maze.UseJediSword(player);
        UpdateEnergyLabel();
    }

    private void buttonUseSpartanKick_Click(object sender, EventArgs e)
    {
        Maze.UseSpartanKick(player);
        UpdateEnergyLabel();
    }

    private void UpdateEnergyLabel()
    {
        labelEnergy.Text = $"Энергия: {player.Energy} единиц";
    }
}
