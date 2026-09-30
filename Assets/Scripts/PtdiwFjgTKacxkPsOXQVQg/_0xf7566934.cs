using DG.Tweening;
using UnityEngine;

/// <summary>
/// The cart at the bottom of the yard: which track it sits on, how it slides
/// between them, and the two reactions the player reads as feedback - a tilt into
/// the turn, and a shake when the load is wrong.
/// </summary>
public sealed class _0xf7566934 : MonoBehaviour
{
    private _0x76eb34d4 _0xdb04cd13;
    private int _0xafaee474 = 1;
    private void _0xd6883c14()
    {
        if (this._0xe0dc0867 == null)
            return;
        this._0xe0dc0867.transform.DOLocalRotate(Vector3.zero, _0x6f92d6a9.LaneSlideSeconds).SetEase(Ease.OutQuad);
    }

    /// <summary>Arrival flourish: the cart grows into place from the computed size.</summary>
    public void _0xdc329a58()
    {
        if (this._0xe0dc0867 == null)
            return;
        Transform _0x29e9de2f = this._0xe0dc0867.transform;
        _0x29e9de2f.localScale = Vector3.one * 0.7f;
        DOTween.Kill(_0x29e9de2f);
        _0x29e9de2f.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
    }

    private void OnDestroy()
    {
        if (this._0xe0dc0867 != null)
            DOTween.Kill(this._0xe0dc0867.transform);
        if (this._0x78ef11a5 != null)
        {
            DOTween.Kill(this._0x78ef11a5.transform);
            DOTween.Kill(this._0x78ef11a5);
        }

        DOTween.Kill(this.transform);
    }

    public int _0x91161f67
    {
        get
        {
            return this._0xafaee474;
        }
    }

    /// <summary>Green wash on the trail - the crate was the one the order wanted.</summary>
    public void _0xf9a1a31c()
    {
        if (this._0x78ef11a5 == null)
            return;
        this._0x78ef11a5.color = _0x5b09b348.Fade(_0x5b09b348.Green, 0.85f);
        DOTween.Kill(this._0x78ef11a5);
        this._0x78ef11a5.DOColor(_0x5b09b348.Fade(_0x5b09b348.Cyan, 0.45f), 0.35f);
    }

    private SpriteRenderer _0xe0dc0867;
    private SpriteRenderer _0x78ef11a5;
    private void _0xb8d597d2()
    {
        this._0xfdcb8ecf = false;
    }

    public void _0xc3322fa7(_0x385ff28c _0x06413aa6, _0x4e3c8ac5 _0x8b238226, _0x76eb34d4 _0x9bfcd877)
    {
        this._0xdb04cd13 = _0x9bfcd877;
        this._0xafaee474 = 1;
        this._0x78ef11a5 = _0x22d320c4.Quad(this.transform, _0x55cbe35d._0x7bc6fcb0(new byte[9] { 128, 162, 177, 183, 151, 177, 162, 170, 175 }, 195), _0x06413aa6.SlotFrame, new Vector2(_0x9bfcd877.CartSize.x * 0.78f, _0x9bfcd877.CartSize.y * 0.26f), new Vector2(_0x9bfcd877.LaneX[1], _0x9bfcd877.CartY - _0x9bfcd877.CartSize.y * 0.48f), _0x6f92d6a9.TrailOrder, _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.45f));
        this._0xe0dc0867 = _0x22d320c4.Spawn(_0x8b238226.Cart, this.transform, _0x55cbe35d._0x7bc6fcb0(new byte[9] { 72, 106, 121, 127, 91, 98, 103, 100, 127 }, 11), _0x06413aa6.CartHero, _0x9bfcd877.CartSize, new Vector2(_0x9bfcd877.LaneX[1], _0x9bfcd877.CartY), _0x6f92d6a9.CartOrder, Color.white);
        // The cart art is declared nose UP and horizontally symmetric, so it is never
        // mirrored - only tilted into the turn (rule C.8).
        this._0xe0dc0867.transform.localScale = Vector3.one;
        this._0xe0dc0867.transform.localRotation = Quaternion.identity;
    }

    /// <summary>One step left (-1) or right (+1). A step during a slide is ignored,
    /// so a fast player cannot queue up a crossing of the whole yard.</summary>
    public bool Step(int _0xb6219822)
    {
        if (this._0xdb04cd13 == null || this._0xe0dc0867 == null || this._0xfdcb8ecf)
            return false;
        int _0x86e01268 = Mathf.Clamp(this._0xafaee474 + (_0xb6219822 < 0 ? -1 : 1), 0, _0x6f92d6a9.Lanes - 1);
        if (_0x86e01268 == this._0xafaee474)
            return false;
        this._0xafaee474 = _0x86e01268;
        this._0xfdcb8ecf = true;
        Transform _0x04a8f216 = this._0xe0dc0867.transform;
        float _0x2af0ae1e = _0xb6219822 < 0 ? 12f : -12f;
        float _0x091e1e84 = this._0xdb04cd13.LaneX[this._0xafaee474];
        DOTween.Kill(_0x04a8f216);
        _0x04a8f216.DOLocalMoveX(_0x091e1e84, _0x6f92d6a9.LaneSlideSeconds).SetEase(Ease.OutQuad).OnComplete(() => this._0xb8d597d2());
        _0x04a8f216.DOLocalRotate(new Vector3(0f, 0f, _0x2af0ae1e), _0x6f92d6a9.LaneSlideSeconds * 0.75f).SetEase(Ease.OutQuad).OnComplete(() => this._0xd6883c14());
        if (this._0x78ef11a5 != null)
        {
            Transform _0x05b29b8d = this._0x78ef11a5.transform;
            DOTween.Kill(_0x05b29b8d);
            _0x05b29b8d.DOLocalMoveX(_0x091e1e84, _0x6f92d6a9.LaneSlideSeconds).SetEase(Ease.OutQuad);
        }

        return true;
    }

    /// <summary>Shake plus a red wash - wrong colour, or a barrier taken head on.</summary>
    public void _0x60241971()
    {
        if (this._0xe0dc0867 != null)
        {
            Transform _0xcadb95e3 = this._0xe0dc0867.transform;
            DOTween.Kill(_0xcadb95e3);
            _0xcadb95e3.DOShakePosition(0.25f, 0.12f, 18, 90f, false, true).OnComplete(() => this._0x4985faad());
        }

        if (this._0x78ef11a5 != null)
        {
            this._0x78ef11a5.color = _0x5b09b348.Fade(_0x5b09b348.Alarm, 0.9f);
            DOTween.Kill(this._0x78ef11a5);
            this._0x78ef11a5.DOColor(_0x5b09b348.Fade(_0x5b09b348.Cyan, 0.45f), 0.4f);
        }
    }

    private bool _0xfdcb8ecf;
    private void _0x4985faad()
    {
        if (this._0xe0dc0867 == null || this._0xdb04cd13 == null)
            return;
        this._0xe0dc0867.transform.localPosition = new Vector3(this._0xdb04cd13.LaneX[this._0xafaee474], this._0xdb04cd13.CartY, 0f);
        this._0xe0dc0867.transform.localRotation = Quaternion.identity;
        this._0xfdcb8ecf = false;
    }
}

internal static class _0x55cbe35d
{
    internal static string _0x7bc6fcb0(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}