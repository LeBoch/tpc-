using System;

public class Character
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Initiative { get; set; }
    public int Damages { get; set; }
    public int MaximumLife { get; set; }
    public int CurrentLife { get; set; }
    public int CurrentAttackNumber { get; set; }
    public int TotalAttackNumber { get; set; }

    private Random _random = new Random();

    // Constructor
    public Character(string name, int attack, int defense, int initiative, int damages, int maxLife, int totalAttackNumber)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
        Initiative = initiative;
        Damages = damages;
        MaximumLife = maxLife;
        CurrentLife = maxLife;
        TotalAttackNumber = totalAttackNumber;
        CurrentAttackNumber = totalAttackNumber;
    }

    // Method to calculate a roll
    public int Roll(int baseValue)
    {
        return baseValue + _random.Next(1, 101); // Random between 1 and 100
    }

    // Check if the character is alive
    public bool IsAlive()
    {
        return CurrentLife > 0;
    }

    // Reset attacks for a new round
    public void ResetAttackNumber()
    {
        CurrentAttackNumber = TotalAttackNumber;
    }
}
