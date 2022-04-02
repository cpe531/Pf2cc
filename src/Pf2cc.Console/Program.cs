using Pf2cc;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine($"D4   - {Dice.D4}");
Console.WriteLine($"D6   - {Dice.D6}");
Console.WriteLine($"D8   - {Dice.D8}");
Console.WriteLine($"D10  - {Dice.D10}");
Console.WriteLine($"D12  - {Dice.D12}");
Console.WriteLine($"D20  - {Dice.D20}");
Console.WriteLine($"D100 - {Dice.D100}");
Console.WriteLine();

Console.WriteLine("Rolling 4d6 dropping the lowest...");
Console.WriteLine(Dice.Roll4D6DropLowest());
Console.WriteLine(Dice.Roll4D6DropLowest());
Console.WriteLine(Dice.Roll4D6DropLowest());
Console.WriteLine(Dice.Roll4D6DropLowest());
Console.WriteLine(Dice.Roll4D6DropLowest());
Console.WriteLine(Dice.Roll4D6DropLowest());


