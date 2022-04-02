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

    public static AbilityArray StrengthBoost => Zero with { Strength = 2 };
    public static AbilityArray StrengthFlaw => Zero with { Strength = (-2) };
    public static AbilityArray DexterityBoost => Zero with { Dexterity = 2 };
    public static AbilityArray DexterityFlaw => Zero with { Dexterity = (-2) };
    public static AbilityArray ConstitutionBoost => Zero with { Constitution = 2 };
    public static AbilityArray ConstitutionFlaw => Zero with { Constitution = (-2) };
    public static AbilityArray IntelligenceBoost => Zero with { Intelligence = 2 };
    public static AbilityArray IntelligenceFlaw => Zero with { Intelligence = (-2) };
    public static AbilityArray WisdomBoost => Zero with { Wisdom = 2 };
    public static AbilityArray WisdomFlaw => Zero with { Wisdom = (-2) };
    public static AbilityArray CharismaBoost => Zero with { Charisma = 2 };
    public static AbilityArray CharismaFlaw => Zero with { Charisma = (-2) };


    public static AbilityArray operator +(AbilityArray x, AbilityArray y)
    {
        return new(
            AddBoostOr1(x.Strength, y.Strength), 
            AddBoostOr1(x.Dexterity, y.Dexterity),
            AddBoostOr1(x.Constitution, y.Constitution), 
            AddBoostOr1(x.Intelligence, y.Intelligence),
            AddBoostOr1(x.Wisdom, y.Wisdom), 
            AddBoostOr1(x.Charisma, y.Charisma));
    }

    private static int AddBoostOr1(int ability, int boost)
    {
        if ((ability >= 18) && (boost > 0))
        {
            return ability + 1;
        }
        else
        {
            return ability + boost;
        }
    }
}