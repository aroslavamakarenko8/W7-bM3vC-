using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/// <summary>What a row did to the run when it reached the cart.</summary>
public enum _0xa5242243
{
    Nothing,
    Delivered,
    WrongCrate,
    Crash,
}

/// <summary>One row of the yard as it exists on screen right now.</summary>
public sealed class _0x593278a7
{
    public SpriteRenderer[] CrateArt = new SpriteRenderer[0];
    public bool Resolved;
    public int[] CrateLane = new int[0];
    public int Index;
    public Transform Host;
    public int[] HazardLane = new int[0];
    public int[] CrateKind = new int[0];
    public bool[] CrateWanted = new bool[0];
    public SpriteRenderer[] HazardArt = new SpriteRenderer[0];
}

/// <summary>
/// Pours the yard past the camera: it lays an endless rail bed, drops the planned
/// rows at the spawn line, scrolls everything down at the route's speed, and hands
/// each row to the director the moment it meets the cart.
///
/// The grace rule lives here, because only here is the cart's CURRENT track known:
/// at the instant a row is built, the track the cart is standing on never receives
/// a barrier or a crate of the wrong colour. A player who never moves therefore
/// cannot take a strike, and the run always lasts the full line clock (rule C.5).
/// </summary>
public sealed class _0x0ca22b7a : MonoBehaviour
{
    private _0x4e3c8ac5 _0xd51d58e4;
    /// <summary>Highlight the track the cart is on, so the active lane reads at a glance.</summary>
    public void _0xfad23fe3(int _0xd4ad0a6e)
    {
        for (int _0x13ec4a49 = 0; _0x13ec4a49 < this._0xf705aeb4.Length; _0x13ec4a49++)
        {
            if (this._0xf705aeb4[_0x13ec4a49] == null)
                continue;
            this._0xf705aeb4[_0x13ec4a49].color = _0x13ec4a49 == _0xd4ad0a6e ? _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.16f) : _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.05f);
        }
    }

    private SpriteRenderer Barrier(Transform _0xeba885f3, int _0x17259cb1, int _0xba584956)
    {
        return _0x22d320c4.Spawn(this._0xd51d58e4.Hazard, _0xeba885f3, _0xac154cc3._0x051894f9(new byte[6] { 162, 139, 144, 139, 152, 142 }, 234), this._0x43d61674._0x302001b7(_0xba584956), this._0x2f2ed23c.HazardSize, new Vector2(this._0x2f2ed23c.LaneX[_0x17259cb1], 0f), _0x6f92d6a9.HazardOrder, Color.white);
    }

    private _0x385ff28c _0x43d61674;
    private SpriteRenderer[] _0xf705aeb4 = new SpriteRenderer[_0x6f92d6a9.Lanes];
    private readonly List<_0x593278a7> _0x15e7b1bd = new List<_0x593278a7>();
    private _0xbddf612c _0xfc0ae4a4;
    private void _0x702e0fcf(SpriteRenderer _0x1815aa57)
    {
        if (_0x1815aa57 == null)
            return;
        Transform _0xf24854b7 = _0x1815aa57.transform;
        Vector3 _0x27d2bece = Vector3.one * 1.35f;
        DOTween.Kill(_0xf24854b7);
        _0xf24854b7.DOScale(_0x27d2bece, 0.1f).SetEase(Ease.OutQuad).OnComplete(() => this._0x327fc57a(_0x1815aa57));
    }

    private void _0x25fa210c(float travel)
    {
        float _0xbcdcefc7 = this._0x2f2ed23c.RailTileSize.y;
        this._0x1ba57ae6 += travel;
        for (int _0x401f0f87 = 0; _0x401f0f87 < this._0x4eab8d0d.Count; _0x401f0f87++)
        {
            SpriteRenderer _0x19f46e40 = this._0x4eab8d0d[_0x401f0f87];
            if (_0x19f46e40 == null)
                continue;
            float _0x520a1ea4 = this._0x2f2ed23c.DespawnY + _0xbcdcefc7 * (_0x401f0f87 + 0.5f);
            float _0x33ea97ee = _0x520a1ea4 - Mathf.Repeat(this._0x1ba57ae6, _0xbcdcefc7 * this._0x4eab8d0d.Count);
            while (_0x33ea97ee < this._0x2f2ed23c.DespawnY)
                _0x33ea97ee += _0xbcdcefc7 * this._0x4eab8d0d.Count;
            _0x19f46e40.transform.localPosition = new Vector3(0f, _0x33ea97ee, 0f);
        }
    }

    public void _0xeac90e22()
    {
        for (int _0xc089c75b = 0; _0xc089c75b < this._0x15e7b1bd.Count; _0xc089c75b++)
        {
            if (this._0x15e7b1bd[_0xc089c75b].Host != null)
                Destroy(this._0x15e7b1bd[_0xc089c75b].Host.gameObject);
        }

        this._0x15e7b1bd.Clear();
    }

    public void _0x17fe3be4(_0xbddf612c _0x4860e6ab, _0x0a9f4dbc _0xc358a735, System.Random _0xcf4e710c)
    {
        this._0xfc0ae4a4 = _0x4860e6ab;
        this._0x0c69380c = _0xc358a735;
        this._0x722fa636 = _0xcf4e710c;
        this._0x3a9cf7fc = 0;
        this._0xcdabd54a = _0xc358a735.RowInterval * 0.35f;
        this._0xeac90e22();
    }

    private Transform _0xabffa7b0;
    private float _0xcdb47d7e()
    {
        return this._0x722fa636 == null ? 0.5f : (float)this._0x722fa636.NextDouble();
    }

    private readonly List<SpriteRenderer> _0x4eab8d0d = new List<SpriteRenderer>();
    public void _0x8ee4cddc(_0x385ff28c _0xfffa9842, _0x4e3c8ac5 _0xd8da3637, _0x76eb34d4 _0x421d8008, _0xf7566934 _0x825fda10)
    {
        this._0x43d61674 = _0xfffa9842;
        this._0xd51d58e4 = _0xd8da3637;
        this._0x2f2ed23c = _0x421d8008;
        this._0xa0226eab = _0x825fda10;
        this._0xabffa7b0 = new GameObject(_0xac154cc3._0x051894f9(new byte[7] { 242, 193, 201, 204, 226, 197, 196 }, 160)).transform;
        this._0xabffa7b0.SetParent(this.transform, false);
        this._0xfd932e08 = new GameObject(_0xac154cc3._0x051894f9(new byte[9] { 230, 219, 195, 231, 192, 198, 209, 213, 217 }, 180)).transform;
        this._0xfd932e08.SetParent(this.transform, false);
        // Four tiles in a ring cover a screen and a half, so the seam never shows.
        int _0x50e23982 = Mathf.CeilToInt(2f * _0x421d8008.HalfHeight / _0x421d8008.RailTileSize.y) + 2;
        for (int _0x21e3760c = 0; _0x21e3760c < _0x50e23982; _0x21e3760c++)
        {
            SpriteRenderer _0x30a379d8 = _0x22d320c4.Spawn(_0xd8da3637.RailTile, this._0xabffa7b0, _0xac154cc3._0x051894f9(new byte[8] { 112, 67, 75, 78, 118, 75, 78, 71 }, 34), _0xfffa9842.RailTile, _0x421d8008.RailTileSize, new Vector2(0f, _0x421d8008.DespawnY + _0x421d8008.RailTileSize.y * (_0x21e3760c + 0.5f)), _0x6f92d6a9.RailOrder, _0x5b09b348.Fade(Color.white, 0.92f));
            this._0x4eab8d0d.Add(_0x30a379d8);
        }

        for (int _0x80c0cfde = 0; _0x80c0cfde < _0x6f92d6a9.Lanes; _0x80c0cfde++)
        {
            this._0xf705aeb4[_0x80c0cfde] = _0x22d320c4.Quad(this.transform, _0xac154cc3._0x051894f9(new byte[12] { 113, 92, 83, 88, 120, 89, 90, 88, 122, 81, 82, 74 }, 61), _0xfffa9842.SlotFrame, new Vector2(_0x421d8008.LanePitch * 0.96f, 2f * _0x421d8008.HalfHeight), new Vector2(_0x421d8008.LaneX[_0x80c0cfde], 0f), _0x6f92d6a9.LaneGlowOrder, _0x5b09b348.Fade(_0x5b09b348.Cyan, 0.06f));
        }
    }

    private float _0xcdabd54a;
    private _0x76eb34d4 _0x2f2ed23c;
    private void _0x327fc57a(SpriteRenderer _0xb6a0ae59)
    {
        if (_0xb6a0ae59 == null)
            return;
        _0xb6a0ae59.transform.DOScale(0f, 0.08f).SetEase(Ease.InQuad);
    }

    private int _0x3a9cf7fc;
    private float _0x1ba57ae6;
    /// <summary>
    /// Advance the yard by one frame and report what the row that met the cart did.
    /// <paramref name = "head"/> is the colour the order strip is currently asking for.
    /// </summary>
    public _0xa5242243 _0xac54842d(float deltaTime, int _0x6256cdbc, out int _0x3513420f)
    {
        _0x3513420f = -1;
        if (this._0x0c69380c == null || this._0xfc0ae4a4 == null)
            return _0xa5242243.Nothing;
        float travel = this._0x0c69380c.ScrollSpeed * deltaTime;
        this._0x25fa210c(travel);
        this._0xcdabd54a += deltaTime;
        if (this._0xcdabd54a >= this._0x0c69380c.RowInterval && this._0x3a9cf7fc < this._0xfc0ae4a4.Rows.Length)
        {
            this._0xcdabd54a -= this._0x0c69380c.RowInterval;
            this._0x32fbaa55(this._0xfc0ae4a4.Rows[this._0x3a9cf7fc], this._0x3a9cf7fc, _0x6256cdbc);
            this._0x3a9cf7fc++;
        }

        _0xa5242243 _0xb548e993 = _0xa5242243.Nothing;
        for (int _0xaffcd866 = this._0x15e7b1bd.Count - 1; _0xaffcd866 >= 0; _0xaffcd866--)
        {
            _0x593278a7 _0xb3aee94b = this._0x15e7b1bd[_0xaffcd866];
            if (_0xb3aee94b.Host == null)
            {
                this._0x15e7b1bd.RemoveAt(_0xaffcd866);
                continue;
            }

            Vector3 _0xc118fcee = _0xb3aee94b.Host.localPosition;
            _0xc118fcee.y -= travel;
            _0xb3aee94b.Host.localPosition = _0xc118fcee;
            if (!_0xb3aee94b.Resolved && _0xc118fcee.y <= this._0x2f2ed23c.CartY)
            {
                _0xb3aee94b.Resolved = true;
                int _0x7c413e83;
                _0xa5242243 _0x572fcda1 = this._0x51064660(_0xb3aee94b, out _0x7c413e83);
                if (_0x572fcda1 != _0xa5242243.Nothing)
                {
                    _0xb548e993 = _0x572fcda1;
                    _0x3513420f = _0x7c413e83;
                }
            }

            if (_0xc118fcee.y < this._0x2f2ed23c.DespawnY)
            {
                Destroy(_0xb3aee94b.Host.gameObject);
                this._0x15e7b1bd.RemoveAt(_0xaffcd866);
            }
        }

        return _0xb548e993;
    }

    private _0xf7566934 _0xa0226eab;
    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
    }

    private Transform _0xfd932e08;
    private void _0x0007001c(SpriteRenderer _0xd442a4de)
    {
        if (_0xd442a4de == null)
            return;
        DOTween.Kill(_0xd442a4de);
        _0xd442a4de.DOColor(_0x5b09b348.Alarm, 0.09f);
        _0xd442a4de.transform.DOScale(0f, 0.12f).SetEase(Ease.InQuad).SetDelay(0.09f);
    }

    // -- the moment a row meets the cart ---------------------------------------
    private _0xa5242243 _0x51064660(_0x593278a7 _0x1e6ac8cf, out int _0x013f4f92)
    {
        _0x013f4f92 = -1;
        int _0xd865548e = this._0xa0226eab != null ? this._0xa0226eab._0x91161f67 : 1;
        for (int _0x0ec1d295 = 0; _0x0ec1d295 < _0x1e6ac8cf.HazardLane.Length; _0x0ec1d295++)
        {
            if (_0x1e6ac8cf.HazardLane[_0x0ec1d295] != _0xd865548e)
                continue;
            this._0x6dc1ef54(_0x1e6ac8cf.HazardArt[_0x0ec1d295]);
            return _0xa5242243.Crash;
        }

        for (int _0xabd5fbde = 0; _0xabd5fbde < _0x1e6ac8cf.CrateLane.Length; _0xabd5fbde++)
        {
            if (_0x1e6ac8cf.CrateLane[_0xabd5fbde] != _0xd865548e)
                continue;
            _0x013f4f92 = _0x1e6ac8cf.CrateKind[_0xabd5fbde];
            if (_0x1e6ac8cf.CrateWanted[_0xabd5fbde])
            {
                this._0x702e0fcf(_0x1e6ac8cf.CrateArt[_0xabd5fbde]);
                return _0xa5242243.Delivered;
            }

            this._0x0007001c(_0x1e6ac8cf.CrateArt[_0xabd5fbde]);
            return _0xa5242243.WrongCrate;
        }

        return _0xa5242243.Nothing;
    }

    private _0x0a9f4dbc _0x0c69380c;
    private System.Random _0x722fa636;
    // -- one row ---------------------------------------------------------------
    private void _0x32fbaa55(_0xed49d1c5 _0x48e353c7, int _0x18059bf1, int _0x0666b874)
    {
        int _0x5cae83f4 = this._0xa0226eab != null ? this._0xa0226eab._0x91161f67 : 1;
        int _0x64039199 = _0x48e353c7.WantedLane;
        int _0x102b02d2 = _0x48e353c7.DecoyLane;
        List<int> _0xc75ed835 = new List<int>();
        for (int _0xa3733898 = 0; _0xa3733898 < _0x48e353c7.HazardLanes.Length; _0xa3733898++)
            _0xc75ed835.Add(_0x48e353c7.HazardLanes[_0xa3733898]);
        _0xc75ed835.Remove(_0x5cae83f4);
        if (_0x102b02d2 == _0x5cae83f4)
            _0x102b02d2 = -1;
        if (_0x64039199 >= 0)
        {
            if (this._0xcdb47d7e() < this._0x0c69380c.GraceChance)
            {
                _0x64039199 = _0x5cae83f4;
                _0xc75ed835.Remove(_0x5cae83f4);
            }
            else if (_0x64039199 == _0x5cae83f4)
            {
                for (int _0x259d5618 = 1; _0x259d5618 <= _0x6f92d6a9.Lanes - 1; _0x259d5618++)
                {
                    int _0x76f5f6ee = (_0x5cae83f4 + _0x259d5618) % _0x6f92d6a9.Lanes;
                    if (_0x76f5f6ee == _0x102b02d2)
                        continue;
                    _0x64039199 = _0x76f5f6ee;
                    break;
                }

                _0xc75ed835.Remove(_0x64039199);
            }
        }

        GameObject _0x82ba7c07 = new GameObject(_0xac154cc3._0x051894f9(new byte[8] { 159, 185, 170, 168, 160, 153, 164, 188 }, 203));
        _0x82ba7c07.transform.SetParent(this._0xfd932e08, false);
        _0x82ba7c07.transform.localPosition = new Vector3(0f, this._0x2f2ed23c.SpawnY, 0f);
        _0x593278a7 _0xa4204f02 = new _0x593278a7();
        _0xa4204f02.Host = _0x82ba7c07.transform;
        _0xa4204f02.Index = _0x18059bf1;
        List<int> _0x14253a7f = new List<int>();
        List<int> _0xf7f2380d = new List<int>();
        List<bool> _0x044b68a0 = new List<bool>();
        List<SpriteRenderer> _0xfceaebe1 = new List<SpriteRenderer>();
        if (_0x64039199 >= 0)
        {
            _0x14253a7f.Add(_0x64039199);
            _0xf7f2380d.Add(_0x0666b874);
            _0x044b68a0.Add(true);
            _0xfceaebe1.Add(this.Crate(_0x82ba7c07.transform, _0x64039199, _0x0666b874));
        }

        if (_0x102b02d2 >= 0)
        {
            int _0x06d5e248 = (_0x0666b874 + _0x48e353c7.DecoyOffset) % _0x6f92d6a9.CrateKinds;
            _0x14253a7f.Add(_0x102b02d2);
            _0xf7f2380d.Add(_0x06d5e248);
            _0x044b68a0.Add(false);
            _0xfceaebe1.Add(this.Crate(_0x82ba7c07.transform, _0x102b02d2, _0x06d5e248));
        }

        List<SpriteRenderer> _0x554a67ec = new List<SpriteRenderer>();
        for (int _0xdd9a5d52 = 0; _0xdd9a5d52 < _0xc75ed835.Count; _0xdd9a5d52++)
            _0x554a67ec.Add(this.Barrier(_0x82ba7c07.transform, _0xc75ed835[_0xdd9a5d52], _0x48e353c7.HazardVariant));
        if (_0x48e353c7.MarkerSide != 0)
        {
            float _0x4cf166bd = this._0x2f2ed23c.HalfWidth - this._0x2f2ed23c.LanePitch * 0.22f;
            SpriteRenderer _0x48b635a8 = _0x22d320c4.Spawn(this._0xd51d58e4.StationMarker, _0x82ba7c07.transform, _0xac154cc3._0x051894f9(new byte[13] { 192, 231, 242, 231, 250, 252, 253, 222, 242, 225, 248, 246, 225 }, 147), this._0x43d61674.StationMarker, new Vector2(this._0x2f2ed23c.LanePitch * 0.42f, this._0x2f2ed23c.LanePitch * 0.84f), new Vector2(_0x48e353c7.MarkerSide * _0x4cf166bd, 0f), _0x6f92d6a9.MarkerOrder, _0x5b09b348.Fade(_0x5b09b348.Amber, 0.9f));
            _0x48b635a8.flipX = _0x48e353c7.MarkerSide < 0;
        }

        _0xa4204f02.CrateLane = _0x14253a7f.ToArray();
        _0xa4204f02.CrateKind = _0xf7f2380d.ToArray();
        _0xa4204f02.CrateWanted = _0x044b68a0.ToArray();
        _0xa4204f02.CrateArt = _0xfceaebe1.ToArray();
        _0xa4204f02.HazardLane = _0xc75ed835.ToArray();
        _0xa4204f02.HazardArt = _0x554a67ec.ToArray();
        this._0x15e7b1bd.Add(_0xa4204f02);
    }

    private void _0x6dc1ef54(SpriteRenderer _0x4468446f)
    {
        if (_0x4468446f == null)
            return;
        DOTween.Kill(_0x4468446f);
        _0x4468446f.DOColor(_0x5b09b348.Alarm, 0.09f).SetLoops(2, LoopType.Yoyo);
        _0x4468446f.transform.DOPunchScale(Vector3.one * 0.2f, 0.25f, 6, 0.6f);
    }

    private SpriteRenderer Crate(Transform _0x960aea42, int _0x8a69cc6b, int _0xa5abceb8)
    {
        SpriteRenderer _0x40f75122 = _0x22d320c4.Spawn(this._0xd51d58e4.Crate, _0x960aea42, _0xac154cc3._0x051894f9(new byte[5] { 15, 62, 45, 56, 41 }, 76), this._0x43d61674._0x19c57fe3(_0xa5abceb8), this._0x2f2ed23c.CrateSize, new Vector2(this._0x2f2ed23c.LaneX[_0x8a69cc6b], 0f), _0x6f92d6a9.CrateOrder, Color.white);
        return _0x40f75122;
    }
}

internal static class _0xac154cc3
{
    internal static string _0x051894f9(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}