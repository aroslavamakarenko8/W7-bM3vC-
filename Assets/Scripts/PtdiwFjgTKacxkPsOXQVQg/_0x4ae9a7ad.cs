using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TmpContrastGuard.cs — staged into every Unity app by approve-pipeline-unity.sh
// (stage 5c3, rule C.14 in CLAUDE-unity.md). Do not edit the copy inside a project;
// edit scripts/lib/unity/TmpContrastGuard.cs.
//
// WHY: every TMP label gets an outline (C.10), and by default that outline is dark.
// A dark face colour on a dark outline merges into a smudge — the label is not
// readable on any backing (ANDROID-3627: PLAY drawn Deep #12151E on the #12151E
// outline read as a black blob). enforce-text-contrast.sh fixes colours SERIALISED
// in scenes/prefabs, but labels built at runtime from C# (UiKit.Cta, VaultUi.Caption,
// label.color = Palette.X ...) never reach a scene file, so that pass cannot see them.
//
// WHAT: after any TMP text is regenerated, compare its face colour with the outline
// colour of the material it actually renders with. Below WCAG 4.5:1 the face is
// blended toward white (dark outline) or black (light outline) until it reaches 7:1.
// Hue is kept; alpha is kept. A label whose outline was deliberately switched to a
// light colour (TextReadability-style per-label material) is measured against THAT
// outline, so intentionally dark text on a light rim is left alone. Labels without
// an outline are left alone too.
public sealed class _0x4ae9a7ad : MonoBehaviour
{
    private readonly List<TMP_Text> _0x2da9c079 = new List<TMP_Text>();
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Boot()
    {
        if (_0x458646e5 != null)
            return;
        GameObject _0x95dabb8c = new GameObject(_0x7876fa66._0x8f979d1b(new byte[16] { 46, 23, 10, 57, 21, 20, 14, 8, 27, 9, 14, 61, 15, 27, 8, 30 }, 122));
        _0x95dabb8c.hideFlags = HideFlags.HideInHierarchy;
        DontDestroyOnLoad(_0x95dabb8c);
        _0x458646e5 = _0x95dabb8c.AddComponent<_0x4ae9a7ad>();
    }

    private static float Linear(float _0x124d16f4)
    {
        _0x124d16f4 = Mathf.Clamp01(_0x124d16f4);
        return _0x124d16f4 <= 0.03928f ? _0x124d16f4 / 12.92f : Mathf.Pow((_0x124d16f4 + 0.055f) / 1.055f, 2.4f);
    }

    private const float MinRatio = 4.5f;
    private void OnDisable()
    {
        if (this._0x0c56856b != null)
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(this._0x0c56856b);
    }

    private readonly HashSet<TMP_Text> _0x11c76ca9 = new HashSet<TMP_Text>();
    // WCAG relative luminance of an sRGB colour, and the contrast ratio of two.
    private static float Luminance(Color _0x0a361109)
    {
        return 0.2126f * Linear(_0x0a361109.r) + 0.7152f * Linear(_0x0a361109.g) + 0.0722f * Linear(_0x0a361109.b);
    }

    private static float Ratio(Color _0x5db12bb2, Color _0x0cf2cd3b)
    {
        float _0x03bfd90e = Luminance(_0x5db12bb2);
        float _0xc36773ea = Luminance(_0x0cf2cd3b);
        return (Mathf.Max(_0x03bfd90e, _0xc36773ea) + 0.05f) / (Mathf.Min(_0x03bfd90e, _0xc36773ea) + 0.05f);
    }

    private const float TargetRatio = 7f;
    // The event fires from inside the canvas rebuild. Changing the colour right there
    // would re-dirty the graphic mid-rebuild, which Unity rejects — so queue it and
    // apply in LateUpdate, which runs before the next frame's rebuild.
    private void _0x163c6b39(Object _0x5d16bea1)
    {
        TMP_Text _0x3a0db098 = _0x5d16bea1 as TMP_Text;
        if (_0x3a0db098 != null)
            this._0x11c76ca9.Add(_0x3a0db098);
    }

    private void OnEnable()
    {
        if (this._0x0c56856b == null)
            this._0x0c56856b = _0x723c53a5 => this._0x163c6b39(_0x723c53a5);
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(this._0x0c56856b);
    }

    private void LateUpdate()
    {
        if (this._0x11c76ca9.Count == 0)
            return;
        this._0x2da9c079.Clear();
        this._0x2da9c079.AddRange(this._0x11c76ca9);
        this._0x11c76ca9.Clear();
        for (int _0x4c9ff89b = 0; _0x4c9ff89b < this._0x2da9c079.Count; _0x4c9ff89b++)
            Fix(this._0x2da9c079[_0x4c9ff89b]);
    }

    private const float MinOutlineWidth = 0.01f;
    private static _0x4ae9a7ad _0x458646e5;
    // A lambda held in a field, never the bare method group: Plana renames the method
    // declaration but not a method-group reference (verify-unity-buttons.sh, CS0103).
    // The field keeps Add and Remove on the same delegate instance.
    private System.Action<Object> _0x0c56856b;
    private static void Fix(TMP_Text _0x911ee828)
    {
        if (_0x911ee828 == null || !_0x911ee828.isActiveAndEnabled)
            return;
        Material _0xcff73cb3 = _0x911ee828.fontSharedMaterial;
        if (_0xcff73cb3 == null || !_0xcff73cb3.HasProperty(ShaderUtilities.ID_OutlineColor) || !_0xcff73cb3.HasProperty(ShaderUtilities.ID_OutlineWidth))
            return;
        if (_0xcff73cb3.GetFloat(ShaderUtilities.ID_OutlineWidth) < MinOutlineWidth)
            return;
        Color _0x1b25c63b = _0x911ee828.color;
        if (_0x1b25c63b.a <= 0f)
            return;
        Color _0x7524cd46 = _0xcff73cb3.GetColor(ShaderUtilities.ID_OutlineColor);
        if (Ratio(_0x1b25c63b, _0x7524cd46) >= MinRatio)
            return;
        Color _0xd06357d5 = Luminance(_0x7524cd46) < 0.5f ? Color.white : Color.black;
        Color _0x22c6abd1;
        if (Ratio(_0xd06357d5, _0x7524cd46) < TargetRatio)
        {
            _0x22c6abd1 = _0xd06357d5;
        }
        else
        {
            // Smallest blend that reaches the target: contrast grows monotonically
            // with t, so a short bisection keeps as much of the hue as possible.
            float _0xbf7efd8e = 0f;
            float _0x80f20867 = 1f;
            for (int _0x533e0284 = 0; _0x533e0284 < 20; _0x533e0284++)
            {
                float _0x77c437a5 = (_0xbf7efd8e + _0x80f20867) * 0.5f;
                if (Ratio(Color.Lerp(_0x1b25c63b, _0xd06357d5, _0x77c437a5), _0x7524cd46) >= TargetRatio)
                    _0x80f20867 = _0x77c437a5;
                else
                    _0xbf7efd8e = _0x77c437a5;
            }

            _0x22c6abd1 = Color.Lerp(_0x1b25c63b, _0xd06357d5, _0x80f20867);
        }

        _0x22c6abd1.a = _0x1b25c63b.a;
        _0x911ee828.color = _0x22c6abd1;
    }
}

internal static class _0x7876fa66
{
    internal static string _0x8f979d1b(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}