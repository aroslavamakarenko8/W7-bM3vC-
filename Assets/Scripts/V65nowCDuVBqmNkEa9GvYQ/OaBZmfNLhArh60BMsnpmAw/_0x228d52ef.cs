using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class _0x228d52ef
{
    public static class _0x87f8de56
    {
        public static readonly int PAUSE = 6;
        public static readonly int WIN = 7;
        public static readonly int LOSE = 8;
    }

    public static class _0x837759f6
    {
        public static readonly int SPLASH = 0;
        public static readonly int DEFAULT = 1;
        public static readonly int EMPTY = 2;
        public static readonly int TUTORIAL0 = 13;
        public static readonly int TUTORIAL1 = 14;
        public static readonly int TUTORIAL2 = 15;
        public static readonly int TUTORIAL3 = 16;
        public static readonly int TUTORIAL4 = 17;
        public static readonly int TUTORIAL5 = 18;
        public static readonly int TUTORIAL6 = 19;
    }

    public static class _0x8a0db87c
    {
        public static readonly int SCENE_0 = 0;
        public static readonly int SCENE_1 = 1;
    }

    public class _0x050d3ccd
    {
        private static readonly _0x050d3ccd _0x701f4c33 = new();
        public static readonly _0x050d3ccd[] ALL_SCENES_SETTING_SINGLETONS =
        {
            _0x701f4c33,
            _0x701f4c33,
            _0x701f4c33,
        };
        private int _0xbf8f6e1b => 0;
        private int _0x646da4ee => 10;
        private string _0xbfa578fa => _0xd13ae10b._0xa2312e20(new byte[4] { 236, 196, 207, 212 }, 161);
        private string _0x1d83973f => _0xd13ae10b._0xa2312e20(new byte[8] { 229, 236, 255, 236, 229, 210, 153, 212 }, 169);

        private int _0xdfd38814
        {
            get
            {
                if (!PlayerPrefs.HasKey(_0xd13ae10b._0xa2312e20(new byte[25] { 255, 201, 206, 206, 217, 210, 200, 251, 208, 211, 222, 221, 208, 255, 212, 221, 204, 200, 217, 206, 245, 210, 216, 217, 196 }, 188)))
                    PlayerPrefs.SetInt(_0xd13ae10b._0xa2312e20(new byte[25] { 240, 198, 193, 193, 214, 221, 199, 244, 223, 220, 209, 210, 223, 240, 219, 210, 195, 199, 214, 193, 250, 221, 215, 214, 203 }, 179), 0);
                return PlayerPrefs.GetInt(_0xd13ae10b._0xa2312e20(new byte[25] { 43, 29, 26, 26, 13, 6, 28, 47, 4, 7, 10, 9, 4, 43, 0, 9, 24, 28, 13, 26, 33, 6, 12, 13, 16 }, 104));
            }

            set => PlayerPrefs.SetInt(_0xd13ae10b._0xa2312e20(new byte[25] { 43, 29, 26, 26, 13, 6, 28, 47, 4, 7, 10, 9, 4, 43, 0, 9, 24, 28, 13, 26, 33, 6, 12, 13, 16 }, 104), value);
        }

        public int _0x5c19c4ee
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0xbfa578fa}CurrentLevelIndex"))
                    PlayerPrefs.SetInt($"{this._0xbfa578fa}CurrentLevelIndex", 0);
                return PlayerPrefs.GetInt($"{this._0xbfa578fa}CurrentLevelIndex");
            }

            set => PlayerPrefs.SetInt($"{this._0xbfa578fa}CurrentLevelIndex", value);
        }

        public int _0x4c792aee
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0xbfa578fa}BestScore"))
                    this._0x4c792aee = 0;
                return PlayerPrefs.GetInt($"{this._0xbfa578fa}BestScore");
            }

            set => PlayerPrefs.SetInt($"{this._0xbfa578fa}BestScore", value);
        }

        public bool _0xa872f7b9
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0xbfa578fa}IsGameTutorPassed"))
                    PlayerPrefs.SetInt($"{this._0xbfa578fa}IsGameTutorPassed", Convert.ToInt32(false));
                return PlayerPrefs.GetInt($"{this._0xbfa578fa}IsGameTutorPassed") == 1;
            }

            set => PlayerPrefs.SetInt($"{this._0xbfa578fa}IsGameTutorPassed", Convert.ToInt32(value));
        }
    }

    public static class _0x9d930ff8
    {
        public static int _0x8709d36a
        {
            get
            {
                if (!PlayerPrefs.HasKey(_0xd13ae10b._0xa2312e20(new byte[5] { 152, 180, 178, 181, 168 }, 219)))
                    PlayerPrefs.SetInt(_0xd13ae10b._0xa2312e20(new byte[5] { 104, 68, 66, 69, 88 }, 43), 0);
                return PlayerPrefs.GetInt(_0xd13ae10b._0xa2312e20(new byte[5] { 149, 185, 191, 184, 165 }, 214));
            }

            set
            {
                PlayerPrefs.SetInt(_0xd13ae10b._0xa2312e20(new byte[5] { 224, 204, 202, 205, 208 }, 163), value);
                _0x639e6ff3.Instance._0xf368c329();
            }
        }
    }
}

internal static class _0xd13ae10b
{
    internal static string _0xa2312e20(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}