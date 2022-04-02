using Xunit;
using Pf2cc;

namespace Pf2cc.Lib.Tests;

public class AbilityScoreTest
{
    [Fact]
    public void TestAbilityScoreModifiers()
    {
        AbilityScore a = new(10);
        AbilityScore aModExpected = 0;
        AbilityScore b = new(9);
        AbilityScore bModExpected = -1;
        AbilityScore c = new(1);
        AbilityScore cModExpected = -5;
        AbilityScore d = new(20);
        AbilityScore dModExpected = 5;
        AbilityScore e = new(17);
        AbilityScore eModExpected = 3;

        AbilityScore aModActual = a.Modifier;
        AbilityScore bModActual = b.Modifier;
        AbilityScore cModActual = c.Modifier;
        AbilityScore dModActual = d.Modifier;
        AbilityScore eModActual = e.Modifier;

        Assert.Equal(aModActual, aModExpected);
        Assert.Equal(bModActual, bModExpected);
        Assert.Equal(cModActual, cModExpected);
        Assert.Equal(dModActual, dModExpected);
        Assert.Equal(eModActual, eModExpected);
    }

    [Fact]
    public void TestAbilityScoreAddition()
    {
        AbilityScore x = new(8);
        AbilityScore y = new(9);
        AbilityScore expected = new(17);

        AbilityScore actual = x + y;

        Assert.Equal(actual, expected);
    }

    [Fact]
    public void TestAbilityScoreSubtraction()
    {
        AbilityScore x = new(9);
        AbilityScore y = new(8);
        AbilityScore expected = new(1);

        AbilityScore actual = x - y;

        Assert.Equal(actual, expected);
    }

    [Fact]
    public void TestAbilityArrayAddition()
    {
        AbilityArray x = AbilityArray.Default;
        AbilityArray y = AbilityArray.Zero with { Strength = 8, Charisma = 9 };
        AbilityArray expected = new(18, 10, 10, 10, 10, 19);

        AbilityArray actual = x + y;

        Assert.Equal(actual, expected);
    }

    [Fact]
    public void TestAbilityArrayMultiOps()
    {
        AbilityArray x = AbilityArray.Default;
        AbilityArray y = AbilityArray.Zero with { Strength = (-2), Charisma = 5 };
        AbilityArray expected = new(8, 10, 10, 10, 10, 15);

        AbilityArray actual = x + y;

        Assert.Equal(actual, expected);
    }

    [Fact]
    public void TestAbilityArrayBoosts()
    {
        AbilityArray x = AbilityArray.Default with { Strength = 18, Wisdom = 16 };
        AbilityArray boosts =
            AbilityArray.StrengthBoost + AbilityArray.WisdomBoost + AbilityArray.CharismaFlaw;
        // should only be adding 1 to Strength
        AbilityArray expected = 
            AbilityArray.Default with { Strength = 19, Wisdom = 18, Charisma = 8 };

        AbilityArray actual = x + boosts;

        Assert.Equal(actual, expected);
    }
}