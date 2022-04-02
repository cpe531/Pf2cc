namespace Pf2cc;

public sealed class Dice
{
    public static int D4 => Random.Shared.Next(1, 5);
    public static int D6 => Random.Shared.Next(1, 7);
    public static int D8 => Random.Shared.Next(1, 8);
    public static int D10 => Random.Shared.Next(1, 11);
    public static int D12 => Random.Shared.Next(1, 13);
    public static int D20 => Random.Shared.Next(1, 21);
    public static int D100 => Random.Shared.Next(1, 101);

    public static int Roll3D6()
    {
        return D6 + D6 + D6;
    }

    public static int Roll4D6DropLowest()
    {
        int[] ds = { D6, D6, D6, D6 };
        Array.Sort(ds);
        return ds[1] + ds[2] + ds[3];   // return the sum of all but the first element
    }
}
