using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Every layer of one generated button, handed back so a caller can restyle it
/// later through a reference instead of a name lookup.
/// </summary>
public sealed class _0x8d17d077
{
    public Button Button;
    public RectTransform Root;
    public Image Edge;
    public Image Fill;
    public Image Icon;
    public TextMeshProUGUI Caption;
}

/// <summary>
/// The UGUI construction kit for the night yard: a dark card inside a bright
/// signal frame, no blur, no gradient fills. Every label it builds has word wrap
/// OFF, autosize ON and a floor that stays above the readable minimum, so a line
/// breaks only where the string says so (rule C.10 / C.12).
/// </summary>
public static class _0xc3776c65
{
    public static TextMeshProUGUI Label(Transform _0x78322d51, string _0x10d93518, string _0x70e19ad0, Vector2 _0x7ff8a6ea, Vector2 _0x9cdfbcbf, Vector2 _0x9f5651a8, float _0xe2b5e616, float _0x3e4c9604, Color _0xee900b64, TMP_FontAsset _0xd724d140, TextAlignmentOptions _0xf042527c)
    {
        RectTransform _0x5268190c = Node(_0x78322d51, _0x10d93518, _0x7ff8a6ea, _0x9cdfbcbf, _0x9f5651a8);
        TextMeshProUGUI _0x9b32131c = _0x5268190c.gameObject.AddComponent<TextMeshProUGUI>();
        if (_0xd724d140 != null)
            _0x9b32131c.font = _0xd724d140;
        _0x9b32131c.text = _0x70e19ad0;
        _0x9b32131c.color = _0xee900b64;
        _0x9b32131c.alignment = _0xf042527c;
        _0x9b32131c.raycastTarget = false;
        Wrap(_0x9b32131c, _0xe2b5e616, _0x3e4c9604);
        return _0x9b32131c;
    }

    public static Button Cta(Transform _0x18763e3f, string _0x0451c43b, string _0x28fbad0b, Vector2 _0xbe67306c, Vector2 _0x23f454bf, Vector2 _0x86f4ce4a, Sprite _0x1707ce0c, Sprite _0x155f0559, Color _0x7283f808, Color _0x6aed8587, Color _0x3506a99d, TMP_FontAsset _0xcce9959c, float _0xa074da52)
    {
        return CtaParts(_0x18763e3f, _0x0451c43b, _0x28fbad0b, _0xbe67306c, _0x23f454bf, _0x86f4ce4a, _0x1707ce0c, _0x155f0559, _0x7283f808, _0x6aed8587, _0x3506a99d, _0xcce9959c, _0xa074da52).Button;
    }

    /// <summary>
    /// Switch off everything the template authored inside a panel body, leaving the
    /// pops alone - they are raised by the template and must survive the wipe.
    /// </summary>
    public static void ClearTemplateChrome(Transform _0x6fde750e)
    {
        if (_0x6fde750e == null)
            return;
        for (int _0x5b6fd50b = _0x6fde750e.childCount - 1; _0x5b6fd50b >= 0; _0x5b6fd50b--)
        {
            Transform _0x9e0ba4ca = _0x6fde750e.GetChild(_0x5b6fd50b);
            if (_0x9e0ba4ca == null)
                continue;
            if (_0x9e0ba4ca.GetComponentInChildren<_0x9297c78f>(true) != null)
                continue;
            _0x9e0ba4ca.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// A fresh RectTransform starts 100x100 at the centre, which would silently
    /// resolve every child anchor against 100x100 instead of the real canvas. This
    /// makes a host that covers its parent exactly.
    /// </summary>
    public static RectTransform Host(Transform _0x1cb837a2, string _0x2f901a16)
    {
        GameObject _0xfffd9f26 = new GameObject(_0x2f901a16, typeof(RectTransform));
        _0xfffd9f26.transform.SetParent(_0x1cb837a2, false);
        RectTransform _0xee2e7e22 = _0xfffd9f26.GetComponent<RectTransform>();
        _0xee2e7e22.anchorMin = Vector2.zero;
        _0xee2e7e22.anchorMax = Vector2.one;
        _0xee2e7e22.pivot = new Vector2(0.5f, 0.5f);
        _0xee2e7e22.anchoredPosition = Vector2.zero;
        _0xee2e7e22.sizeDelta = Vector2.zero;
        _0xee2e7e22.localScale = Vector3.one;
        return _0xee2e7e22;
    }

    public static void SanitiseTutorials(TMP_FontAsset _0xa9225071)
    {
        _0x76586aa9 _0xe75bc432 = _0x76586aa9.Instance;
        if (_0xe75bc432 == null || _0xe75bc432.Panels == null)
            return;
        int[] _0x57d6b87b =
        {
            _0x228d52ef._0x837759f6.TUTORIAL0,
            _0x228d52ef._0x837759f6.TUTORIAL1,
            _0x228d52ef._0x837759f6.TUTORIAL2,
            _0x228d52ef._0x837759f6.TUTORIAL3,
            _0x228d52ef._0x837759f6.TUTORIAL4,
            _0x228d52ef._0x837759f6.TUTORIAL5,
            _0x228d52ef._0x837759f6.TUTORIAL6,
        };
        for (int _0x4d40f75f = 0; _0x4d40f75f < _0x57d6b87b.Length; _0x4d40f75f++)
        {
            int _0x70f228b8 = _0x57d6b87b[_0x4d40f75f];
            if (_0x70f228b8 < 0 || _0x70f228b8 >= _0xe75bc432.Panels.Count)
                continue;
            _0x6330b92a _0x17bc4032 = _0xe75bc432.Panels[_0x70f228b8];
            if (_0x17bc4032 == null || _0x17bc4032.Content == null)
                continue;
            TMP_Text[] _0x3929860b = _0x17bc4032.Content.GetComponentsInChildren<TMP_Text>(true);
            for (int _0xb07051c0 = 0; _0xb07051c0 < _0x3929860b.Length; _0xb07051c0++)
            {
                if (_0x3929860b[_0xb07051c0] == null)
                    continue;
                string _0xcfe6fba6 = string.Empty;
                if (_0xb07051c0 == 0 && _0x4d40f75f < _0x1bea3c1a.Length)
                    _0xcfe6fba6 = _0x1bea3c1a[_0x4d40f75f];
                else if (_0xb07051c0 == 1 && _0x4d40f75f < _0x623f45a1.Length)
                    _0xcfe6fba6 = _0x623f45a1[_0x4d40f75f];
                _0x3929860b[_0xb07051c0].text = _0xcfe6fba6;
                _0x3929860b[_0xb07051c0].color = _0xb07051c0 == 0 ? _0x5b09b348.Amber : _0x5b09b348.TextPrimary;
                if (_0xa9225071 != null)
                    _0x3929860b[_0xb07051c0].font = _0xa9225071;
                Wrap(_0x3929860b[_0xb07051c0], _0xb07051c0 == 0 ? 68f : 46f, _0xb07051c0 == 0 ? 50f : 36f);
            }
        }
    }

    /// <summary>
    /// A tappable signal plate. Children go background, then icon, then caption, so
    /// the label is always the last sibling and always drawn on top (rule C.13).
    /// </summary>
    public static _0x8d17d077 CtaParts(Transform _0x827db188, string _0xa4fdb7ab, string _0xc8c48376, Vector2 _0xeb79cdef, Vector2 _0xdc33a338, Vector2 _0x868438e4, Sprite _0xd3a9ad6f, Sprite _0x4bba3965, Color _0x0999e1a2, Color _0xfd5b4ccd, Color _0x7e42def9, TMP_FontAsset _0xfd8922d9, float _0xacd39d17)
    {
        RectTransform _0x21462451 = Node(_0x827db188, _0xa4fdb7ab, _0xeb79cdef, _0xdc33a338, _0x868438e4);
        _0x8d17d077 _0x86e0de1c = new _0x8d17d077();
        _0x86e0de1c.Root = _0x21462451;
        // Every Image in this template's BASE_PANEL ships with raycastTarget off, so
        // a button needs a graphic of its own that accepts the pointer.
        Image _0x49382ba6 = _0x21462451.gameObject.AddComponent<Image>();
        _0x49382ba6.sprite = _0xd3a9ad6f;
        _0x49382ba6.type = _0xd3a9ad6f == null ? Image.Type.Simple : Image.Type.Sliced;
        _0x49382ba6.color = new Color(1f, 1f, 1f, 0.004f);
        _0x49382ba6.raycastTarget = true;
        _0x49382ba6.canvasRenderer.cullTransparentMesh = false;
        _0x86e0de1c.Edge = Block(_0x21462451, _0xa707de5f._0x1b8ee839(new byte[8] { 123, 76, 89, 126, 74, 89, 85, 93 }, 56), new Vector2(0.5f, 0.5f), Vector2.zero, _0x868438e4, _0xd3a9ad6f, _0xfd5b4ccd);
        _0x86e0de1c.Fill = Block(_0x21462451, _0xa707de5f._0x1b8ee839(new byte[7] { 37, 18, 7, 32, 15, 10, 10 }, 102), new Vector2(0.5f, 0.5f), Vector2.zero, _0x868438e4 - new Vector2(FramePixels * 2f, FramePixels * 2f), _0xd3a9ad6f, _0x0999e1a2);
        float _0x96b183f2 = 0f;
        if (_0x4bba3965 != null)
        {
            float _0x57a63205 = Mathf.Min(48f, _0x868438e4.y * 0.5f);
            _0x86e0de1c.Icon = Block(_0x21462451, _0xa707de5f._0x1b8ee839(new byte[7] { 144, 167, 178, 154, 176, 188, 189 }, 211), new Vector2(0.5f, 0.5f), new Vector2(string.IsNullOrEmpty(_0xc8c48376) ? 0f : -(_0x868438e4.x * 0.5f - _0x57a63205 * 0.85f), 0f), new Vector2(_0x57a63205, _0x57a63205), _0x4bba3965, _0x7e42def9);
            _0x86e0de1c.Icon.type = Image.Type.Simple;
            _0x96b183f2 = string.IsNullOrEmpty(_0xc8c48376) ? 0f : _0x57a63205 * 0.6f;
        }

        if (!string.IsNullOrEmpty(_0xc8c48376))
            _0x86e0de1c.Caption = Label(_0x21462451, _0xa707de5f._0x1b8ee839(new byte[7] { 94, 105, 124, 73, 120, 101, 105 }, 29), _0xc8c48376, new Vector2(0.5f, 0.5f), new Vector2(_0x96b183f2, 0f), new Vector2(_0x868438e4.x - 56f - _0x96b183f2, _0x868438e4.y - 26f), _0xacd39d17, _0xacd39d17 * 0.72f, _0x7e42def9, _0xfd8922d9, TextAlignmentOptions.Center);
        // The press tint multiplies the FILL. Tinting the near-invisible hit layer
        // would be no feedback at all, and rule C.7 wants a press to be seen.
        Button _0x31b6f847 = _0x21462451.gameObject.AddComponent<Button>();
        _0x31b6f847.targetGraphic = _0x86e0de1c.Fill != null ? _0x86e0de1c.Fill : (Graphic)_0x49382ba6;
        ColorBlock _0x5b9952d1 = _0x31b6f847.colors;
        _0x5b9952d1.normalColor = Color.white;
        _0x5b9952d1.highlightedColor = Color.white;
        _0x5b9952d1.pressedColor = new Color(0.66f, 0.7f, 0.78f, 1f);
        _0x5b9952d1.selectedColor = Color.white;
        _0x5b9952d1.disabledColor = new Color(0.4f, 0.43f, 0.5f, 0.7f);
        _0x5b9952d1.colorMultiplier = 1f;
        _0x5b9952d1.fadeDuration = 0.06f;
        _0x31b6f847.colors = _0x5b9952d1;
        _0x86e0de1c.Button = _0x31b6f847;
        return _0x86e0de1c;
    }

    public static void SetBar(Image _0x44643f39, float _0x8ddbf264, float _0x8d6947f1)
    {
        if (_0x44643f39 == null)
            return;
        float _0xfd0e1bbb = Mathf.Clamp01(_0x8ddbf264);
        Vector2 _0x2c43b0e7 = _0x44643f39.rectTransform.sizeDelta;
        _0x44643f39.rectTransform.sizeDelta = new Vector2(Mathf.Max(6f, _0x8d6947f1 * _0xfd0e1bbb), _0x2c43b0e7.y);
    }

    /// <summary>
    /// Word wrap OFF, autosize ON, floor never under the readable minimum. Where a
    /// line ends is the caller's decision and lives in the string as a newline.
    /// </summary>
    public static void Wrap(TMP_Text _0x500fd71b, float _0x2e72b785, float _0xf658f8cf)
    {
        if (_0x500fd71b == null)
            return;
        float _0x1f4e8c95 = Mathf.Max(LabelFloor, _0xf658f8cf);
        _0x500fd71b.enableWordWrapping = false;
        _0x500fd71b.overflowMode = TextOverflowModes.Overflow;
        _0x500fd71b.enableAutoSizing = true;
        _0x500fd71b.fontSizeMax = Mathf.Max(_0x1f4e8c95, _0x2e72b785);
        _0x500fd71b.fontSizeMin = _0x1f4e8c95;
        _0x500fd71b.fontSize = Mathf.Max(_0x1f4e8c95, _0x2e72b785);
    }

    /// <summary>The body of a template panel, addressed by index only (rule A).</summary>
    public static Transform PanelContent(int _0x55afe7e1)
    {
        _0x76586aa9 _0x96e31ed0 = _0x76586aa9.Instance;
        if (_0x96e31ed0 == null || _0x96e31ed0.Panels == null)
            return null;
        if (_0x55afe7e1 < 0 || _0x55afe7e1 >= _0x96e31ed0.Panels.Count)
            return null;
        _0x6330b92a _0xa45346b0 = _0x96e31ed0.Panels[_0x55afe7e1];
        if (_0xa45346b0 == null || _0xa45346b0.Content == null)
            return null;
        return _0xa45346b0.Content.transform;
    }

    // The scene template ships seven tutorial panels full of filler copy. This game
    // keeps the template tutorial switched off and explains its gesture in the game
    // scene instead, but leaving that filler in place risks it reaching a screen
    // (rule C.15) - so every one of the seven is rewritten in this game's words.
    private static readonly string[] _0x1bea3c1a =
    {
        _0xa707de5f._0x1b8ee839(new byte[14] { 143, 150, 156, 148, 255, 139, 151, 154, 255, 144, 141, 155, 154, 141 }, 223),
        _0xa707de5f._0x1b8ee839(new byte[12] { 133, 142, 135, 136, 129, 131, 230, 146, 148, 135, 133, 141 }, 198),
        _0xa707de5f._0x1b8ee839(new byte[17] { 165, 179, 166, 177, 186, 210, 166, 186, 183, 210, 161, 187, 181, 188, 179, 190, 161 }, 242),
    };
    public static RectTransform Node(Transform _0xf25a6cf1, string _0xa7bd1627, Vector2 _0x8ba7c644, Vector2 _0x6ec04482, Vector2 _0xd070bc26)
    {
        GameObject _0x9a71d3f0 = new GameObject(_0xa7bd1627, typeof(RectTransform));
        _0x9a71d3f0.transform.SetParent(_0xf25a6cf1, false);
        RectTransform _0xb994b933 = _0x9a71d3f0.GetComponent<RectTransform>();
        _0xb994b933.anchorMin = _0x8ba7c644;
        _0xb994b933.anchorMax = _0x8ba7c644;
        _0xb994b933.pivot = new Vector2(0.5f, 0.5f);
        _0xb994b933.anchoredPosition = _0x6ec04482;
        _0xb994b933.sizeDelta = _0xd070bc26;
        _0xb994b933.localScale = Vector3.one;
        return _0xb994b933;
    }

    /// <summary>A full-stretch layer over its parent - shades, overlays, veils.</summary>
    public static Image Sheet(Transform _0x27824532, string _0xd000c3ed, Sprite _0x5707e0fb, Color _0x662896d2, bool _0xf0de3aa9)
    {
        Image _0x0eae5d32 = Block(_0x27824532, _0xd000c3ed, new Vector2(0.5f, 0.5f), Vector2.zero, Vector2.zero, _0x5707e0fb, _0x662896d2);
        RectTransform _0x1a96fa1c = _0x0eae5d32.rectTransform;
        _0x1a96fa1c.anchorMin = Vector2.zero;
        _0x1a96fa1c.anchorMax = Vector2.one;
        _0x1a96fa1c.sizeDelta = Vector2.zero;
        _0x1a96fa1c.anchoredPosition = Vector2.zero;
        _0x0eae5d32.raycastTarget = _0xf0de3aa9;
        return _0x0eae5d32;
    }

    public static Image Block(Transform _0x7bd3a96f, string _0x839b8c65, Vector2 _0x3d7b9c0e, Vector2 _0x75f44e1d, Vector2 _0x6d2a8959, Sprite _0xe1253d18, Color _0xeeb7b134)
    {
        RectTransform _0x4a5d4c55 = Node(_0x7bd3a96f, _0x839b8c65, _0x3d7b9c0e, _0x75f44e1d, _0x6d2a8959);
        Image _0xc4f44574 = _0x4a5d4c55.gameObject.AddComponent<Image>();
        _0xc4f44574.sprite = _0xe1253d18;
        _0xc4f44574.type = _0xe1253d18 == null ? Image.Type.Simple : Image.Type.Sliced;
        _0xc4f44574.color = _0xeeb7b134;
        _0xc4f44574.raycastTarget = false;
        return _0xc4f44574;
    }

    public const float LabelFloor = 30f;
    /// <summary>
    /// The splash loading bar: accent fill over a dark track with a real alpha, so
    /// the bar is visible instead of the template's near-transparent default.
    /// </summary>
    public static void ThemeSplashSlider()
    {
        Transform _0x9c6b585c = PanelContent(_0x228d52ef._0x837759f6.SPLASH);
        if (_0x9c6b585c == null)
            return;
        Slider _0xcd2c5ba7 = _0x9c6b585c.GetComponentInChildren<Slider>(true);
        if (_0xcd2c5ba7 == null)
            return;
        RectTransform _0x8f021746 = _0xcd2c5ba7.fillRect;
        if (_0x8f021746 != null)
        {
            Image _0x99b083f9 = _0x8f021746.GetComponent<Image>();
            if (_0x99b083f9 != null)
                _0x99b083f9.color = _0x5b09b348.Amber;
            if (_0x8f021746.parent != null)
            {
                Image _0x330bbb6a = _0x8f021746.parent.GetComponent<Image>();
                if (_0x330bbb6a != null)
                    _0x330bbb6a.color = _0x5b09b348.Fade(_0x5b09b348.Deep, 0.92f);
            }
        }

        Image _0xab0c4b59 = _0xcd2c5ba7.GetComponent<Image>();
        if (_0xab0c4b59 != null)
            _0xab0c4b59.color = _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.35f);
        _0xcd2c5ba7.transform.SetAsLastSibling();
    }

    /// <summary>A two-layer bar: bright frame, dark track, accent fill pinned left.</summary>
    public static Image Bar(Transform _0x01bcacd5, string _0x7764f898, Vector2 _0x341c509a, Vector2 _0xbae28d22, Vector2 _0xa7f286d9, Sprite _0x81cb9d7c, Color _0x08b4336a, Color _0x2ab99672, Color _0xdd4121a6)
    {
        RectTransform _0xf2ede8b6 = Node(_0x01bcacd5, _0x7764f898, _0x341c509a, _0xbae28d22, _0xa7f286d9);
        Block(_0xf2ede8b6, _0xa707de5f._0x1b8ee839(new byte[8] { 10, 41, 58, 14, 58, 41, 37, 45 }, 72), new Vector2(0.5f, 0.5f), Vector2.zero, _0xa7f286d9, _0x81cb9d7c, _0x2ab99672);
        Block(_0xf2ede8b6, _0xa707de5f._0x1b8ee839(new byte[8] { 39, 4, 23, 49, 23, 4, 6, 14 }, 101), new Vector2(0.5f, 0.5f), Vector2.zero, _0xa7f286d9 - new Vector2(6f, 6f), _0x81cb9d7c, _0x08b4336a);
        RectTransform _0xeabae780 = Node(_0xf2ede8b6, _0xa707de5f._0x1b8ee839(new byte[11] { 5, 38, 53, 1, 46, 43, 43, 15, 40, 52, 51 }, 71), new Vector2(0f, 0.5f), new Vector2(3f, 0f), _0xa7f286d9 - new Vector2(6f, 6f));
        _0xeabae780.pivot = new Vector2(0f, 0.5f);
        _0xeabae780.anchorMin = new Vector2(0f, 0.5f);
        _0xeabae780.anchorMax = new Vector2(0f, 0.5f);
        Image _0xbfa85d9b = _0xeabae780.gameObject.AddComponent<Image>();
        _0xbfa85d9b.sprite = _0x81cb9d7c;
        _0xbfa85d9b.type = _0x81cb9d7c == null ? Image.Type.Simple : Image.Type.Sliced;
        _0xbfa85d9b.color = _0xdd4121a6;
        _0xbfa85d9b.raycastTarget = false;
        return _0xbfa85d9b;
    }

    public const float FramePixels = 5f;
    private static readonly string[] _0x623f45a1 =
    {
        _0xa707de5f._0x1b8ee839(new byte[45] { 238, 242, 255, 154, 233, 238, 232, 243, 234, 154, 245, 244, 154, 238, 245, 234, 154, 233, 242, 245, 237, 233, 176, 237, 242, 243, 249, 242, 154, 249, 232, 251, 238, 255, 154, 249, 245, 247, 255, 233, 154, 244, 255, 226, 238 }, 186),
        _0xa707de5f._0x1b8ee839(new byte[48] { 136, 140, 146, 139, 158, 251, 148, 137, 251, 143, 154, 139, 251, 151, 158, 157, 143, 251, 244, 251, 137, 146, 156, 147, 143, 209, 143, 148, 251, 150, 148, 141, 158, 251, 153, 158, 143, 140, 158, 158, 149, 251, 143, 137, 154, 152, 144, 136 }, 219),
        _0xa707de5f._0x1b8ee839(new byte[48] { 15, 19, 9, 30, 30, 123, 12, 9, 20, 21, 28, 123, 24, 9, 26, 15, 30, 8, 123, 20, 9, 123, 24, 9, 26, 8, 19, 30, 8, 81, 8, 19, 14, 15, 123, 15, 19, 30, 123, 23, 18, 21, 30, 123, 31, 20, 12, 21 }, 91),
    };
    /// <summary>
    /// A signal plate: a bright frame with a dark card inset inside it. Returns the
    /// card, so children added to it draw over the fill - the order rule E.1 asks for.
    /// </summary>
    public static RectTransform Plate(Transform _0x1767c531, string _0xc7a6f954, Vector2 _0x600a0cf1, Vector2 _0xea0871ef, Vector2 _0x8c56ee75, Sprite _0x32a8e6e2, Color _0xfd98315f, Color _0x2d3bd444)
    {
        RectTransform _0x457ce903 = Node(_0x1767c531, _0xc7a6f954, _0x600a0cf1, _0xea0871ef, _0x8c56ee75);
        Block(_0x457ce903, _0xa707de5f._0x1b8ee839(new byte[10] { 15, 51, 62, 43, 58, 25, 45, 62, 50, 58 }, 95), new Vector2(0.5f, 0.5f), Vector2.zero, _0x8c56ee75, _0x32a8e6e2, _0x2d3bd444);
        Image _0x3408b1d0 = Block(_0x457ce903, _0xa707de5f._0x1b8ee839(new byte[9] { 71, 123, 118, 99, 114, 85, 120, 115, 110 }, 23), new Vector2(0.5f, 0.5f), Vector2.zero, _0x8c56ee75 - new Vector2(FramePixels * 2f, FramePixels * 2f), _0x32a8e6e2, _0xfd98315f);
        return _0x3408b1d0.rectTransform;
    }
}

internal static class _0xa707de5f
{
    internal static string _0x1b8ee839(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}