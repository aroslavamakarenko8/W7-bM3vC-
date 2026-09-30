using UnityEngine;

/// <summary>
/// Every sprite the yard is drawn from, handed round in one piece so no component
/// ever has to look an asset up by name. A director fills it from its own
/// serialized fields, which the scene assigns by guid.
/// </summary>
public sealed class _0x385ff28c
{
    public Sprite HazardCrate;
    public Sprite LaneFan;
    public Sprite IconPause;
    public Sprite IconBack;
    /// <summary>The crate face for a crate id, falling back to the first one so a
    /// missing asset never leaves an invisible pickup on the track.</summary>
    public Sprite _0x19c57fe3(int _0x932b5956)
    {
        if (this.Crates == null || this.Crates.Length == 0)
            return null;
        return this.Crates[Mathf.Clamp(_0x932b5956, 0, this.Crates.Length - 1)];
    }

    public Sprite TutSwipe;
    public Sprite _0x302001b7(int _0xeb6a7a3a)
    {
        return _0xeb6a7a3a == 0 ? this.HazardBarrier : this.HazardCrate;
    }

    public Sprite TutSignal;
    public Sprite HazardBarrier;
    public Sprite RailTile;
    public Sprite IconClose;
    public Sprite PipDead;
    public Sprite StationMarker;
    public Sprite MarkSignal;
    public Sprite[] Crates = new Sprite[0];
    public Sprite PlatePanel;
    public Sprite SlotFrame;
    public Sprite IconChevron;
    public Sprite TutOrder;
    public Sprite PipLive;
    public Sprite CartHero;
}

/// <summary>The spawnable pieces, authored as prefabs so each one arrives already
/// Sliced, already sized and already on the right sorting order.</summary>
public sealed class _0x4e3c8ac5
{
    public GameObject RailTile;
    public GameObject Crate;
    public GameObject Cart;
    public GameObject Hazard;
    public GameObject StationMarker;
}

/// <summary>
/// The yard geometry, derived from the camera every run (rule C.0). Nothing here
/// is a pixel count: on a taller phone the road simply gets taller, and the crates
/// keep their share of the track.
/// </summary>
public sealed class _0x76eb34d4
{
    public static _0x76eb34d4 FromCamera(Camera _0xc868a25a)
    {
        _0x76eb34d4 _0x7f162e69 = new _0x76eb34d4();
        _0x7f162e69.HalfHeight = _0xc868a25a == null ? 5f : _0xc868a25a.orthographicSize;
        float _0x91110372 = _0xc868a25a == null || _0xc868a25a.aspect <= 0f ? 9f / 19.5f : _0xc868a25a.aspect;
        _0x7f162e69.HalfWidth = _0x7f162e69.HalfHeight * _0x91110372;
        _0x7f162e69.RoadWidth = 2f * _0x7f162e69.HalfWidth * _0x6f92d6a9.RoadFraction;
        _0x7f162e69.LanePitch = _0x7f162e69.RoadWidth / _0x6f92d6a9.Lanes;
        _0x7f162e69.LaneX[0] = -_0x7f162e69.LanePitch;
        _0x7f162e69.LaneX[1] = 0f;
        _0x7f162e69.LaneX[2] = _0x7f162e69.LanePitch;
        float _0xd723d9e3 = _0x7f162e69.LanePitch * _0x6f92d6a9.CrateFraction;
        _0x7f162e69.CrateSize = new Vector2(_0xd723d9e3, _0xd723d9e3);
        float _0x7c78d4ac = _0x7f162e69.LanePitch * _0x6f92d6a9.CartFraction;
        _0x7f162e69.CartSize = new Vector2(_0x7c78d4ac, _0x7c78d4ac);
        _0x7f162e69.HazardSize = new Vector2(_0x7f162e69.LanePitch * _0x6f92d6a9.HazardWideFraction, _0x7f162e69.LanePitch * _0x6f92d6a9.HazardTallFraction);
        _0x7f162e69.RailTileSize = new Vector2(2f * _0x7f162e69.HalfWidth, _0x7f162e69.HalfHeight * _0x6f92d6a9.RailTileFraction);
        _0x7f162e69.CartY = -_0x7f162e69.HalfHeight * _0x6f92d6a9.CartDepthFraction;
        _0x7f162e69.SpawnY = _0x7f162e69.HalfHeight + _0x6f92d6a9.SpawnMargin;
        _0x7f162e69.DespawnY = -_0x7f162e69.HalfHeight - _0x6f92d6a9.SpawnMargin;
        return _0x7f162e69;
    }

    public Vector2 CartSize;
    public float DespawnY;
    public float HalfWidth = 2.3077f;
    public float CartY;
    public float[] LaneX = new float[_0x6f92d6a9.Lanes];
    public Vector2 HazardSize;
    public float RoadWidth;
    public Vector2 RailTileSize;
    public float LanePitch;
    public float SpawnY;
    public float HalfHeight = 5f;
    public Vector2 CrateSize;
}

/// <summary>
/// Thin factory for world art. Every renderer it hands back is Sliced with an
/// explicit size at scale 1, so what the camera maths asked for is what shows up.
/// </summary>
public static class _0x22d320c4
{
    public static void SetAlpha(SpriteRenderer _0x1131a384, float _0xcfc55697)
    {
        if (_0x1131a384 == null)
            return;
        Color _0x8148e96c = _0x1131a384.color;
        _0x1131a384.color = new Color(_0x8148e96c.r, _0x8148e96c.g, _0x8148e96c.b, _0xcfc55697);
    }

    public static SpriteRenderer Spawn(GameObject _0xadcbe6d3, Transform _0xae4e9b57, string _0xb780f75d, Sprite _0x1f97dd98, Vector2 _0x472a7c0a, Vector2 _0x8d7aa6c0, int _0x711516fe, Color _0x283770d6)
    {
        if (_0xadcbe6d3 == null)
            return Quad(_0xae4e9b57, _0xb780f75d, _0x1f97dd98, _0x472a7c0a, _0x8d7aa6c0, _0x711516fe, _0x283770d6);
        GameObject _0xe63c35a9 = Object.Instantiate(_0xadcbe6d3, _0xae4e9b57);
        _0xe63c35a9.name = _0xb780f75d;
        _0xe63c35a9.transform.localPosition = new Vector3(_0x8d7aa6c0.x, _0x8d7aa6c0.y, 0f);
        _0xe63c35a9.transform.localRotation = Quaternion.identity;
        _0xe63c35a9.transform.localScale = Vector3.one;
        SpriteRenderer _0x071a94d4 = _0xe63c35a9.GetComponent<SpriteRenderer>();
        if (_0x071a94d4 == null)
            _0x071a94d4 = _0xe63c35a9.AddComponent<SpriteRenderer>();
        if (_0x1f97dd98 != null)
            _0x071a94d4.sprite = _0x1f97dd98;
        _0x071a94d4.drawMode = SpriteDrawMode.Sliced;
        _0x071a94d4.size = _0x472a7c0a;
        _0x071a94d4.sortingOrder = _0x711516fe;
        _0x071a94d4.color = _0x283770d6;
        return _0x071a94d4;
    }

    public static SpriteRenderer Quad(Transform _0xe2a77d07, string _0x2f1922c1, Sprite _0xab7ee97b, Vector2 _0x02d4fde8, Vector2 _0x384f0088, int _0x053edb07, Color _0x49a77a1e)
    {
        GameObject _0x580fa62d = new GameObject(_0x2f1922c1);
        _0x580fa62d.transform.SetParent(_0xe2a77d07, false);
        _0x580fa62d.transform.localPosition = new Vector3(_0x384f0088.x, _0x384f0088.y, 0f);
        _0x580fa62d.transform.localScale = Vector3.one;
        SpriteRenderer _0xb2f477b3 = _0x580fa62d.AddComponent<SpriteRenderer>();
        _0xb2f477b3.sprite = _0xab7ee97b;
        _0xb2f477b3.drawMode = SpriteDrawMode.Sliced;
        _0xb2f477b3.size = _0x02d4fde8;
        _0xb2f477b3.sortingOrder = _0x053edb07;
        _0xb2f477b3.color = _0x49a77a1e;
        return _0xb2f477b3;
    }

    public static void Resize(SpriteRenderer _0xe872037f, Vector2 _0xb09fe0b2)
    {
        if (_0xe872037f == null)
            return;
        _0xe872037f.drawMode = SpriteDrawMode.Sliced;
        _0xe872037f.size = _0xb09fe0b2;
        _0xe872037f.transform.localScale = Vector3.one;
    }
}