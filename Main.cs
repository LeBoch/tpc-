using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Create characters
        var characters = new List<Character>
        {
            new Character("Hector", 75, 60, 50, 20, 100, 3),
            new Character("Simon", 70, 65, 55, 25, 90, 2),
            new Character("Anna", 80, 50, 60, 15, 110, 4)
        };

        // Start the battle
        var battle = new Battle(characters);
        battle.Start();
    }
}
