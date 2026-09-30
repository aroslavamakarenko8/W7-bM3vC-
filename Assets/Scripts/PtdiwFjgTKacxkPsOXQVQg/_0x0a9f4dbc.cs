using UnityEngine;

/// <summary>
/// One route of the freight line: how many crates it asks for, how fast the yard
/// scrolls past, how often a row arrives, how long the line clock runs and how
/// generous the spawn is towards a player who never moves.
/// </summary>
public sealed class _0x0a9f4dbc
{
    public int HazardFromRow;
    public float ScrollSpeed;
    public int Crates;
    public float LineSeconds;
    public int HazardMax;
    public float RowInterval;
    public string Caption;
    public float GraceChance;
}

/// <summary>
/// Every number the run is built from. Nothing here is a screen size: the world
/// layout is derived from the camera at runtime (rule C.0) and only the ratios
/// live in this file, so the same values hold on any aspect.
/// </summary>
public static class _0x6f92d6a9
{
    public const float ClockWarnSeconds = 15f;
    /// <summary>How many crates a bot has to be able to deliver inside the clock,
    /// with this much slack, before a generated route is accepted.</summary>
    public const float SolverSlackSeconds = 12f;
    public const float SwipeSeconds = 0.28f;
    public const float CartFraction = 0.79f;
    public const int MenuCrateOrder = -5;
    public const float LaneSlideSeconds = 0.16f;
    public const int HazardOrder = -7;
    // Swipe recognition: a horizontal flick wins over a vertical one, and one
    // flick is one track - the queue never stacks.
    public const float SwipePixels = 45f;
    public const int OrderWindow = 5;
    public const int TrailOrder = -5;
    public const float HazardWideFraction = 0.68f;
    // -- world layout, all as fractions of the camera --------------------------
    public const float RoadFraction = 0.86f;
    // -- generator weights (per cent, summing to 100) --------------------------
    public const int WeightSolo = 35;
    public const int WeightPair = 30;
    // -- run rules -------------------------------------------------------------
    public const int StrikeBudget = 3;
    public const float StreakBonusSeconds = 2.5f;
    /// <summary>mm:ss, always two digits a side, so the HUD never reflows.</summary>
    public static string Clock(float _0x7691ef48)
    {
        int _0xbf40f6ec = Mathf.Max(0, Mathf.CeilToInt(_0x7691ef48));
        int _0x1cb38cb8 = _0xbf40f6ec / 60;
        int _0xf906561f = _0xbf40f6ec % 60;
        return (_0x1cb38cb8 < 10 ? _0xce2fbc72._0x5e51ca95(new byte[1] { 89 }, 105) : string.Empty) + _0x1cb38cb8 + _0xce2fbc72._0x5e51ca95(new byte[1] { 135 }, 189) + (_0xf906561f < 10 ? _0xce2fbc72._0x5e51ca95(new byte[1] { 166 }, 150) : string.Empty) + _0xf906561f;
    }

    public const int MarkerOrder = -15;
    public const float CrateFraction = 0.59f;
    public const int CrateKinds = 4;
    public static readonly _0x0a9f4dbc[] Routes =
    {
        new _0x0a9f4dbc
        {
            Caption = _0xce2fbc72._0x5e51ca95(new byte[10] { 73, 92, 75, 75, 64, 46, 66, 71, 64, 75 }, 14),
            Crates = 26,
            ScrollSpeed = 3.2f,
            RowInterval = 1.35f,
            LineSeconds = 100f,
            GraceChance = 0.3f,
            HazardFromRow = 5,
            HazardMax = 1,
        },
        new _0x0a9f4dbc
        {
            Caption = _0xce2fbc72._0x5e51ca95(new byte[10] { 176, 188, 179, 180, 163, 209, 189, 184, 191, 180 }, 241),
            Crates = 32,
            ScrollSpeed = 3.8f,
            RowInterval = 1.15f,
            LineSeconds = 105f,
            GraceChance = 0.22f,
            HazardFromRow = 3,
            HazardMax = 2,
        },
        new _0x0a9f4dbc
        {
            Caption = _0xce2fbc72._0x5e51ca95(new byte[8] { 188, 171, 170, 206, 162, 167, 160, 171 }, 238),
            Crates = 38,
            ScrollSpeed = 4.4f,
            RowInterval = 1f,
            LineSeconds = 110f,
            GraceChance = 0.15f,
            HazardFromRow = 1,
            HazardMax = 2,
        },
    };
    public const int CartOrder = -4;
    public const float SpawnMargin = 0.6f;
    public const float SwipeDominance = 1.2f;
    public const int StreakBonusEvery = 5;
    public const float IntroSeconds = 0.8f;
    public const float CartDepthFraction = 0.61f;
    public const int LaneGlowOrder = -16;
    public const int WeightGuard = 25;
    /// <summary>Two-digit counter, so "07 / 26" keeps its width all run long.</summary>
    public static string Pad(int _0x9217f391)
    {
        return _0x9217f391 < 10 ? _0xce2fbc72._0x5e51ca95(new byte[1] { 127 }, 79) + _0x9217f391 : _0x9217f391.ToString();
    }

    public const int Lanes = 3;
    public const int MenuFanOrder = -12;
    public const float HintWideSeconds = 10f;
    public const float PopHoldSeconds = 6f;
    public const float RailTileFraction = 0.48f;
    public const int MenuCartOrder = -6;
    // -- sorting orders --------------------------------------------------------
    // The background canvas draws at -30 and the pops at +10, so every world
    // sprite has to live strictly between them (rule C.21). No two layers that
    // can overlap share a number.
    public const int RailOrder = -18;
    public const int CrateOrder = -6;
    public static _0x0a9f4dbc Route(int _0x4d710bb0)
    {
        return Routes[Mathf.Clamp(_0x4d710bb0, 0, Routes.Length - 1)];
    }

    public const float HazardTallFraction = 0.54f;
    public static readonly string[] CrateNames =
    {
        _0xce2fbc72._0x5e51ca95(new byte[5] { 182, 186, 181, 178, 165 }, 247),
        _0xce2fbc72._0x5e51ca95(new byte[4] { 28, 6, 30, 17 }, 95),
        _0xce2fbc72._0x5e51ca95(new byte[5] { 167, 178, 165, 165, 174 }, 224),
        _0xce2fbc72._0x5e51ca95(new byte[3] { 145, 134, 135 }, 195)
    };
}

internal static class _0xce2fbc72
{
    internal static string _0x5e51ca95(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}