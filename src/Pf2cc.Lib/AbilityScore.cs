namespace Pf2cc;

public readonly struct AbilityScore
{
    private readonly int _score;

    public AbilityScore(int score)
    {
        _score = score;
    }

    public int Modifier => (_score / 2) - 5;
    public static implicit operator int(AbilityScore s) => s._score;
    public static implicit operator AbilityScore(int s) => new(s);
    public static AbilityScore operator +(AbilityScore x, AbilityScore y)
    {
        return new(x._score + y._score);
    }
    public static AbilityScore operator -(AbilityScore x, AbilityScore y)
    {
        return new(x._score - y._score);
    }
    public override string ToString() => _score.ToString();
}

public record AbilityArray(AbilityScore Strength, AbilityScore Dexterity, AbilityScore Constitution,
    AbilityScore Intelligence, AbilityScore Wisdom, AbilityScore Charisma)
{
    public static AbilityArray Default => new(10, 10, 10, 10, 10, 10);
    public static AbilityArray Zero => new(0, 0, 0, 0, 0, 0);

    public static AbilityArray operator +(AbilityArray x, AbilityArray y)
    {
        return new(
            x.Strength + y.Strength, 
            x.Dexterity + y.Dexterity,
            x.Constitution + y.Constitution, 
            x.Intelligence + y.Intelligence,
            x.Wisdom + y.Wisdom, 
            x.Charisma + y.Charisma);
    }
    public static AbilityArray operator -(AbilityArray x, AbilityArray y)
    {
        return new(
            x.Strength - y.Strength, 
            x.Dexterity - y.Dexterity,
            x.Constitution - y.Constitution, 
            x.Intelligence - y.Intelligence,
            x.Wisdom - y.Wisdom, 
            x.Charisma - y.Charisma);
    }
}