using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The run read-out, built as this game's own objects inside the template panel
/// body - never as content pushed into a template placeholder, because those are
/// switched off before the build ships (rule C.2).
///
/// Top to bottom: the two chrome buttons, the order strip that says which crate
/// comes next, the line clock, the delivery counter and the three signals, and at
/// the foot the gesture hint, which stays on screen for the whole run.
/// </summary>
public sealed class _0x4ae19aac : MonoBehaviour
{
    private const float StripStep = 168f;
    /// <summary>The strip shuffles one step left, then snaps back full of the new order.</summary>
    public void _0xb04d838b(_0xbddf612c _0x8569c1f1, int _0xed0e6c75)
    {
        if (this._0xc1b19a93 == null)
        {
            this._0x552ee7fc(_0x8569c1f1, _0xed0e6c75);
            return;
        }

        DOTween.Kill(this._0xc1b19a93);
        this._0xc1b19a93.anchoredPosition = new Vector2(StripStep, -14f);
        this._0xc1b19a93.DOAnchorPos(new Vector2(0f, -14f), 0.22f).SetEase(Ease.OutBack);
        this._0x552ee7fc(_0x8569c1f1, _0xed0e6c75);
        if (this._0x611703cb[0] != null)
        {
            Transform _0x9d1dd941 = this._0x611703cb[0].transform.parent;
            DOTween.Kill(_0x9d1dd941);
            _0x9d1dd941.localScale = Vector3.one;
            _0x9d1dd941.DOPunchScale(Vector3.one * 0.12f, 0.2f, 6, 0.6f);
        }
    }

    // -- signals ---------------------------------------------------------------
    private void _0x06217719(Transform _0xa41afe78)
    {
        this._0xffb75481 = _0xc3776c65.Plate(_0xa41afe78, _0x9a83639c._0x7a173959(new byte[11] { 30, 3, 18, 9, 5, 31, 17, 24, 23, 26, 5 }, 86), new Vector2(0.745f, 0.735f), Vector2.zero, new Vector2(420f, 170f), this._0xcd420d45.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Base, 0.92f), _0x5b09b348.Fade(_0x5b09b348.Amber, 0.8f));
        float _0x9c67295d = -(_0x6f92d6a9.StrikeBudget - 1) * 74f * 0.5f;
        for (int _0xb5d0edf5 = 0; _0xb5d0edf5 < _0x6f92d6a9.StrikeBudget; _0xb5d0edf5++)
        {
            this._0x753125fd[_0xb5d0edf5] = _0xc3776c65.Block(this._0xffb75481, _0x9a83639c._0x7a173959(new byte[7] { 162, 191, 174, 181, 186, 163, 186 }, 234), new Vector2(0.5f, 1f), new Vector2(_0x9c67295d + _0xb5d0edf5 * 74f, -56f), new Vector2(60f, 60f), this._0xcd420d45.PipLive, _0x5b09b348.Green);
            this._0x753125fd[_0xb5d0edf5].type = Image.Type.Simple;
        }

        _0xc3776c65.Label(this._0xffb75481, _0x9a83639c._0x7a173959(new byte[15] { 242, 239, 254, 229, 233, 243, 253, 244, 251, 246, 233, 229, 238, 251, 253 }, 186), _0x9a83639c._0x7a173959(new byte[7] { 64, 90, 84, 93, 82, 95, 64 }, 19), new Vector2(0.5f, 0f), new Vector2(0f, 40f), new Vector2(380f, 48f), 32f, 30f, _0x5b09b348.TextSecondary, this._0x86f7382f, TextAlignmentOptions.Center);
    }

    // -- chrome ----------------------------------------------------------------
    // The template's own TopPanel buttons are switched off by the pipeline before a
    // build ships, so this game carries its own pair and adds nothing beside theirs
    // (rule H, option 2).
    private void _0x1a87b23b(Transform _0x85f5df0d, System.Action _0x60583181, System.Action _0xa1eb2de2)
    {
        _0xc3776c65.Block(_0x85f5df0d, _0x9a83639c._0x7a173959(new byte[11] { 95, 66, 83, 72, 67, 88, 71, 72, 85, 86, 69 }, 23), new Vector2(0.5f, 1f), new Vector2(0f, -96f), new Vector2(1242f, 192f), this._0xcd420d45.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Deep, 0.55f));
        Button _0xe9c5fea6 = _0xc3776c65.Cta(_0x85f5df0d, _0x9a83639c._0x7a173959(new byte[8] { 31, 2, 19, 8, 21, 22, 20, 28 }, 87), string.Empty, new Vector2(0.085f, 0.94f), Vector2.zero, new Vector2(128f, 128f), this._0xcd420d45.PlatePanel, this._0xcd420d45.IconBack, _0x5b09b348.Surface, _0x5b09b348.Amber, _0x5b09b348.Amber, this._0x86f7382f, 40f);
        _0xe9c5fea6.onClick.AddListener(() => _0x60583181.Invoke());
        Button _0x69af691b = _0xc3776c65.Cta(_0x85f5df0d, _0x9a83639c._0x7a173959(new byte[9] { 40, 53, 36, 63, 48, 33, 53, 51, 37 }, 96), string.Empty, new Vector2(0.915f, 0.94f), Vector2.zero, new Vector2(128f, 128f), this._0xcd420d45.PlatePanel, this._0xcd420d45.IconPause, _0x5b09b348.Surface, _0x5b09b348.Amber, _0x5b09b348.Amber, this._0x86f7382f, 40f);
        _0x69af691b.onClick.AddListener(() => _0xa1eb2de2.Invoke());
    }

    private const float StripSlot = 150f;
    // -- gesture hint (rule C.6) -----------------------------------------------
    private void _0xe0acf1b3(Transform _0x48402bbd)
    {
        this._0x3d0cdadb = _0xc3776c65.Plate(_0x48402bbd, _0x9a83639c._0x7a173959(new byte[13] { 151, 138, 155, 128, 151, 150, 145, 139, 128, 136, 150, 155, 154 }, 223), new Vector2(0.5f, 0.125f), Vector2.zero, new Vector2(1020f, 110f), this._0xcd420d45.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Base, 0.94f), _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.85f));
        _0xc3776c65.Label(this._0x3d0cdadb, _0x9a83639c._0x7a173959(new byte[18] { 126, 99, 114, 105, 126, 127, 120, 98, 105, 97, 127, 114, 115, 105, 98, 115, 110, 98 }, 54), _0x9a83639c._0x7a173959(new byte[41] { 109, 105, 119, 110, 123, 30, 113, 108, 30, 106, 127, 110, 30, 114, 123, 120, 106, 30, 17, 30, 108, 119, 121, 118, 106, 30, 106, 113, 30, 125, 118, 127, 112, 121, 123, 30, 106, 108, 127, 125, 117 }, 62), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(960f, 70f), 38f, 32f, _0x5b09b348.TextPrimary, this._0x86f7382f, TextAlignmentOptions.Center);
        this._0x21205340 = _0xc3776c65.Plate(_0x48402bbd, _0x9a83639c._0x7a173959(new byte[13] { 149, 136, 153, 130, 149, 148, 147, 137, 130, 158, 149, 148, 141 }, 221), new Vector2(0.5f, 0.125f), Vector2.zero, new Vector2(660f, 86f), this._0xcd420d45.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Base, 0.88f), _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.6f));
        _0xc3776c65.Label(this._0x21205340, _0x9a83639c._0x7a173959(new byte[18] { 11, 22, 7, 28, 11, 10, 13, 23, 28, 0, 11, 10, 19, 28, 23, 6, 27, 23 }, 67), _0x9a83639c._0x7a173959(new byte[32] { 196, 209, 192, 176, 220, 213, 214, 196, 176, 191, 176, 194, 217, 215, 216, 196, 176, 196, 223, 176, 211, 216, 209, 222, 215, 213, 176, 196, 194, 209, 211, 219 }, 144), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(620f, 60f), 34f, 30f, _0x5b09b348.Fade(_0x5b09b348.TextPrimary, 0.85f), this._0x86f7382f, TextAlignmentOptions.Center);
        this._0x7bc289ad(true);
    }

    public void _0xa1162e0a(int _0x2737b598, int _0xbea9aff4)
    {
        if (this._0x4d431c04 != null)
            this._0x4d431c04.text = _0x6f92d6a9.Pad(_0x2737b598) + _0x9a83639c._0x7a173959(new byte[3] { 245, 250, 245 }, 213) + _0x6f92d6a9.Pad(_0xbea9aff4);
        if (this._0x8fea18c7 == null)
            return;
        DOTween.Kill(this._0x8fea18c7);
        this._0x8fea18c7.localScale = Vector3.one;
        this._0x8fea18c7.DOPunchScale(Vector3.one * 0.06f, 0.25f, 6, 0.6f);
    }

    private Image _0xd93a0835;
    private TextMeshProUGUI _0xfb6877fd;
    private TextMeshProUGUI _0x4d431c04;
    public void Build(Transform _0x262ad509, _0x385ff28c _0x35d5f2c1, TMP_FontAsset _0xce545eac, System.Action _0xffb9bb56, System.Action _0x1ea7e496)
    {
        this._0xcd420d45 = _0x35d5f2c1;
        this._0x86f7382f = _0xce545eac;
        this._0x1a87b23b(_0x262ad509, _0xffb9bb56, _0x1ea7e496);
        this._0x75b79bca(_0x262ad509);
        this._0x16acb465(_0x262ad509);
        this._0xc0cd5b77(_0x262ad509);
        this._0x06217719(_0x262ad509);
        this._0xe0acf1b3(_0x262ad509);
    }

    public void _0xb7f548e4(int _0x0371d828)
    {
        for (int _0x0b9732c0 = 0; _0x0b9732c0 < this._0x753125fd.Length; _0x0b9732c0++)
        {
            if (this._0x753125fd[_0x0b9732c0] == null)
                continue;
            bool _0xbe0b3b65 = _0x0b9732c0 < _0x0371d828;
            this._0x753125fd[_0x0b9732c0].sprite = _0xbe0b3b65 ? this._0xcd420d45.PipDead : this._0xcd420d45.PipLive;
            this._0x753125fd[_0x0b9732c0].color = _0xbe0b3b65 ? _0x5b09b348.Fade(_0x5b09b348.Alarm, 0.9f) : _0x5b09b348.Green;
        }

        if (_0x0371d828 <= 0 || this._0xffb75481 == null)
            return;
        int _0xd6927bdb = Mathf.Clamp(_0x0371d828 - 1, 0, this._0x753125fd.Length - 1);
        if (this._0x753125fd[_0xd6927bdb] != null)
        {
            Transform _0x8b18cdae = this._0x753125fd[_0xd6927bdb].transform;
            DOTween.Kill(_0x8b18cdae);
            _0x8b18cdae.localScale = Vector3.one;
            _0x8b18cdae.DOPunchScale(Vector3.one * 0.25f, 0.3f, 8, 0.6f);
        }

        DOTween.Kill(this._0xffb75481);
        this._0xffb75481.DOShakePosition(0.25f, 8f, 12, 90f, false, true);
    }

    private RectTransform _0xffb75481;
    private readonly Image[] _0x611703cb = new Image[_0x6f92d6a9.OrderWindow];
    /// <summary>Repaint the five slots from the colour chain starting at the head.</summary>
    public void _0x552ee7fc(_0xbddf612c _0xdf3ccbe7, int _0x08e84638)
    {
        for (int _0xec9581ee = 0; _0xec9581ee < _0x6f92d6a9.OrderWindow; _0xec9581ee++)
        {
            int _0x18e48da2 = _0x08e84638 + _0xec9581ee;
            bool _0xb54c2684 = _0xdf3ccbe7 != null && _0x18e48da2 < _0xdf3ccbe7._0x8a0f87ee;
            int _0xd44af598 = _0xb54c2684 ? _0xdf3ccbe7._0xa819aef1(_0x18e48da2) : 0;
            if (this._0xc9109136[_0xec9581ee] != null)
            {
                this._0xc9109136[_0xec9581ee].sprite = this._0xcd420d45._0x19c57fe3(_0xd44af598);
                this._0xc9109136[_0xec9581ee].color = _0xb54c2684 ? _0x5b09b348.Fade(Color.white, _0xec9581ee == 0 ? 1f : 0.62f) : _0x5b09b348.Fade(Color.white, 0.12f);
            }

            if (this._0x611703cb[_0xec9581ee] != null)
            {
                Color _0xc49b74d7 = _0xb54c2684 ? _0x5b09b348.Crates[Mathf.Clamp(_0xd44af598, 0, _0x5b09b348.Crates.Length - 1)] : _0x5b09b348.Surface;
                this._0x611703cb[_0xec9581ee].color = _0xec9581ee == 0 ? _0x5b09b348.Cyan : _0x5b09b348.Fade(_0xc49b74d7, 0.62f);
            }
        }
    }

    private const float ClockWidth = 620f;
    /// <summary>
    /// The hint never leaves: it only shrinks from a full plate to a chip once the
    /// player has had ten seconds with it, so a review screenshot taken at any point
    /// in the run still shows how the cart is steered.
    /// </summary>
    public void _0x7bc289ad(bool _0x7892bee6)
    {
        if (this._0x3d0cdadb != null)
            this._0x3d0cdadb.parent.gameObject.SetActive(_0x7892bee6);
        if (this._0x21205340 != null)
            this._0x21205340.parent.gameObject.SetActive(!_0x7892bee6);
    }

    private RectTransform _0x21205340;
    /// <summary>The line clock just gained time: say so where the player is looking.</summary>
    public void _0x252e9c68(float _0x1695bcd1)
    {
        if (this._0xd93a0835 != null)
        {
            Transform _0x5a3cfc4a = this._0xd93a0835.transform.parent;
            DOTween.Kill(_0x5a3cfc4a);
            _0x5a3cfc4a.localScale = Vector3.one;
            _0x5a3cfc4a.DOPunchScale(Vector3.one * 0.08f, 0.35f, 6, 0.6f);
        }

        if (this._0xfb6877fd == null)
            return;
        this._0xfb6877fd.text = _0x9a83639c._0x7a173959(new byte[1] { 188 }, 151) + _0x1695bcd1.ToString(_0x9a83639c._0x7a173959(new byte[3] { 171, 181, 171 }, 155)) + _0x9a83639c._0x7a173959(new byte[1] { 193 }, 146);
        RectTransform _0x5e4321eb = this._0xfb6877fd.rectTransform;
        DOTween.Kill(_0x5e4321eb);
        DOTween.Kill(this._0xfb6877fd);
        _0x5e4321eb.anchoredPosition = new Vector2(0f, 40f);
        this._0xfb6877fd.alpha = 1f;
        _0x5e4321eb.DOAnchorPos(new Vector2(0f, 130f), 0.6f).SetEase(Ease.OutQuad);
        DOTween.To(() => this._0xfb6877fd.alpha, _0xcda2279f => this._0xfb6877fd.alpha = _0xcda2279f, 0f, 0.6f);
    }

    private RectTransform _0x3d0cdadb;
    private RectTransform _0x8fea18c7;
    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
    }

    public void _0xd272eaa9(float _0x29f4b478, float _0xaf1f1ef3)
    {
        if (this._0xe8b1583c != null)
            this._0xe8b1583c.text = _0x6f92d6a9.Clock(_0x29f4b478);
        if (this._0xd93a0835 == null)
            return;
        _0xc3776c65.SetBar(this._0xd93a0835, _0xaf1f1ef3 <= 0f ? 0f : _0x29f4b478 / _0xaf1f1ef3, ClockWidth - 6f);
        this._0xd93a0835.color = _0x29f4b478 <= _0x6f92d6a9.ClockWarnSeconds ? _0x5b09b348.Alarm : _0x5b09b348.Amber;
    }

    private RectTransform _0xc1b19a93;
    private TMP_FontAsset _0x86f7382f;
    private readonly Image[] _0x753125fd = new Image[_0x6f92d6a9.StrikeBudget];
    // -- line clock ------------------------------------------------------------
    private void _0x16acb465(Transform _0x53c48a65)
    {
        this._0xe8b1583c = _0xc3776c65.Label(_0x53c48a65, _0x9a83639c._0x7a173959(new byte[15] { 68, 89, 72, 83, 79, 64, 67, 79, 71, 83, 64, 77, 78, 73, 64 }, 12), _0x9a83639c._0x7a173959(new byte[5] { 160, 161, 170, 164, 160 }, 144), new Vector2(0.165f, 0.808f), Vector2.zero, new Vector2(260f, 76f), 52f, 40f, _0x5b09b348.TextPrimary, this._0x86f7382f, TextAlignmentOptions.Center);
        this._0xd93a0835 = _0xc3776c65.Bar(_0x53c48a65, _0x9a83639c._0x7a173959(new byte[13] { 162, 191, 174, 181, 169, 166, 165, 169, 161, 181, 168, 171, 184 }, 234), new Vector2(0.58f, 0.808f), Vector2.zero, new Vector2(ClockWidth, 40f), this._0xcd420d45.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Deep, 0.92f), _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.45f), _0x5b09b348.Amber);
        this._0xfb6877fd = _0xc3776c65.Label(_0x53c48a65, _0x9a83639c._0x7a173959(new byte[15] { 150, 139, 154, 129, 157, 146, 145, 157, 149, 129, 156, 145, 144, 139, 141 }, 222), string.Empty, new Vector2(0.58f, 0.808f), new Vector2(0f, 56f), new Vector2(320f, 60f), 44f, 34f, _0x5b09b348.Green, this._0x86f7382f, TextAlignmentOptions.Center);
        this._0xfb6877fd.alpha = 0f;
    }

    private const float StripHead = 170f;
    // -- delivered -------------------------------------------------------------
    private void _0xc0cd5b77(Transform _0xaa303eef)
    {
        this._0x8fea18c7 = _0xc3776c65.Plate(_0xaa303eef, _0x9a83639c._0x7a173959(new byte[12] { 80, 77, 92, 71, 72, 74, 87, 95, 74, 93, 75, 75 }, 24), new Vector2(0.255f, 0.735f), Vector2.zero, new Vector2(420f, 170f), this._0xcd420d45.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Base, 0.92f), _0x5b09b348.Fade(_0x5b09b348.Green, 0.8f));
        this._0x4d431c04 = _0xc3776c65.Label(this._0x8fea18c7, _0x9a83639c._0x7a173959(new byte[18] { 192, 221, 204, 215, 216, 218, 199, 207, 218, 205, 219, 219, 215, 222, 201, 196, 221, 205 }, 136), _0x9a83639c._0x7a173959(new byte[7] { 214, 214, 198, 201, 198, 212, 208 }, 230), new Vector2(0.5f, 1f), new Vector2(0f, -54f), new Vector2(380f, 80f), 60f, 44f, _0x5b09b348.Green, this._0x86f7382f, TextAlignmentOptions.Center);
        _0xc3776c65.Label(this._0x8fea18c7, _0x9a83639c._0x7a173959(new byte[16] { 217, 196, 213, 206, 193, 195, 222, 214, 195, 212, 194, 194, 206, 197, 208, 214 }, 145), _0x9a83639c._0x7a173959(new byte[9] { 60, 61, 52, 49, 46, 61, 42, 61, 60 }, 120), new Vector2(0.5f, 0f), new Vector2(0f, 40f), new Vector2(380f, 48f), 32f, 30f, _0x5b09b348.TextSecondary, this._0x86f7382f, TextAlignmentOptions.Center);
    }

    private readonly Image[] _0xc9109136 = new Image[_0x6f92d6a9.OrderWindow];
    // -- order strip -----------------------------------------------------------
    private void _0x75b79bca(Transform _0xc063f233)
    {
        RectTransform _0x271fe593 = _0xc3776c65.Plate(_0xc063f233, _0x9a83639c._0x7a173959(new byte[9] { 135, 154, 139, 144, 128, 157, 139, 138, 157 }, 207), new Vector2(0.5f, 0.885f), Vector2.zero, new Vector2(940f, 210f), this._0xcd420d45.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Base, 0.92f), _0x5b09b348.Fade(_0x5b09b348.Amber, 0.85f));
        _0xc3776c65.Label(_0x271fe593, _0x9a83639c._0x7a173959(new byte[13] { 124, 97, 112, 107, 123, 102, 112, 113, 102, 107, 96, 117, 115 }, 52), _0x9a83639c._0x7a173959(new byte[4] { 102, 109, 112, 124 }, 40), new Vector2(0f, 1f), new Vector2(120f, -34f), new Vector2(200f, 44f), 32f, 30f, _0x5b09b348.Cyan, this._0x86f7382f, TextAlignmentOptions.Center);
        this._0xc1b19a93 = _0xc3776c65.Node(_0x271fe593, _0x9a83639c._0x7a173959(new byte[13] { 26, 7, 22, 13, 29, 0, 22, 23, 0, 13, 0, 29, 5 }, 82), new Vector2(0.5f, 0.5f), new Vector2(0f, -14f), new Vector2(880f, 180f));
        float _0xf8c3025a = -(_0x6f92d6a9.OrderWindow - 1) * StripStep * 0.5f;
        for (int _0xabd6e02c = 0; _0xabd6e02c < _0x6f92d6a9.OrderWindow; _0xabd6e02c++)
        {
            float _0x6b28011d = _0xabd6e02c == 0 ? StripHead : StripSlot;
            RectTransform _0x01781c8b = _0xc3776c65.Node(this._0xc1b19a93, _0x9a83639c._0x7a173959(new byte[8] { 6, 27, 10, 17, 29, 2, 1, 26 }, 78), new Vector2(0.5f, 0.5f), new Vector2(_0xf8c3025a + _0xabd6e02c * StripStep, 0f), new Vector2(_0x6b28011d, _0x6b28011d));
            this._0x611703cb[_0xabd6e02c] = _0xc3776c65.Block(_0x01781c8b, _0x9a83639c._0x7a173959(new byte[9] { 100, 91, 88, 67, 113, 69, 86, 90, 82 }, 55), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(_0x6b28011d, _0x6b28011d), this._0xcd420d45.SlotFrame, _0x5b09b348.Amber);
            this._0xc9109136[_0xabd6e02c] = _0xc3776c65.Block(_0x01781c8b, _0x9a83639c._0x7a173959(new byte[8] { 228, 219, 216, 195, 241, 214, 212, 210 }, 183), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(_0x6b28011d * 0.7f, _0x6b28011d * 0.7f), this._0xcd420d45._0x19c57fe3(0), Color.white);
            this._0xc9109136[_0xabd6e02c].type = Image.Type.Simple;
            float _0x622b9344 = _0xabd6e02c == 0 ? 1f : 1f - (_0xabd6e02c - 1) * 0.06f;
            _0x01781c8b.localScale = Vector3.one * _0x622b9344;
        }
    }

    private _0x385ff28c _0xcd420d45;
    private TextMeshProUGUI _0xe8b1583c;
}

internal static class _0x9a83639c
{
    internal static string _0x7a173959(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}