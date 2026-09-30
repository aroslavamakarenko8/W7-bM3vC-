using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class _0x719ea4ca : MonoBehaviour
{
    private static Vector2 _0x42174a4f = Vector2.zero;
    private RectTransform _0x76dddd73;
    private void Update()
    {
        if (_0x9f2300ad[0] != this)
            return;
        if (Application.isMobilePlatform && Screen.orientation != _0x2568ec4d)
            OrientationChanged();
        if (Screen.safeArea != _0x3c84738c)
            SafeAreaChanged();
        if (Screen.width != _0x42174a4f.x || Screen.height != _0x42174a4f.y)
            ResolutionChanged();
    }

    private Canvas _0x4a74109c;
    private static Rect _0x3c84738c = Rect.zero;
    private RectTransform _0x04b43ca4;
    private static ScreenOrientation _0x2568ec4d = ScreenOrientation.LandscapeLeft;
    private static bool _0x31ac4698;
    private static void ResolutionChanged()
    {
        _0x42174a4f.x = Screen.width;
        _0x42174a4f.y = Screen.height;
        _0x62b975b2.Invoke();
    }

    private void _0xd758de62()
    {
        if (this._0x76dddd73 == null)
            return;
        Rect _0xae428faf = Screen.safeArea;
        Vector2 _0x52fddcc8 = _0xae428faf.position;
        Vector2 _0xa021f955 = _0xae428faf.position + _0xae428faf.size;
        _0x52fddcc8.x /= this._0x4a74109c.pixelRect.width;
        _0x52fddcc8.y /= this._0x4a74109c.pixelRect.height;
        _0xa021f955.x /= this._0x4a74109c.pixelRect.width;
        _0xa021f955.y /= this._0x4a74109c.pixelRect.height;
        this._0x76dddd73.anchorMin = _0x52fddcc8;
        this._0x76dddd73.anchorMax = _0xa021f955;
    }

    private static UnityEvent _0x62b975b2 = new();
    private static void OrientationChanged()
    {
        _0x2568ec4d = Screen.orientation;
        _0x42174a4f.x = Screen.width;
        _0x42174a4f.y = Screen.height;
        _0x62b975b2.Invoke();
    }

    private static readonly List<_0x719ea4ca> _0x9f2300ad = new();
    private static void SafeAreaChanged()
    {
        _0x3c84738c = Screen.safeArea;
        for (int _0xc9eb5260 = 0; _0xc9eb5260 < _0x9f2300ad.Count; _0xc9eb5260++)
            _0x9f2300ad[_0xc9eb5260]._0xd758de62();
    }

    private void Awake()
    {
        if (!_0x9f2300ad.Contains(this))
            _0x9f2300ad.Add(this);
        this._0x4a74109c = this.GetComponent<Canvas>();
        this._0x04b43ca4 = this.GetComponent<RectTransform>();
        this._0x76dddd73 = this.transform.Find(_0xf8809c46._0x82928632(new byte[8] { 104, 90, 93, 94, 122, 73, 94, 90 }, 59)) as RectTransform;
        if (!_0x31ac4698)
        {
            _0x2568ec4d = Screen.orientation;
            _0x42174a4f.x = Screen.width;
            _0x42174a4f.y = Screen.height;
            _0x3c84738c = Screen.safeArea;
            _0x31ac4698 = true;
        }

        this._0xd758de62();
    }

    private void OnDestroy()
    {
        if (_0x9f2300ad != null && _0x9f2300ad.Contains(this))
            _0x9f2300ad.Remove(this);
    }
}

internal static class _0xf8809c46
{
    internal static string _0x82928632(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}