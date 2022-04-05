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
    public void TestAbilityBoostAddition()
    {
        AbilityBoost x = AbilityBoost.StrengthBoost;
        AbilityBoost y = AbilityBoost.CharismaBoost;
        AbilityBoost z = AbilityBoost.WisdomFlaw;
        AbilityBoost expected = new(2, 0, 0, 0, -2, 2);

        AbilityBoost actual = x + y + z;

        Assert.Equal(actual, expected);
    }

    [Fact]
    public void TestAbilityArrayAddition()
    {
        AbilityArray def = AbilityArray.Default;
        AbilityBoost boost =
            AbilityBoost.IntelligenceBoost + AbilityBoost.WisdomBoost + AbilityBoost.StrengthFlaw;
        AbilityArray defExpected = new(8, 10, 10, 12, 12, 10);

        AbilityArray high = new(10, 10, 10, 18, 18, 10);
        AbilityArray highExpected = new(8, 10, 10, 19, 19, 10);

        AbilityArray defActual = def + boost;
        AbilityArray highActual = high + boost;

        Assert.Equal(defActual, defExpected);
        Assert.Equal(highActual, highExpected);
    }

    [Fact]
    public void TestVoluntaryFlaws()
    {
        AbilityArray a = new(16, 10, 10, 10, 10, 10);
        AbilityBoost flaw1 = AbilityBoost.CharismaFlaw;
        AbilityBoost flaw2 = AbilityBoost.CharismaFlaw;
        AbilityBoost boost = AbilityBoost.StrengthBoost;
        AbilityArray expected = new(18, 10, 10, 10, 10, 6);

        AbilityArray actual = AbilityArray.ApplyVoluntaryFlaw(a, flaw1, flaw2, boost);

        Assert.Equal(actual, expected);
    }
}