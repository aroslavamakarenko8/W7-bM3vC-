using UnityEngine;

/// <summary>
/// The one palette the whole freight yard is painted from: a graphite night, an
/// amber signal as the primary accent, a cyan second voice and a green delivery
/// read-out. Alarm red is graphics only - it never carries a letter, because the
/// shared font outline is near-black and red text against it sits at the very
/// edge of the contrast floor (rule C.14).
/// </summary>
public static class _0x5b09b348
{
    /// <summary>#1E2330 - every card, chip and plate body.</summary>
    public static readonly Color Surface = new Color(0.11764706f, 0.13725491f, 0.1882353f, 1f);
    /// <summary>The same cream at three quarters, for captions under a value.</summary>
    public static readonly Color TextSecondary = new Color(1f, 0.94509804f, 0.8392157f, 0.75f);
    /// <summary>#F5C442 - the signal amber: PLAY, panel frames, the run clock.</summary>
    public static readonly Color Amber = new Color(0.9607843f, 0.76862746f, 0.25882354f, 1f);
    /// <summary>#0B0D13 - the font material outline; also the contour of every plate.</summary>
    public static readonly Color Ink = new Color(0.043137256f, 0.050980393f, 0.07450981f, 1f);
    /// <summary>The four crate colours, indexed by crate id.</summary>
    public static readonly Color[] Crates =
    {
        Amber,
        Cyan,
        Green,
        Alarm
    };
    public static Color Fade(Color _0xa4ada224, float _0x5abe87cd)
    {
        return new Color(_0xa4ada224.r, _0xa4ada224.g, _0xa4ada224.b, _0x5abe87cd);
    }

    /// <summary>#2A3142 - a surface that is switched on / selected.</summary>
    public static readonly Color SurfaceLit = new Color(0.16470589f, 0.19215687f, 0.25882354f, 1f);
    /// <summary>#37B8CC - the second voice: the active track, the head of the order strip.</summary>
    public static readonly Color Cyan = new Color(0.21568628f, 0.72156864f, 0.8f, 1f);
    /// <summary>#171A22 - the graphite the whole night is built on.</summary>
    public static readonly Color Base = new Color(0.09019608f, 0.10196079f, 0.13333334f, 1f);
    /// <summary>#E94B3D - hazards and dead signals. Graphics only, never text.</summary>
    public static readonly Color Alarm = new Color(0.9137255f, 0.29411766f, 0.23921569f, 1f);
    /// <summary>#7AC84F - delivered, cleared, alive.</summary>
    public static readonly Color Green = new Color(0.47843137f, 0.78431374f, 0.30980393f, 1f);
    /// <summary>#0E1017 - the deepest layer: gradient bottoms, bar tracks, shades.</summary>
    public static readonly Color Deep = new Color(0.05490196f, 0.0627451f, 0.09019608f, 1f);
    /// <summary>#FFF1D6 - the default text colour.</summary>
    public static readonly Color TextPrimary = new Color(1f, 0.94509804f, 0.8392157f, 1f);
}