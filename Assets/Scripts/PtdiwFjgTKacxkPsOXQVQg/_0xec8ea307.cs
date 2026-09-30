using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dresses the three cards the template raises by index - WIN (7), LOSE (8) and
/// PAUSE (6). Everything the template put inside a card is switched off first, so
/// no leftover label and no sprite-less close icon (which Unity draws as a white
/// square) survives; what the player sees is built here, in this game's words and
/// this game's palette (rule C.3).
/// </summary>
public sealed class _0xec8ea307 : MonoBehaviour
{
    private readonly List<GameObject> _0x90eca28e = new List<GameObject>();
    /// <summary>
    /// Build a card inside a pop's body. The Pop comes in from the literal
    /// GetPop(SETTINGS.POPS.X) at the call site, so the pop this dresser fills and
    /// the pop the caller raises are provably the same one.
    /// </summary>
    public void _0x47efc8de(_0x9297c78f _0x4f72bc69, string _0xfb28cc44, Color _0x857dd9db, string _0x81e33e4b, string _0x870756ce, string _0x9fb0b3e2, System.Action _0xe211a994, string _0xa6438efc, System.Action _0x00af579c, string _0x34f9879d, System.Action _0xe5fb6eb8)
    {
        if (_0x4f72bc69 == null || _0x4f72bc69.Content == null)
            return;
        Transform _0x7668c2d5 = _0x4f72bc69.Content.transform;
        this._0x8921f5e7(_0x4f72bc69, _0x7668c2d5);
        RectTransform _0x98943860 = _0xc3776c65.Plate(_0x7668c2d5, _0x0ed66b34._0xaf255391(new byte[8] { 132, 131, 152, 137, 149, 151, 132, 146 }, 214), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(1020f, 1220f), this._0x050e2937.PlatePanel, _0x5b09b348.Surface, _0x5b09b348.Fade(_0x5b09b348.Amber, 0.9f));
        _0xc3776c65.Label(_0x98943860, _0x0ed66b34._0xaf255391(new byte[11] { 9, 11, 24, 14, 21, 2, 15, 11, 14, 15, 24 }, 74), _0xfb28cc44, new Vector2(0.5f, 1f), new Vector2(0f, -180f), new Vector2(930f, 160f), 76f, 56f, _0x857dd9db, this._0x019bc826, TextAlignmentOptions.Center);
        _0xc3776c65.Block(_0x98943860, _0x0ed66b34._0xaf255391(new byte[9] { 202, 200, 219, 205, 214, 219, 220, 197, 204 }, 137), new Vector2(0.5f, 1f), new Vector2(0f, -286f), new Vector2(700f, 8f), this._0x050e2937.PlatePanel, _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.85f));
        _0xc3776c65.Label(_0x98943860, _0x0ed66b34._0xaf255391(new byte[9] { 36, 38, 53, 35, 56, 42, 38, 46, 41 }, 103), _0x81e33e4b, new Vector2(0.5f, 1f), new Vector2(0f, -396f), new Vector2(900f, 150f), 56f, 42f, _0x5b09b348.TextPrimary, this._0x019bc826, TextAlignmentOptions.Center);
        _0xc3776c65.Label(_0x98943860, _0x0ed66b34._0xaf255391(new byte[10] { 146, 144, 131, 149, 142, 148, 137, 133, 131, 144 }, 209), _0x870756ce, new Vector2(0.5f, 1f), new Vector2(0f, -552f), new Vector2(900f, 150f), 40f, 32f, _0x5b09b348.TextSecondary, this._0x019bc826, TextAlignmentOptions.Center);
        Button _0x2d8f4a5c = _0xc3776c65.Cta(_0x98943860, _0x0ed66b34._0xaf255391(new byte[12] { 94, 92, 79, 89, 66, 77, 79, 84, 80, 92, 79, 68 }, 29), _0x9fb0b3e2, new Vector2(0.5f, 0f), new Vector2(0f, 384f), new Vector2(720f, 148f), this._0x050e2937.PlatePanel, this._0x050e2937.IconChevron, _0x5b09b348.Amber, _0x5b09b348.Ink, _0x5b09b348.Base, this._0x019bc826, 48f);
        _0x2d8f4a5c.onClick.AddListener(() => _0xe211a994.Invoke());
        Button _0x6f0e7dfe = _0xc3776c65.Cta(_0x98943860, _0x0ed66b34._0xaf255391(new byte[14] { 124, 126, 109, 123, 96, 108, 122, 124, 112, 113, 123, 126, 109, 102 }, 63), _0xa6438efc, new Vector2(0.5f, 0f), new Vector2(0f, 222f), new Vector2(720f, 136f), this._0x050e2937.PlatePanel, null, _0x5b09b348.SurfaceLit, _0x5b09b348.Cyan, _0x5b09b348.Cyan, this._0x019bc826, 44f);
        _0x6f0e7dfe.onClick.AddListener(() => _0x00af579c.Invoke());
        if (!string.IsNullOrEmpty(_0x34f9879d))
        {
            Button _0xfc19aa9a = _0xc3776c65.Cta(_0x98943860, _0x0ed66b34._0xaf255391(new byte[13] { 32, 34, 49, 39, 60, 55, 38, 49, 55, 42, 34, 49, 58 }, 99), _0x34f9879d, new Vector2(0.5f, 0f), new Vector2(0f, 72f), new Vector2(720f, 128f), this._0x050e2937.PlatePanel, null, _0x5b09b348.Fade(_0x5b09b348.Base, 0.95f), _0x5b09b348.Fade(_0x5b09b348.TextPrimary, 0.5f), _0x5b09b348.TextPrimary, this._0x019bc826, 42f);
            _0xfc19aa9a.onClick.AddListener(() => _0xe5fb6eb8.Invoke());
        }

        // The corner close button carries this game's own X, never the template's
        // unassigned sprite, which ships as a white square (rule B.1).
        Button _0xf39a7d5f = _0xc3776c65.Cta(_0x98943860, _0x0ed66b34._0xaf255391(new byte[10] { 145, 147, 128, 150, 141, 145, 158, 157, 129, 151 }, 210), string.Empty, new Vector2(1f, 1f), new Vector2(-62f, -62f), new Vector2(108f, 108f), this._0x050e2937.PlatePanel, this._0x050e2937.IconClose, _0x5b09b348.Fade(_0x5b09b348.Base, 0.95f), _0x5b09b348.Fade(_0x5b09b348.Amber, 0.7f), _0x5b09b348.TextPrimary, this._0x019bc826, 40f);
        _0xf39a7d5f.onClick.AddListener(() => _0x00af579c.Invoke());
        _0x98943860.localScale = Vector3.one * 0.9f;
        DOTween.Kill(_0x98943860);
        _0x98943860.DOScale(1f, 0.28f).SetEase(Ease.OutBack);
        this._0x99acd869.Add(_0x4f72bc69);
        this._0x90eca28e.Add(_0x98943860.parent == null ? _0x98943860.gameObject : _0x98943860.parent.gameObject);
    }

    private _0x385ff28c _0x050e2937;
    private TMP_FontAsset _0x019bc826;
    /// <summary>
    /// Switch off everything the template authored inside this card and remove the
    /// card this dresser built last time, so re-dressing replaces instead of stacking.
    /// </summary>
    private void _0x8921f5e7(_0x9297c78f _0xa3c6bb74, Transform _0x26f007f1)
    {
        for (int _0xf7aba5d1 = this._0x99acd869.Count - 1; _0xf7aba5d1 >= 0; _0xf7aba5d1--)
        {
            if (this._0x99acd869[_0xf7aba5d1] != _0xa3c6bb74)
                continue;
            if (this._0x90eca28e[_0xf7aba5d1] != null)
                Destroy(this._0x90eca28e[_0xf7aba5d1]);
            this._0x99acd869.RemoveAt(_0xf7aba5d1);
            this._0x90eca28e.RemoveAt(_0xf7aba5d1);
        }

        for (int _0x3bd86883 = _0x26f007f1.childCount - 1; _0x3bd86883 >= 0; _0x3bd86883--)
        {
            Transform _0x83908c8e = _0x26f007f1.GetChild(_0x3bd86883);
            if (_0x83908c8e != null)
                _0x83908c8e.gameObject.SetActive(false);
        }
    }

    private readonly List<_0x9297c78f> _0x99acd869 = new List<_0x9297c78f>();
    public void _0x40881727(_0x385ff28c _0x9cbbc2de, TMP_FontAsset _0xf6f02320)
    {
        this._0x050e2937 = _0x9cbbc2de;
        this._0x019bc826 = _0xf6f02320;
    }

    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
    }
}

internal static class _0x0ed66b34
{
    internal static string _0xaf255391(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}