using System;
using System.Collections.Generic;
using System.Linq;

public class Battle
{
    private List<Character> _characters;
    private Random _random = new Random();

    // Constructor
    public Battle(List<Character> characters)
    {
        _characters = characters;
    }

    // Method to start the battle
    public void Start()
    {
        int round = 1;
        while (_characters.Count(c => c.IsAlive()) > 1)
        {
            Console.WriteLine($"--- Round {round} ---");
            PlayRound();
            round++;
        }

        var winner = _characters.FirstOrDefault(c => c.IsAlive());
        if (winner != null)
        {
            Console.WriteLine($"The winner is {winner.Name}!");
        }
        else
        {
            Console.WriteLine("All characters are dead. No winner!");
        }
    }

    // Method to play a single round
    private void PlayRound()
    {
        // Roll initiative for each character
        var initiativeOrder = _characters
            .Where(c => c.IsAlive())
            .OrderByDescending(c => c.Roll(c.Initiative))
            .ToList();

        foreach (var attacker in initiativeOrder)
        {
            if (!attacker.IsAlive()) continue;

            // Reset attacks for this round
            attacker.ResetAttackNumber();

            while (attacker.CurrentAttackNumber > 0 && attacker.IsAlive())
            {
                // Choose a random target
                var targets = _characters.Where(c => c.IsAlive() && c != attacker).ToList();
                if (targets.Count == 0) break;

                var target = targets[_random.Next(targets.Count)];

                // Calculate attack roll
                int attackRoll = attacker.Roll(attacker.Attack);

                // Calculate defense roll
                int defenseRoll = target.Roll(target.Defense);

                Console.WriteLine($"{attacker.Name} attacks {target.Name}!");
                Console.WriteLine($"Attack Roll: {attackRoll}, Defense Roll: {defenseRoll}");

                if (attackRoll > defenseRoll)
                {
                    // Successful hit
                    Console.WriteLine($"{attacker.Name} hits {target.Name} for {attacker.Damages} damage!");
                    target.CurrentLife -= attacker.Damages;

                    if (target.CurrentLife <= 0)
                    {
                        Console.WriteLine($"{target.Name} has been defeated!");
                    }
                }
                else
                {
                    // Miss
                    Console.WriteLine($"{attacker.Name} missed {target.Name}!");
                }

                attacker.CurrentAttackNumber--;
            }
        }
    }
}
