namespace Pf2cc;

public readonly struct AbilityScore
{
    private readonly int _score;

    public AbilityScore(int score)
    {
        _score = score;
    }

    public static AbilityScore FromModifier(int modifier)
    {
        return (modifier + 5) * 2;
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

public record class AbilityArray(AbilityScore Strength, AbilityScore Dexterity, 
    AbilityScore Constitution, AbilityScore Intelligence, 
    AbilityScore Wisdom, AbilityScore Charisma)
{
    private const int BoostMax = 18;
    public static AbilityArray Default => new(10, 10, 10, 10, 10, 10);

    public static AbilityArray ApplyBoost(AbilityArray x, AbilityBoost y)
    {
        return new(
            AddBoostOr1(x.Strength, y.Strength),
            AddBoostOr1(x.Dexterity, y.Dexterity),
            AddBoostOr1(x.Constitution, y.Constitution),
            AddBoostOr1(x.Intelligence, y.Intelligence),
            AddBoostOr1(x.Wisdom, y.Wisdom),
            AddBoostOr1(x.Charisma, y.Charisma));

        static int AddBoostOr1(int ability, int boost)
        {
            if ((ability >= BoostMax) && (boost > 0))
            {
                return ability + 1;
            }
            else 
            {
                return ability + boost;
            }
        }
    }

    public static AbilityArray ApplyVoluntaryFlaw(AbilityArray abilities,
        AbilityBoost flaw1, AbilityBoost flaw2, AbilityBoost boost)
    {
        // I'm sorry...
        return ApplyBoost(ApplyBoost(ApplyBoost(abilities, flaw1), flaw2), boost);
    }

    public static AbilityArray operator +(AbilityArray x, AbilityBoost y)
    {
        return ApplyBoost(x, y);
    }
}

public record class AbilityBoost(int Strength, int Dexterity,
    int Constitution, int Intelligence, int Wisdom, int Charisma)
{
    private const int Boost = 2;
    private const int Flaw = (-2);

    public static AbilityBoost Zero => new(0, 0, 0, 0, 0, 0);
    public static AbilityBoost StrengthBoost => Zero with { Strength = Boost };
    public static AbilityBoost StrengthFlaw => Zero with { Strength = Flaw };
    public static AbilityBoost DexterityBoost => Zero with { Dexterity = Boost };
    public static AbilityBoost DexterityFlaw => Zero with { Dexterity = Flaw };
    public static AbilityBoost ConstitutionBoost => Zero with { Constitution = Boost };
    public static AbilityBoost ConstitutionFlaw => Zero with { Constitution = Flaw };
    public static AbilityBoost IntelligenceBoost => Zero with { Intelligence = Boost };
    public static AbilityBoost IntelligenceFlaw => Zero with { Intelligence = Flaw };
    public static AbilityBoost WisdomBoost => Zero with { Wisdom = Boost };
    public static AbilityBoost WisdomFlaw => Zero with { Wisdom = Flaw };
    public static AbilityBoost CharismaBoost => Zero with { Charisma = Boost };
    public static AbilityBoost CharismaFlaw => Zero with { Charisma = Flaw };
    
    public static AbilityBoost Add(AbilityBoost x, AbilityBoost y)
    {
        return new(
            AddWithZeroOrFail(x.Strength, y.Strength),
            AddWithZeroOrFail(x.Dexterity, y.Dexterity),
            AddWithZeroOrFail(x.Constitution, y.Constitution),
            AddWithZeroOrFail(x.Intelligence, y.Intelligence),
            AddWithZeroOrFail(x.Wisdom, y.Wisdom),
            AddWithZeroOrFail(x.Charisma, y.Charisma));

        // two equal boosts or flaws cannot be added together
        static int AddWithZeroOrFail(int x, int y)
        {
            // only add a number and zero, both numbers may be zero
            if ((x == 0) || (y == 0))
            {
                return x + y;
            }
            else
            {
                throw new Exception("Cannot add two of the same type of boost or flaw.");
            }
        }
    }

    public static AbilityBoost operator +(AbilityBoost x, AbilityBoost y)
    {
        return Add(x, y);
    }

    public List<AbilityBoost> FreeBoosts()
    {
        List<AbilityBoost> free = new();
        AddBoostIfZero(Strength, StrengthBoost);
        AddBoostIfZero(Dexterity, DexterityBoost);
        AddBoostIfZero(Constitution, ConstitutionBoost);
        AddBoostIfZero(Intelligence, IntelligenceBoost);
        AddBoostIfZero(Wisdom, WisdomBoost);
        AddBoostIfZero(Charisma, CharismaBoost);

        return free;

        void AddBoostIfZero(int score, AbilityBoost boost)
        {
            if (score == 0) free.Add(boost);
        }
    }
}