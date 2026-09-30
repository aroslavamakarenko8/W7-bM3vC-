using UnityEngine;

/// <summary>
/// One row of the yard as the generator planned it, before the spawner knows
/// where the cart is standing. Lanes are 0..2; -1 means "nothing on this row".
/// Crate colours are stored as an OFFSET from the colour the order strip is
/// currently asking for, so a row keeps its shape while the head of the order
/// moves underneath it.
/// </summary>
public sealed class _0xed49d1c5
{
    /// <summary>A trackside signal mast on the left (-1), right (1) or neither (0).</summary>
    public int MarkerSide;
    /// <summary>Lanes blocked by a barrier. Length 0, 1 or 2.</summary>
    public int[] HazardLanes = new int[0];
    /// <summary>Lane carrying a crate of the wrong colour, or -1.</summary>
    public int DecoyLane = -1;
    /// <summary>Lane carrying the crate the order wants, or -1.</summary>
    public int WantedLane = -1;
    /// <summary>1..3 - how far the decoy's colour sits from the wanted one.</summary>
    public int DecoyOffset = 1;
    /// <summary>Which barrier art this row uses.</summary>
    public int HazardVariant;
}

/// <summary>
/// A whole route: the colour sequence the strip walks through, and the rows that
/// scroll past. Both come from one seeded generator, so two attempts on the same
/// route differ in layout and decoys, not only in the number in the HUD.
/// </summary>
public sealed class _0xbddf612c
{
    public int Seed;
    public int _0xa819aef1(int _0x64f70889)
    {
        if (this.Sequence.Length == 0)
            return 0;
        return this.Sequence[Mathf.Clamp(_0x64f70889, 0, this.Sequence.Length - 1)];
    }

    /// <summary>True when the layout came from the safety net, not the generator.</summary>
    public bool FromFallback;
    public int _0x8a0f87ee
    {
        get
        {
            return this.Sequence.Length;
        }
    }

    public _0xed49d1c5[] Rows = new _0xed49d1c5[0];
    public int Attempt;
    public int[] Sequence = new int[0];
    public int RouteIndex;
    /// <summary>Rows the greedy solver needed to finish, for the log line.</summary>
    public int SolvedRows;
    /// <summary>Seconds the greedy solver needed, for the log line.</summary>
    public float SolvedSeconds;
}