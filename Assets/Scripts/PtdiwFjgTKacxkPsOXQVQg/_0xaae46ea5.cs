using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The routes card in the menu. Picking a line is not an extra step on the way
/// into the game - PLAY always leaves straight for the yard with whatever is
/// selected - it is a switch on the same screen.
///
/// Rule C.7 asks that pressing it be visible in a screenshot, so a pick changes
/// four things at once: the chip's frame colour, its fill, a cyan marker in its
/// corner, and the objective line above the card.
/// </summary>
public sealed class _0xaae46ea5 : MonoBehaviour
{
    private readonly Image[] _0xa5cdb8f4 = new Image[3];
    private int _0x161a4102;
    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
    }

    private void _0xadbb33f8(int _0xe190a91d)
    {
        this._0x161a4102 = Mathf.Clamp(_0xe190a91d, 0, _0x6f92d6a9.Routes.Length - 1);
        _0x5d1b9d8b._0x8eed499e = this._0x161a4102;
        _0x5d1b9d8b.Buzz();
        for (int _0x3e77043c = 0; _0x3e77043c < _0x6f92d6a9.Routes.Length; _0x3e77043c++)
        {
            bool _0x8aab1db8 = _0x3e77043c == this._0x161a4102;
            if (this._0xa5cdb8f4[_0x3e77043c] != null)
                this._0xa5cdb8f4[_0x3e77043c].color = _0x8aab1db8 ? _0x5b09b348.Amber : _0x5b09b348.Fade(_0x5b09b348.Surface, 0.9f);
            if (this._0x1562bb0b[_0x3e77043c] != null)
                this._0x1562bb0b[_0x3e77043c].color = _0x8aab1db8 ? _0x5b09b348.SurfaceLit : _0x5b09b348.Fade(_0x5b09b348.Surface, 0.55f);
            if (this._0x14cea6df[_0x3e77043c] != null)
                this._0x14cea6df[_0x3e77043c].color = _0x8aab1db8 ? _0x5b09b348.Cyan : _0x5b09b348.Fade(_0x5b09b348.Cyan, 0f);
            if (this._0x7ae8d9eb[_0x3e77043c] != null)
            {
                int _0x839956dd = _0x5d1b9d8b.BestDelivered(_0x3e77043c);
                this._0x7ae8d9eb[_0x3e77043c].text = _0x839956dd > 0 ? _0xfdbcb8d2._0xd7b1a17a(new byte[5] { 88, 95, 73, 78, 58 }, 26) + _0x839956dd + _0xfdbcb8d2._0xd7b1a17a(new byte[3] { 38, 41, 38 }, 6) + _0x6f92d6a9.Routes[_0x3e77043c].Crates : _0xfdbcb8d2._0xd7b1a17a(new byte[11] { 213, 212, 207, 187, 201, 206, 213, 187, 194, 222, 207 }, 155);
                this._0x7ae8d9eb[_0x3e77043c].color = _0x5d1b9d8b.Cleared(_0x3e77043c) ? _0x5b09b348.Green : _0x5b09b348.TextSecondary;
            }

            if (this._0x5a39bf69[_0x3e77043c] == null)
                continue;
            this._0x5a39bf69[_0x3e77043c].localScale = Vector3.one;
            if (_0x8aab1db8)
            {
                DOTween.Kill(this._0x5a39bf69[_0x3e77043c]);
                this._0x5a39bf69[_0x3e77043c].DOPunchScale(Vector3.one * 0.08f, 0.35f, 6, 0.6f);
            }
        }

        if (this._0x4111e39d != null)
            this._0x4111e39d.Invoke(this._0x161a4102);
    }

    private readonly RectTransform[] _0x5a39bf69 = new RectTransform[3];
    public void Build(Transform _0xaefa1c4f, _0x385ff28c _0x0c065ef1, TMP_FontAsset _0x4119fe79, Vector2 _0xf0e8332f, System.Action<int> _0x8a7a3658)
    {
        this._0xdda8ac98 = _0x0c065ef1;
        this._0xc88982f4 = _0x4119fe79;
        this._0x4111e39d = _0x8a7a3658;
        RectTransform _0x07e47ead = _0xc3776c65.Plate(_0xaefa1c4f, _0xfdbcb8d2._0xd7b1a17a(new byte[11] { 255, 247, 252, 231, 237, 224, 253, 231, 230, 247, 225 }, 178), _0xf0e8332f, Vector2.zero, new Vector2(1080f, 300f), _0x0c065ef1.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Base, 0.92f), _0x5b09b348.Fade(_0x5b09b348.Amber, 0.85f));
        _0xc3776c65.Label(_0x07e47ead, _0xfdbcb8d2._0xd7b1a17a(new byte[15] { 227, 235, 224, 251, 241, 252, 225, 251, 250, 235, 253, 241, 250, 239, 233 }, 174), _0xfdbcb8d2._0xd7b1a17a(new byte[6] { 241, 236, 246, 247, 230, 240 }, 163), new Vector2(0.5f, 1f), new Vector2(0f, -34f), new Vector2(600f, 48f), 36f, 32f, _0x5b09b348.Amber, this._0xc88982f4, TextAlignmentOptions.Center);
        int _0x1457c3d6 = _0x6f92d6a9.Routes.Length;
        if (_0x1457c3d6 == 0)
        {
            _0xc3776c65.Label(_0x07e47ead, _0xfdbcb8d2._0xd7b1a17a(new byte[17] { 38, 46, 37, 62, 52, 57, 36, 62, 63, 46, 56, 52, 46, 38, 59, 63, 50 }, 107), _0xfdbcb8d2._0xd7b1a17a(new byte[22] { 181, 180, 219, 169, 180, 174, 175, 190, 168, 219, 174, 181, 183, 180, 184, 176, 190, 191, 219, 162, 190, 175 }, 251), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(900f, 80f), 38f, 32f, _0x5b09b348.TextSecondary, this._0xc88982f4, TextAlignmentOptions.Center);
            return;
        }

        float _0xf05a8566 = 352f;
        float _0x3b74fd88 = -(_0x1457c3d6 - 1) * _0xf05a8566 * 0.5f;
        for (int _0x52319ccb = 0; _0x52319ccb < _0x1457c3d6; _0x52319ccb++)
        {
            int _0x091885ef = _0x52319ccb;
            _0x0a9f4dbc _0x5b4ea494 = _0x6f92d6a9.Routes[_0x52319ccb];
            Vector2 _0xb1b5ff9c = new Vector2(330f, 180f);
            RectTransform _0x66b3977e = _0xc3776c65.Node(_0x07e47ead, _0xfdbcb8d2._0xd7b1a17a(new byte[9] { 97, 105, 98, 121, 115, 111, 100, 101, 124 }, 44), new Vector2(0.5f, 0.5f), new Vector2(_0x3b74fd88 + _0x52319ccb * _0xf05a8566, -28f), _0xb1b5ff9c);
            this._0x5a39bf69[_0x52319ccb] = _0x66b3977e;
            Image _0xd449e788 = _0x66b3977e.gameObject.AddComponent<Image>();
            _0xd449e788.sprite = _0x0c065ef1.PlatePanel;
            _0xd449e788.type = _0x0c065ef1.PlatePanel == null ? Image.Type.Simple : Image.Type.Sliced;
            _0xd449e788.color = new Color(1f, 1f, 1f, 0.004f);
            _0xd449e788.raycastTarget = true;
            _0xd449e788.canvasRenderer.cullTransparentMesh = false;
            this._0xa5cdb8f4[_0x52319ccb] = _0xc3776c65.Block(_0x66b3977e, _0xfdbcb8d2._0xd7b1a17a(new byte[9] { 171, 128, 129, 152, 174, 154, 137, 133, 141 }, 232), new Vector2(0.5f, 0.5f), Vector2.zero, _0xb1b5ff9c, _0x0c065ef1.PlatePanel, _0x5b09b348.Surface);
            this._0x1562bb0b[_0x52319ccb] = _0xc3776c65.Block(_0x66b3977e, _0xfdbcb8d2._0xd7b1a17a(new byte[8] { 79, 100, 101, 124, 74, 101, 96, 96 }, 12), new Vector2(0.5f, 0.5f), Vector2.zero, _0xb1b5ff9c - new Vector2(8f, 8f), _0x0c065ef1.PlatePanel, _0x5b09b348.Surface);
            _0xc3776c65.Label(_0x66b3977e, _0xfdbcb8d2._0xd7b1a17a(new byte[8] { 33, 10, 11, 18, 44, 3, 15, 7 }, 98), _0x5b4ea494.Caption, new Vector2(0.5f, 1f), new Vector2(0f, -38f), new Vector2(290f, 48f), 34f, 30f, _0x5b09b348.TextPrimary, this._0xc88982f4, TextAlignmentOptions.Center);
            _0xc3776c65.Label(_0x66b3977e, _0xfdbcb8d2._0xd7b1a17a(new byte[8] { 32, 11, 10, 19, 47, 12, 2, 7 }, 99), _0x5b4ea494.Crates + _0xfdbcb8d2._0xd7b1a17a(new byte[7] { 239, 140, 157, 142, 155, 138, 156 }, 207), new Vector2(0.5f, 0.5f), new Vector2(0f, 4f), new Vector2(290f, 44f), 32f, 30f, _0x5b09b348.Amber, this._0xc88982f4, TextAlignmentOptions.Center);
            this._0x7ae8d9eb[_0x52319ccb] = _0xc3776c65.Label(_0x66b3977e, _0xfdbcb8d2._0xd7b1a17a(new byte[8] { 10, 33, 32, 57, 11, 44, 58, 61 }, 73), string.Empty, new Vector2(0.5f, 0f), new Vector2(0f, 34f), new Vector2(290f, 44f), 30f, 30f, _0x5b09b348.TextSecondary, this._0xc88982f4, TextAlignmentOptions.Center);
            this._0x14cea6df[_0x52319ccb] = _0xc3776c65.Block(_0x66b3977e, _0xfdbcb8d2._0xd7b1a17a(new byte[8] { 71, 108, 109, 116, 73, 101, 118, 111 }, 4), new Vector2(0f, 1f), new Vector2(22f, -22f), new Vector2(24f, 24f), _0x0c065ef1.PipLive, _0x5b09b348.Cyan);
            this._0x14cea6df[_0x52319ccb].type = Image.Type.Simple;
            Button _0x728d347b = _0x66b3977e.gameObject.AddComponent<Button>();
            _0x728d347b.targetGraphic = this._0x1562bb0b[_0x52319ccb];
            ColorBlock _0x38f2b05a = _0x728d347b.colors;
            _0x38f2b05a.normalColor = Color.white;
            _0x38f2b05a.highlightedColor = Color.white;
            _0x38f2b05a.pressedColor = new Color(0.7f, 0.74f, 0.82f, 1f);
            _0x38f2b05a.selectedColor = Color.white;
            _0x38f2b05a.disabledColor = new Color(0.4f, 0.43f, 0.5f, 0.7f);
            _0x38f2b05a.colorMultiplier = 1f;
            _0x38f2b05a.fadeDuration = 0.06f;
            _0x728d347b.colors = _0x38f2b05a;
            _0x728d347b.onClick.AddListener(() => this._0xadbb33f8(_0x091885ef));
        }

        this._0xadbb33f8(_0x5d1b9d8b._0x8eed499e);
    }

    private readonly Image[] _0x1562bb0b = new Image[3];
    private TMP_FontAsset _0xc88982f4;
    private readonly TextMeshProUGUI[] _0x7ae8d9eb = new TextMeshProUGUI[3];
    private readonly Image[] _0x14cea6df = new Image[3];
    private _0x385ff28c _0xdda8ac98;
    private System.Action<int> _0x4111e39d;
}

internal static class _0xfdbcb8d2
{
    internal static string _0xd7b1a17a(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}