using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class _0x29610cb2 : MonoBehaviour
{
    private static Vector2 _0xcd6bd380 = Vector2.zero;
    private static void ResolutionChanged()
    {
        _0xcd6bd380.x = Screen.width;
        _0xcd6bd380.y = Screen.height;
        _0x3f1a8951 = Screen.safeArea;
        ApplySafeAreaToAll();
        _0x3c7987d7.Invoke();
    }

    private RectTransform _0xaf16c62d;
    private static Rect _0x3f1a8951 = Rect.zero;
    private void OnDestroy()
    {
        if (_0xce7671db != null && _0xce7671db.Contains(this))
            _0xce7671db.Remove(this);
    }

    private static bool _0x73eefa7d;
    private static readonly List<_0x29610cb2> _0xce7671db = new();
    private Vector2 _0x99be792f;
    private Canvas _0x9a597747;
    private static void SafeAreaChanged()
    {
        _0x3f1a8951 = Screen.safeArea;
        ApplySafeAreaToAll();
    }

    private void Start()
    {
    }

    private CanvasScaler _0x8af4194e;
    private void Update()
    {
        if (_0xce7671db.Count == 0 || _0xce7671db[0] != this)
            return;
        if (Application.isMobilePlatform && Screen.orientation != _0x74218da9)
            OrientationChanged();
        if (Screen.safeArea != _0x3f1a8951)
            SafeAreaChanged();
        if (Screen.width != _0xcd6bd380.x || Screen.height != _0xcd6bd380.y)
            ResolutionChanged();
    }

    private void _0x0422f75b()
    {
        if (this._0xaf16c62d == null)
            return;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        if (screenWidth <= 0f || screenHeight <= 0f)
            return;
        Rect _0x696f0517 = Screen.safeArea;
        Vector2 _0xfaa41cfd = _0x696f0517.position;
        Vector2 _0xdb18476c = _0x696f0517.position + _0x696f0517.size;
        _0xfaa41cfd.x /= screenWidth;
        _0xfaa41cfd.y /= screenHeight;
        _0xdb18476c.x /= screenWidth;
        _0xdb18476c.y /= screenHeight;
        this._0xaf16c62d.anchorMin = _0xfaa41cfd;
        this._0xaf16c62d.anchorMax = _0xdb18476c;
        this._0xaf16c62d.offsetMin = Vector2.zero;
        this._0xaf16c62d.offsetMax = Vector2.zero;
        if (this._0x8af4194e == null)
            return;
        Vector2 _0x65916c01 = _0xdb18476c - _0xfaa41cfd;
        float _0xaf60b058 = 2f - _0x65916c01.x;
        float _0xdb33d23f = 2f - _0x65916c01.y;
        this._0x8af4194e.referenceResolution = this._0x99be792f * new Vector2(_0xaf60b058, _0xdb33d23f);
    }

    private static UnityEvent _0x3c7987d7 = new();
    private static void OrientationChanged()
    {
        _0x74218da9 = Screen.orientation;
        _0xcd6bd380.x = Screen.width;
        _0xcd6bd380.y = Screen.height;
        _0x3f1a8951 = Screen.safeArea;
        ApplySafeAreaToAll();
        _0x3c7987d7.Invoke();
    }

    private static void ApplySafeAreaToAll()
    {
        for (int _0x3c491529 = 0; _0x3c491529 < _0xce7671db.Count; _0x3c491529++)
            _0xce7671db[_0x3c491529]._0x0422f75b();
    }

    private static ScreenOrientation _0x74218da9 = ScreenOrientation.LandscapeLeft;
    private void Awake()
    {
        if (!_0xce7671db.Contains(this))
            _0xce7671db.Add(this);
        this._0x9a597747 = this.GetComponent<Canvas>();
        this._0x8af4194e = this.GetComponent<CanvasScaler>();
        if (this._0x8af4194e != null)
            this._0x99be792f = this._0x8af4194e.referenceResolution;
        this._0x57abea0b = this.GetComponent<RectTransform>();
        this._0xaf16c62d = this.transform.Find(_0x40f7b85c._0x1a986f4b(new byte[8] { 84, 102, 97, 98, 70, 117, 98, 102 }, 7)) as RectTransform;
        if (!_0x73eefa7d)
        {
            _0x74218da9 = Screen.orientation;
            _0xcd6bd380.x = Screen.width;
            _0xcd6bd380.y = Screen.height;
            _0x3f1a8951 = Screen.safeArea;
            _0x73eefa7d = true;
        }

        this._0x0422f75b();
    }

    private RectTransform _0x57abea0b;
}

internal static class _0x40f7b85c
{
    internal static string _0x1a986f4b(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}