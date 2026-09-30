using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The menu side of the yard: an abstract signal mark on the splash, the cart
/// waiting at the mouth of three converging tracks, the best run so far, the route
/// switch, and the two buttons.
///
/// PLAY is the scene template's own load button - this view only draws its face,
/// so the scene change stays exactly where the template put it and is never
/// triggered twice.
/// </summary>
public sealed class _0xe240ef4b : MonoBehaviour
{
    private void _0xc3e8f447(Transform _0x48ecef71)
    {
        if (_0x48ecef71 == null)
            return;
        _0x48ecef71.DOPunchScale(Vector3.one * 0.06f, 0.6f, 6, 0.6f);
    }

    private Camera _0xb537eef3;
    [SerializeField]
    private Sprite _platePanel;
    [SerializeField]
    private Sprite _iconClose;
    [SerializeField]
    private Sprite _slotFrame;
    private _0xaae46ea5 _0xd94853c8;
    private _0x385ff28c _0x3a1d7a56;
    // -- the menu proper -------------------------------------------------------
    private void _0x6caa6191()
    {
        Transform _0xfad70db1 = _0xc3776c65.PanelContent(_0x228d52ef._0x837759f6.DEFAULT);
        if (_0xfad70db1 == null)
            return;
        this._0x766f5730(_0xfad70db1);
        this._0x20ae3fca = _0xc3776c65.Label(_0xfad70db1, _0x7e4c71b6._0xed38b32d(new byte[14] { 171, 163, 168, 179, 185, 169, 164, 172, 163, 165, 178, 175, 176, 163 }, 230), string.Empty, new Vector2(0.5f, 0.545f), Vector2.zero, new Vector2(1000f, 90f), 44f, 36f, _0x5b09b348.TextPrimary, this._font, TextAlignmentOptions.Center);
        _0xc3776c65.Label(_0xfad70db1, _0x7e4c71b6._0xed38b32d(new byte[13] { 65, 73, 66, 89, 83, 95, 89, 78, 88, 69, 88, 64, 73 }, 12), _0x7e4c71b6._0xed38b32d(new byte[32] { 30, 13, 121, 127, 108, 110, 102, 126, 13, 0, 13, 30, 13, 126, 100, 106, 99, 108, 97, 126, 13, 0, 13, 98, 99, 104, 13, 110, 97, 98, 110, 102 }, 45), new Vector2(0.5f, 0.495f), Vector2.zero, new Vector2(1000f, 60f), 32f, 30f, _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.85f), this._font, TextAlignmentOptions.Center);
        GameObject _0x073a70df = new GameObject(_0x7e4c71b6._0xed38b32d(new byte[14] { 152, 176, 187, 160, 135, 186, 160, 161, 176, 151, 186, 180, 167, 177 }, 213));
        _0x073a70df.transform.SetParent(this.transform, false);
        this._0xd94853c8 = _0x073a70df.AddComponent<_0xaae46ea5>();
        this._0xd94853c8.Build(_0xfad70db1, this._0x3a1d7a56, this._font, new Vector2(0.5f, 0.405f), _0x68cf408a => this._0xfea08271(_0x68cf408a));
        this._0x480b7999(_0xfad70db1);
        Button _0xb3e218e5 = _0xc3776c65.Cta(_0xfad70db1, _0x7e4c71b6._0xed38b32d(new byte[14] { 210, 218, 209, 202, 192, 215, 208, 200, 203, 208, 192, 221, 203, 209 }, 159), _0x7e4c71b6._0xed38b32d(new byte[11] { 238, 233, 241, 134, 242, 233, 134, 246, 234, 231, 255 }, 166), new Vector2(0.5f, 0.175f), Vector2.zero, new Vector2(580f, 116f), this._0x3a1d7a56.PlatePanel, null, _0x5b09b348.Surface, _0x5b09b348.Cyan, _0x5b09b348.Cyan, this._font, 42f);
        GameObject _0x462df600 = new GameObject(_0x7e4c71b6._0xed38b32d(new byte[9] { 55, 31, 20, 15, 50, 21, 13, 46, 21 }, 122));
        _0x462df600.transform.SetParent(this.transform, false);
        this._0xb719978f = _0x462df600.AddComponent<_0xd0c9b0d2>();
        this._0xb719978f.Build(_0xfad70db1, this._0x3a1d7a56, this._font);
        _0xb3e218e5.onClick.AddListener(() => this._0x4f9ba2d7());
    }

    private _0xd0c9b0d2 _0xb719978f;
    private void Awake()
    {
        this._0xb537eef3 = Camera.main;
        this._0x3a1d7a56 = new _0x385ff28c
        {
            CartHero = this._cartHero,
            Crates = this._crateSprites,
            LaneFan = this._laneFan,
            MarkSignal = this._markSignal,
            SlotFrame = this._slotFrame,
            PlatePanel = this._platePanel,
            PipLive = this._pipLive,
            IconClose = this._iconClose,
            IconChevron = this._iconChevron,
            TutSwipe = this._tutSwipe,
            TutOrder = this._tutOrder,
            TutSignal = this._tutSignal,
        };
    }

    private _0x76eb34d4 _0x337c5494;
    [SerializeField]
    private Sprite _tutSwipe;
    private void _0x4f9ba2d7()
    {
        _0x5d1b9d8b.Buzz();
        if (this._0xb719978f != null)
            this._0xb719978f._0x7ce7dd3a();
    }

    private void _0x766f5730(Transform _0x84d7f369)
    {
        RectTransform _0xce56a291 = _0xc3776c65.Plate(_0x84d7f369, _0x7e4c71b6._0xed38b32d(new byte[9] { 125, 117, 126, 101, 111, 114, 117, 99, 100 }, 48), new Vector2(0.5f, 0.862f), Vector2.zero, new Vector2(920f, 220f), this._0x3a1d7a56.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Base, 0.92f), _0x5b09b348.Fade(_0x5b09b348.Amber, 0.85f));
        _0xc3776c65.Label(_0xce56a291, _0x7e4c71b6._0xed38b32d(new byte[15] { 184, 176, 187, 160, 170, 183, 176, 166, 161, 170, 161, 180, 178, 170, 185 }, 245), _0x7e4c71b6._0xed38b32d(new byte[14] { 153, 158, 136, 143, 251, 159, 158, 151, 146, 141, 158, 137, 158, 159 }, 219), new Vector2(0.27f, 1f), new Vector2(0f, -42f), new Vector2(380f, 46f), 32f, 30f, _0x5b09b348.TextSecondary, this._font, TextAlignmentOptions.Center);
        _0xc3776c65.Label(_0xce56a291, _0x7e4c71b6._0xed38b32d(new byte[17] { 56, 48, 59, 32, 42, 55, 48, 38, 33, 42, 35, 52, 57, 32, 48, 42, 57 }, 117), _0x5d1b9d8b.BestDeliveredAnywhere().ToString(), new Vector2(0.27f, 0f), new Vector2(0f, 62f), new Vector2(380f, 96f), 72f, 52f, _0x5b09b348.Amber, this._font, TextAlignmentOptions.Center);
        _0xc3776c65.Block(_0xce56a291, _0x7e4c71b6._0xed38b32d(new byte[14] { 41, 33, 42, 49, 59, 38, 33, 55, 48, 59, 54, 49, 40, 33 }, 100), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(4f, 130f), this._0x3a1d7a56.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.4f));
        _0xc3776c65.Label(_0xce56a291, _0x7e4c71b6._0xed38b32d(new byte[15] { 45, 37, 46, 53, 63, 34, 37, 51, 52, 63, 52, 33, 39, 63, 50 }, 96), _0x7e4c71b6._0xed38b32d(new byte[13] { 59, 60, 42, 45, 89, 56, 58, 58, 44, 43, 56, 58, 32 }, 121), new Vector2(0.73f, 1f), new Vector2(0f, -42f), new Vector2(380f, 46f), 32f, 30f, _0x5b09b348.TextSecondary, this._font, TextAlignmentOptions.Center);
        _0xc3776c65.Label(_0xce56a291, _0x7e4c71b6._0xed38b32d(new byte[17] { 228, 236, 231, 252, 246, 235, 236, 250, 253, 246, 255, 232, 229, 252, 236, 246, 251 }, 169), _0x5d1b9d8b.BestAccuracyAnywhere() + _0x7e4c71b6._0xed38b32d(new byte[1] { 175 }, 138), new Vector2(0.73f, 0f), new Vector2(0f, 62f), new Vector2(380f, 96f), 72f, 52f, _0x5b09b348.Green, this._font, TextAlignmentOptions.Center);
    }

    [SerializeField]
    private Sprite[] _crateSprites = new Sprite[0];
    private void _0xf8c361d6()
    {
        Transform _0x9f863bd3 = _0xc3776c65.PanelContent(_0x228d52ef._0x837759f6.SPLASH);
        if (_0x9f863bd3 == null)
            return;
        _0xc3776c65.Sheet(_0x9f863bd3, _0x7e4c71b6._0xed38b32d(new byte[12] { 167, 164, 184, 181, 167, 188, 171, 167, 188, 181, 176, 177 }, 244), this._0x3a1d7a56.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Deep, 0.72f), false);
        Image _0x9066e82b = _0xc3776c65.Block(_0x9f863bd3, _0x7e4c71b6._0xed38b32d(new byte[11] { 118, 117, 105, 100, 118, 109, 122, 104, 100, 119, 110 }, 37), new Vector2(0.5f, 0.58f), Vector2.zero, new Vector2(420f, 420f), this._0x3a1d7a56.MarkSignal, _0x5b09b348.Amber);
        _0x9066e82b.type = Image.Type.Simple;
        _0xc3776c65.Label(_0x9f863bd3, _0x7e4c71b6._0xed38b32d(new byte[10] { 21, 22, 10, 7, 21, 14, 25, 18, 7, 1 }, 70), _0x7e4c71b6._0xed38b32d(new byte[7] { 193, 194, 204, 201, 196, 195, 202 }, 141), new Vector2(0.5f, 0.17f), Vector2.zero, new Vector2(600f, 64f), 36f, 32f, _0x5b09b348.TextPrimary, this._font, TextAlignmentOptions.Center);
        Transform _0xf9aa528a = _0x9066e82b.transform;
        _0xf9aa528a.localScale = Vector3.one * 0.82f;
        DOTween.Kill(_0xf9aa528a);
        _0xf9aa528a.DOScale(1f, 0.45f).SetEase(Ease.OutBack).OnComplete(() => this._0xc3e8f447(_0xf9aa528a));
    }

    [SerializeField]
    private TMP_FontAsset _font;
    [SerializeField]
    private Sprite _pipLive;
    private void OnDestroy()
    {
        if (this._0x67b786e2 != null)
            DOTween.Kill(this._0x67b786e2.transform);
        if (this._0x3c4ec27f != null)
            DOTween.Kill(this._0x3c4ec27f.transform);
        DOTween.Kill(this.transform);
    }

    [SerializeField]
    private Sprite _markSignal;
    [SerializeField]
    private Sprite _tutOrder;
    [SerializeField]
    private Sprite _iconChevron;
    private SpriteRenderer _0x67b786e2;
    [SerializeField]
    private Sprite _laneFan;
    // -- the world behind the menu ---------------------------------------------
    private void _0xbe7b68ba()
    {
        float _0xc103b02f = this._0x337c5494.HalfWidth * 2f * 0.78f;
        _0x22d320c4.Quad(this.transform, _0x7e4c71b6._0xed38b32d(new byte[11] { 175, 135, 140, 151, 174, 131, 140, 135, 164, 131, 140 }, 226), this._0x3a1d7a56.LaneFan, new Vector2(_0xc103b02f, _0xc103b02f * 0.66f), new Vector2(0f, 1.62f), _0x6f92d6a9.MenuFanOrder, _0x5b09b348.Fade(Color.white, 0.9f));
        float _0x216271d1 = this._0x337c5494.LanePitch * 1.18f;
        this._0x67b786e2 = _0x22d320c4.Quad(this.transform, _0x7e4c71b6._0xed38b32d(new byte[8] { 75, 99, 104, 115, 69, 103, 116, 114 }, 6), this._0x3a1d7a56.CartHero, new Vector2(_0x216271d1, _0x216271d1), new Vector2(0f, 1.18f), _0x6f92d6a9.MenuCartOrder, Color.white);
        float _0xf94e1bb1 = _0x216271d1 * 0.34f;
        this._0x3c4ec27f = _0x22d320c4.Quad(this.transform, _0x7e4c71b6._0xed38b32d(new byte[9] { 10, 34, 41, 50, 4, 53, 38, 51, 34 }, 71), this._0x3a1d7a56._0x19c57fe3(0), new Vector2(_0xf94e1bb1, _0xf94e1bb1), new Vector2(0f, 1.18f + _0x216271d1 * 0.2f), _0x6f92d6a9.MenuCrateOrder, Color.white);
        // The cart breathes for a few cycles and then settles - no endless loop.
        Transform _0x2b5a02dc = this._0x67b786e2.transform;
        DOTween.Kill(_0x2b5a02dc);
        _0x2b5a02dc.DOLocalMoveY(1.18f + _0x216271d1 * 0.08f, 1.4f).SetEase(Ease.InOutSine).SetLoops(6, LoopType.Yoyo);
    }

    /// <summary>
    /// Draw this game's face over the template's load button. The face carries the
    /// raycast and the template button keeps the handler, so UGUI bubbles the click
    /// up and the scene loads exactly once.
    /// </summary>
    private void _0x480b7999(Transform _0x152743dd)
    {
        _0x7183452a _0xa7464ffa = _0x152743dd.GetComponentInChildren<_0x7183452a>(true);
        if (_0xa7464ffa == null)
            return;
        RectTransform _0x93bcb30d = _0xa7464ffa.GetComponent<RectTransform>();
        if (_0x93bcb30d == null)
            return;
        Vector2 _0x7d461228 = _0x93bcb30d.rect.size;
        if (_0x7d461228.x < 200f || _0x7d461228.y < 80f)
            _0x7d461228 = new Vector2(760f, 168f);
        Image _0x5f04b9d3 = _0xc3776c65.Block(_0x93bcb30d, _0x7e4c71b6._0xed38b32d(new byte[10] { 97, 125, 112, 104, 110, 119, 99, 112, 124, 116 }, 49), new Vector2(0.5f, 0.5f), Vector2.zero, _0x7d461228, this._0x3a1d7a56.PlatePanel, _0x5b09b348.Ink);
        _0x5f04b9d3.raycastTarget = true;
        Image _0x816e7c7d = _0xc3776c65.Block(_0x93bcb30d, _0x7e4c71b6._0xed38b32d(new byte[9] { 56, 36, 41, 49, 55, 46, 33, 36, 36 }, 104), new Vector2(0.5f, 0.5f), Vector2.zero, _0x7d461228 - new Vector2(_0xc3776c65.FramePixels * 2f, _0xc3776c65.FramePixels * 2f), this._0x3a1d7a56.PlatePanel, _0x5b09b348.Amber);
        _0x816e7c7d.raycastTarget = true;
        Image _0x3fbd7777 = _0xc3776c65.Block(_0x93bcb30d, _0x7e4c71b6._0xed38b32d(new byte[9] { 149, 137, 132, 156, 154, 140, 134, 138, 139 }, 197), new Vector2(0.5f, 0.5f), new Vector2(-(_0x7d461228.x * 0.5f - 66f), 0f), new Vector2(48f, 48f), this._0x3a1d7a56.IconChevron, _0x5b09b348.Base);
        _0x3fbd7777.type = Image.Type.Simple;
        _0xc3776c65.Label(_0x93bcb30d, _0x7e4c71b6._0xed38b32d(new byte[9] { 103, 123, 118, 110, 104, 99, 114, 111, 99 }, 55), _0x7e4c71b6._0xed38b32d(new byte[4] { 226, 254, 243, 235 }, 178), new Vector2(0.5f, 0.5f), new Vector2(26f, 0f), new Vector2(_0x7d461228.x - 170f, _0x7d461228.y - 40f), 64f, 52f, _0x5b09b348.Base, this._font, TextAlignmentOptions.Center);
        _0x93bcb30d.localScale = Vector3.one;
    }

    private SpriteRenderer _0x3c4ec27f;
    private TextMeshProUGUI _0x20ae3fca;
    [SerializeField]
    private Sprite _tutSignal;
    // -- reactions -------------------------------------------------------------
    private void _0xfea08271(int _0xd5bd959a)
    {
        _0x0a9f4dbc _0xf2e36c14 = _0x6f92d6a9.Route(_0xd5bd959a);
        if (this._0x20ae3fca != null)
            this._0x20ae3fca.text = _0x7e4c71b6._0xed38b32d(new byte[8] { 191, 190, 183, 178, 173, 190, 169, 219 }, 251) + _0xf2e36c14.Crates + _0x7e4c71b6._0xed38b32d(new byte[16] { 12, 111, 126, 109, 120, 105, 127, 12, 101, 98, 12, 99, 126, 104, 105, 126 }, 44);
        // The chosen line is visible on the cart itself, not only on the chip: the
        // crate it carries takes that route's colour (rule C.7).
        if (this._0x3c4ec27f != null)
        {
            int _0x00eb1db7 = _0xd5bd959a % _0x6f92d6a9.CrateKinds;
            this._0x3c4ec27f.sprite = this._0x3a1d7a56._0x19c57fe3(_0x00eb1db7);
            Transform _0x12d78850 = this._0x3c4ec27f.transform;
            DOTween.Kill(_0x12d78850);
            _0x12d78850.localScale = Vector3.one;
            _0x12d78850.DOPunchScale(Vector3.one * 0.18f, 0.35f, 6, 0.6f);
        }
    }

    [SerializeField]
    private Sprite _cartHero;
    private void Start()
    {
        this._0x337c5494 = _0x76eb34d4.FromCamera(this._0xb537eef3);
        _0xc3776c65.SanitiseTutorials(this._font);
        this._0xbe7b68ba();
        this._0xf8c361d6();
        this._0x6caa6191();
        _0xc3776c65.ThemeSplashSlider();
    }
}

internal static class _0x7e4c71b6
{
    internal static string _0xed38b32d(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}