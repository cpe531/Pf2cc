using static System.Console;
using Pf2cc;

WriteLine("Pf2cc");

DefaultOrRoll();

int DefaultOrRoll()
{
    Clear();
    WriteLine("Do you want to start with default ability scores or roll?");
    WriteLine("    1.) Default");
    WriteLine("    2.) Roll");
    Write(">");

    switch (ReadKey().KeyChar)
    {
        case '1': return 1;
        case '2': return 2;
        default:  return DefaultOrRoll();
    }
}