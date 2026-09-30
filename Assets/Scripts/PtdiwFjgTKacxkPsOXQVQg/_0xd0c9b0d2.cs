using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The three-step explainer the menu opens. It is this game's own overlay rather
/// than the template tutorial, which stays switched off - so it does not depend on
/// a "tutorial passed" flag in PlayerPrefs and is reachable on every launch,
/// including the second one a reviewer makes.
/// </summary>
public sealed class _0xd0c9b0d2 : MonoBehaviour
{
    public void _0x7ce7dd3a()
    {
        if (this._0xd33d1267 == null)
            return;
        this._0xd33d1267.gameObject.SetActive(true);
        this._0xd33d1267.localScale = Vector3.one * 0.94f;
        DOTween.Kill(this._0xd33d1267);
        this._0xd33d1267.DOScale(1f, 0.24f).SetEase(Ease.OutBack);
    }

    private void Step(Transform _0xdeecda1b, _0x385ff28c _0xb96b577b, TMP_FontAsset _0xc6eb9827, float _0x60ff35c3, Sprite _0x87331c56, string _0xc47d6fe7)
    {
        RectTransform _0x4c16966f = _0xc3776c65.Node(_0xdeecda1b, _0xbe19182f._0x1c62cc42(new byte[9] { 199, 224, 248, 219, 224, 220, 251, 234, 255 }, 143), new Vector2(0.5f, 1f), new Vector2(0f, _0x60ff35c3), new Vector2(920f, 240f));
        Image _0x50f75c2f = _0xc3776c65.Block(_0x4c16966f, _0xbe19182f._0x1c62cc42(new byte[7] { 60, 27, 10, 31, 46, 29, 27 }, 111), new Vector2(0f, 0.5f), new Vector2(140f, 0f), new Vector2(200f, 200f), _0x87331c56, _0x5b09b348.TextPrimary);
        _0x50f75c2f.type = Image.Type.Simple;
        _0xc3776c65.Label(_0x4c16966f, _0xbe19182f._0x1c62cc42(new byte[8] { 161, 134, 151, 130, 166, 151, 138, 134 }, 242), _0xc47d6fe7, new Vector2(1f, 0.5f), new Vector2(-300f, 0f), new Vector2(580f, 200f), 38f, 32f, _0x5b09b348.TextPrimary, _0xc6eb9827, TextAlignmentOptions.Left);
    }

    public void Build(Transform _0x91627f54, _0x385ff28c _0x506b4576, TMP_FontAsset _0xfefa77f6)
    {
        this._0xd33d1267 = _0xc3776c65.Host(_0x91627f54, _0xbe19182f._0x1c62cc42(new byte[10] { 222, 214, 221, 198, 204, 219, 220, 196, 199, 220 }, 147));
        _0xc3776c65.Sheet(this._0xd33d1267, _0xbe19182f._0x1c62cc42(new byte[10] { 93, 122, 98, 65, 122, 70, 125, 116, 113, 112 }, 21), _0x506b4576.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Deep, 0.9f), true);
        RectTransform _0x654764da = _0xc3776c65.Plate(this._0xd33d1267, _0xbe19182f._0x1c62cc42(new byte[9] { 112, 87, 79, 108, 87, 123, 89, 74, 92 }, 56), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(1060f, 1420f), _0x506b4576.PlatePanel, _0x5b09b348.Surface, _0x5b09b348.Fade(_0x5b09b348.Amber, 0.9f));
        _0xc3776c65.Label(_0x654764da, _0xbe19182f._0x1c62cc42(new byte[10] { 142, 169, 177, 146, 169, 146, 175, 178, 170, 163 }, 198), _0xbe19182f._0x1c62cc42(new byte[11] { 71, 64, 88, 47, 91, 64, 47, 95, 67, 78, 86 }, 15), new Vector2(0.5f, 1f), new Vector2(0f, -112f), new Vector2(880f, 120f), 56f, 46f, _0x5b09b348.Amber, _0xfefa77f6, TextAlignmentOptions.Center);
        this.Step(_0x654764da, _0x506b4576, _0xfefa77f6, -300f, _0x506b4576.TutSwipe, _0xbe19182f._0x1c62cc42(new byte[41] { 199, 195, 221, 196, 209, 180, 219, 198, 180, 192, 213, 196, 180, 216, 209, 210, 192, 180, 187, 180, 198, 221, 211, 220, 192, 158, 192, 219, 180, 215, 220, 213, 218, 211, 209, 180, 192, 198, 213, 215, 223 }, 148));
        this.Step(_0x654764da, _0x506b4576, _0xfefa77f6, -588f, _0x506b4576.TutOrder, _0xbe19182f._0x1c62cc42(new byte[47] { 81, 72, 66, 74, 33, 66, 83, 64, 85, 68, 82, 33, 72, 79, 33, 85, 73, 68, 33, 78, 83, 69, 68, 83, 11, 82, 73, 78, 86, 79, 33, 78, 79, 33, 85, 73, 68, 33, 85, 78, 81, 33, 82, 85, 83, 72, 81 }, 1));
        this.Step(_0x654764da, _0x506b4576, _0xfefa77f6, -876f, _0x506b4576.TutSignal, _0xbe19182f._0x1c62cc42(new byte[48] { 98, 126, 100, 115, 115, 22, 97, 100, 121, 120, 113, 22, 117, 100, 119, 98, 115, 101, 22, 121, 100, 22, 117, 100, 119, 101, 126, 115, 101, 60, 101, 126, 99, 98, 22, 98, 126, 115, 22, 122, 127, 120, 115, 22, 114, 121, 97, 120 }, 54));
        Button _0x7368d218 = _0xc3776c65.Cta(_0x654764da, _0xbe19182f._0x1c62cc42(new byte[10] { 179, 148, 140, 175, 148, 184, 151, 148, 136, 158 }, 251), string.Empty, new Vector2(1f, 1f), new Vector2(-62f, -62f), new Vector2(104f, 104f), _0x506b4576.PlatePanel, _0x506b4576.IconClose, _0x5b09b348.Fade(_0x5b09b348.Base, 0.95f), _0x5b09b348.Fade(_0x5b09b348.Amber, 0.7f), _0x5b09b348.TextPrimary, _0xfefa77f6, 40f);
        _0x7368d218.onClick.AddListener(() => this._0xa09dbeb0());
        Button _0x52e43c76 = _0xc3776c65.Cta(_0x654764da, _0xbe19182f._0x1c62cc42(new byte[10] { 40, 15, 23, 52, 15, 39, 15, 20, 41, 20 }, 96), _0xbe19182f._0x1c62cc42(new byte[6] { 30, 22, 13, 121, 16, 13 }, 89), new Vector2(0.5f, 0f), new Vector2(0f, 120f), new Vector2(460f, 128f), _0x506b4576.PlatePanel, null, _0x5b09b348.Amber, _0x5b09b348.Ink, _0x5b09b348.Base, _0xfefa77f6, 46f);
        _0x52e43c76.onClick.AddListener(() => this._0xa09dbeb0());
        this._0xd33d1267.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
    }

    public void _0xa09dbeb0()
    {
        if (this._0xd33d1267 == null)
            return;
        DOTween.Kill(this._0xd33d1267);
        this._0xd33d1267.localScale = Vector3.one;
        this._0xd33d1267.gameObject.SetActive(false);
    }

    private RectTransform _0xd33d1267;
}

internal static class _0xbe19182f
{
    internal static string _0x1c62cc42(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}