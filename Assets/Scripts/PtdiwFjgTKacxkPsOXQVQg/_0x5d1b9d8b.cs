using UnityEngine;

/// <summary>
/// The little that survives between runs: which route the player picked, the best
/// delivery count and accuracy per route, and a counter that makes every launch a
/// different attempt so two runs in a row are never the same layout.
/// </summary>
public static class _0x5d1b9d8b
{
    public static void Record(int _0xced66086, int _0x65bd9805, int _0x07ec6be5, bool _0x1a296bab)
    {
        if (_0x65bd9805 > BestDelivered(_0xced66086))
            PlayerPrefs.SetInt(BestKey + _0xced66086, _0x65bd9805);
        if (_0x07ec6be5 > BestAccuracy(_0xced66086))
            PlayerPrefs.SetInt(AccuracyKey + _0xced66086, _0x07ec6be5);
        if (_0x1a296bab)
            PlayerPrefs.SetInt(ClearedKey + _0xced66086, 1);
        PlayerPrefs.Save();
    }

    public static int BestDelivered(int _0xd4ea6984)
    {
        return PlayerPrefs.GetInt(BestKey + _0xd4ea6984, 0);
    }

    /// <summary>The best delivery count across every route, for the menu card.</summary>
    public static int BestDeliveredAnywhere()
    {
        int _0xb9735b71 = 0;
        for (int _0x859c6dca = 0; _0x859c6dca < _0x6f92d6a9.Routes.Length; _0x859c6dca++)
            _0xb9735b71 = Mathf.Max(_0xb9735b71, BestDelivered(_0x859c6dca));
        return _0xb9735b71;
    }

    public static int _0x8eed499e
    {
        get
        {
            return Mathf.Clamp(PlayerPrefs.GetInt(RouteKey, 0), 0, _0x6f92d6a9.Routes.Length - 1);
        }

        set
        {
            PlayerPrefs.SetInt(RouteKey, Mathf.Clamp(value, 0, _0x6f92d6a9.Routes.Length - 1));
            PlayerPrefs.Save();
        }
    }

    private static readonly string BestKey = _0x232c5884._0x2c3f7699(new byte[10] { 55, 36, 44, 41, 107, 39, 32, 54, 49, 107 }, 69);
    private static readonly string AttemptKey = _0x232c5884._0x2c3f7699(new byte[12] { 175, 188, 180, 177, 243, 188, 169, 169, 184, 176, 173, 169 }, 221);
    public static int BestAccuracy(int _0x8626783c)
    {
        return PlayerPrefs.GetInt(AccuracyKey + _0x8626783c, 0);
    }

    private static readonly string AccuracyKey = _0x232c5884._0x2c3f7699(new byte[9] { 201, 218, 210, 215, 149, 218, 216, 216, 149 }, 187);
    public static int BestAccuracyAnywhere()
    {
        int _0xf3f0a01b = 0;
        for (int _0x92f678a5 = 0; _0x92f678a5 < _0x6f92d6a9.Routes.Length; _0x92f678a5++)
            _0xf3f0a01b = Mathf.Max(_0xf3f0a01b, BestAccuracy(_0x92f678a5));
        return _0xf3f0a01b;
    }

    private static readonly string RouteKey = _0x232c5884._0x2c3f7699(new byte[10] { 137, 154, 146, 151, 213, 137, 148, 142, 143, 158 }, 251);
    /// <summary>A short haptic tick. No sound anywhere in this game (rule C.20).</summary>
    public static void Buzz()
    {
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            {
                try
                {
                    Handheld.Vibrate();
                }
                catch (System.Exception)
                {
                }
            }
#endif
        }
    }

    public static bool Cleared(int _0x86f5de2d)
    {
        return PlayerPrefs.GetInt(ClearedKey + _0x86f5de2d, 0) == 1;
    }

    private static readonly string ClearedKey = _0x232c5884._0x2c3f7699(new byte[13] { 64, 83, 91, 94, 28, 81, 94, 87, 83, 64, 87, 86, 28 }, 50);
    /// <summary>Hand out the next attempt number and remember it, so the generator
    /// draws a different yard on every entry into the game scene.</summary>
    public static int TakeAttempt()
    {
        int _0x4ac15b7d = PlayerPrefs.GetInt(AttemptKey, 0) + 1;
        PlayerPrefs.SetInt(AttemptKey, _0x4ac15b7d);
        PlayerPrefs.Save();
        return _0x4ac15b7d;
    }
}

internal static class _0x232c5884
{
    internal static string _0x2c3f7699(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}