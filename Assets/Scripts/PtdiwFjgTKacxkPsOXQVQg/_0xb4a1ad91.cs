using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch.Touch;

/// <summary>
/// One run down the freight line. The yard scrolls past, the strip on top says
/// which crate the order wants next, and the player moves the cart between three
/// tracks to meet the right one. Three wrong crates or crashes shut the line down;
/// so does the line clock running out.
///
/// The whole yard is built here from serialized art and camera-derived sizes, so
/// the scene template never carries this game's content (rule C.2), and each of
/// the three result cards is fetched by index and dressed before it is raised
/// (rule C.3).
/// </summary>
public sealed class _0xb4a1ad91 : MonoBehaviour
{
    private float _0xf47d1c2d;
    [SerializeField]
    private Sprite _stationMarker;
    [SerializeField]
    private GameObject _stationMarkerPrefab;
    private void _0x6555128f()
    {
        this._0x9e7dc898++;
        this._0x0a46764a();
    }

    private _0x0ca22b7a _0x12b9ca42;
    private int _0xdbc39da8()
    {
        int _0x7ae0c7c1 = this._0xcfbc6474 + this._0x3af406c6 + this._0x9e7dc898;
        if (_0x7ae0c7c1 <= 0)
            return 0;
        return Mathf.RoundToInt(this._0xcfbc6474 * 100f / _0x7ae0c7c1);
    }

    [SerializeField]
    private TMP_FontAsset _font;
    [SerializeField]
    private Sprite _hazardBarrier;
    private void _0x6203465d()
    {
        _0x5d1b9d8b._0x8eed499e = (this._0x6d2b741a + 1) % _0x6f92d6a9.Routes.Length;
        this._0x14f6af34();
    }

    private _0x385ff28c _0x955a78b1;
    private int _0xf25b346b = -1;
    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
    }

    private int _0x9e7dc898;
    private float _0xfeaeffa8;
    private _0x4ae19aac _0xe6743597;
    /// <summary>
    /// A horizontal flick moves one track. A short press without travel counts as a
    /// tap and moves towards the side it landed on - but only inside the band of the
    /// screen the HUD leaves free, so a tap meant for BACK or PAUSE never steers.
    /// </summary>
    private void Steer(Vector2 _0x07b70808, Vector2 _0xd0a6d912, float _0x379d262c)
    {
        if (this._0x9ce45062 == null || Time.unscaledTime < this._0x46de8703)
            return;
        Vector2 _0x42cbfa88 = _0xd0a6d912 - _0x07b70808;
        bool _0x17495a51 = _0x379d262c <= _0x6f92d6a9.SwipeSeconds && Mathf.Abs(_0x42cbfa88.x) >= _0x6f92d6a9.SwipePixels && Mathf.Abs(_0x42cbfa88.x) > Mathf.Abs(_0x42cbfa88.y) * _0x6f92d6a9.SwipeDominance;
        int _0xd8f44d50 = 0;
        if (_0x17495a51)
        {
            _0xd8f44d50 = _0x42cbfa88.x < 0f ? -1 : 1;
        }
        else if (Mathf.Abs(_0x42cbfa88.x) < _0x6f92d6a9.SwipePixels && Mathf.Abs(_0x42cbfa88.y) < _0x6f92d6a9.SwipePixels)
        {
            float height = Mathf.Max(1f, Screen.height);
            float _0xd8e86d3e = _0xd0a6d912.y / height;
            if (_0xd8e86d3e < 0.18f || _0xd8e86d3e > 0.7f)
                return;
            _0xd8f44d50 = _0xd0a6d912.x < Screen.width * 0.5f ? -1 : 1;
        }

        if (_0xd8f44d50 == 0)
            return;
        if (this._0x9ce45062.Step(_0xd8f44d50))
            this._0x12b9ca42._0xfad23fe3(this._0x9ce45062._0x91161f67);
    }

    private void _0xe72e2652()
    {
        _0x9934987c.Instance._0x628aa6a9();
        this._0x32370174 = _0x2646be6a.Running;
        this._0x46de8703 = Time.unscaledTime + 0.3f;
        if (_0x639e6ff3.Instance != null)
            _0x639e6ff3.Instance._0xd3f68e63(true);
    }

    private int _0xb3d14554;
    private readonly _0xe9ab41a3 _0x94c97db6 = new _0xe9ab41a3();
    [SerializeField]
    private Sprite[] _crateSprites = new Sprite[0];
    [SerializeField]
    private GameObject _railTilePrefab;
    private void _0x0a46764a()
    {
        this._0x205af47c = 0;
        this._0xb3d14554++;
        this._0x9ce45062._0x60241971();
        _0x5d1b9d8b.Buzz();
        if (this._0xe6743597 != null)
            this._0xe6743597._0xb7f548e4(this._0xb3d14554);
        if (this._0xb3d14554 >= _0x6f92d6a9.StrikeBudget)
            this._0x89df58f2();
    }

    [SerializeField]
    private Sprite _slotFrame;
    private int _0x205af47c;
    private int _0x6d2b741a;
    private int _0xcfbc6474;
    private void Start()
    {
        this._0xefd8e063 = _0x76eb34d4.FromCamera(this._0xa2619c33);
        this._0x6d2b741a = _0x5d1b9d8b._0x8eed499e;
        this._0x6ce450f8 = _0x6f92d6a9.Route(this._0x6d2b741a);
        GameObject _0x55c63223 = new GameObject(_0x71459ee4._0x59310ca5(new byte[8] { 161, 153, 138, 156, 187, 153, 138, 140 }, 248));
        _0x55c63223.transform.SetParent(this.transform, false);
        this._0x9ce45062 = _0x55c63223.AddComponent<_0xf7566934>();
        this._0x9ce45062._0xc3322fa7(this._0x955a78b1, this._0x860dcd34, this._0xefd8e063);
        GameObject _0x7ff52301 = new GameObject(_0x71459ee4._0x59310ca5(new byte[10] { 48, 8, 27, 13, 58, 29, 27, 12, 8, 4 }, 105));
        _0x7ff52301.transform.SetParent(this.transform, false);
        this._0x12b9ca42 = _0x7ff52301.AddComponent<_0x0ca22b7a>();
        this._0x12b9ca42._0x8ee4cddc(this._0x955a78b1, this._0x860dcd34, this._0xefd8e063, this._0x9ce45062);
        _0xc3776c65.SanitiseTutorials(this._font);
        _0xc3776c65.ThemeSplashSlider();
        this._0x233c478a = this.gameObject.AddComponent<_0xec8ea307>();
        this._0x233c478a._0x40881727(this._0x955a78b1, this._font);
        Transform _0x18f2fe30 = _0xc3776c65.PanelContent(_0x228d52ef._0x837759f6.DEFAULT);
        if (_0x18f2fe30 != null)
        {
            _0xc3776c65.ClearTemplateChrome(_0x18f2fe30);
            RectTransform _0x4f08aae8 = _0xc3776c65.Host(_0x18f2fe30, _0x71459ee4._0x59310ca5(new byte[7] { 150, 145, 138, 155, 140, 145, 128 }, 196));
            this._0xe6743597 = _0x4f08aae8.gameObject.AddComponent<_0x4ae19aac>();
            this._0xe6743597.Build(_0x4f08aae8, this._0x955a78b1, this._font, () => this._0x18a22fd9(), () => this._0x8ef94310());
        }

        this._0x2a9ccb32();
    }

    [SerializeField]
    private Sprite _iconPause;
    private int _0x8eeed9ae;
    [SerializeField]
    private Sprite _railTile;
    // -- the run ---------------------------------------------------------------
    private void _0x2a9ccb32()
    {
        int _0xc0349e98 = _0x5d1b9d8b.TakeAttempt();
        float _0x0cdc7e51 = (this._0xefd8e063.SpawnY - this._0xefd8e063.CartY) / Mathf.Max(0.01f, this._0x6ce450f8.ScrollSpeed);
        this._0xeec394c2 = this._0x94c97db6.Build(this._0x6d2b741a, _0xc0349e98, _0x0cdc7e51);
        this._0xa36a3834 = new System.Random(this._0xeec394c2.Seed ^ 0x5F3A);
        this._0x8eeed9ae = 0;
        this._0xcfbc6474 = 0;
        this._0x3af406c6 = 0;
        this._0x9e7dc898 = 0;
        this._0xb3d14554 = 0;
        this._0x205af47c = 0;
        this._0x1817f73b = 0;
        this._0x9c0c1427 = false;
        this._0xfeaeffa8 = this._0x6ce450f8.LineSeconds;
        this._0xa1dbc5ae = this._0x6ce450f8.LineSeconds;
        this._0xd5baab0d = _0x6f92d6a9.IntroSeconds;
        this._0xf47d1c2d = _0x6f92d6a9.HintWideSeconds;
        this._0x12b9ca42._0x17fe3be4(this._0xeec394c2, this._0x6ce450f8, this._0xa36a3834);
        this._0x12b9ca42._0xfad23fe3(this._0x9ce45062._0x91161f67);
        this._0x9ce45062._0xdc329a58();
        if (this._0xe6743597 != null)
        {
            this._0xe6743597._0x552ee7fc(this._0xeec394c2, this._0x8eeed9ae);
            this._0xe6743597._0xd272eaa9(this._0xa1dbc5ae, this._0xfeaeffa8);
            this._0xe6743597._0xa1162e0a(0, this._0xeec394c2._0x8a0f87ee);
            this._0xe6743597._0xb7f548e4(0);
            this._0xe6743597._0x7bc289ad(true);
        }

        this._0x32370174 = _0x2646be6a.Rolling;
    }

    [SerializeField]
    private Sprite _iconBack;
    private int _0x3af406c6;
    private _0x4e3c8ac5 _0x860dcd34;
    [SerializeField]
    private GameObject _cartPrefab;
    [SerializeField]
    private Sprite _iconClose;
    private System.Random _0xa36a3834;
    [SerializeField]
    private GameObject _hazardPrefab;
    private void _0x14f6af34()
    {
        if (_0x639e6ff3.Instance == null)
            return;
        _0x639e6ff3.Instance._0xd3f68e63(true);
        _0x639e6ff3.Instance.LoadSceneByIndex(_0x228d52ef._0x8a0db87c.SCENE_1);
    }

    private enum _0x2646be6a
    {
        Waiting,
        Rolling,
        Running,
        Halted,
        Finished,
    }

    private Camera _0xa2619c33;
    [SerializeField]
    private Sprite _pipDead;
    // -- result cards ----------------------------------------------------------
    private void _0x17ca2869()
    {
        this._0x32370174 = _0x2646be6a.Finished;
        this._0x12b9ca42._0xeac90e22();
        _0x5d1b9d8b.Record(this._0x6d2b741a, this._0xcfbc6474, this._0xdbc39da8(), true);
        if (_0x639e6ff3.Instance != null)
            _0x639e6ff3.Instance._0xd3f68e63(false);
        _0x9297c78f _0xc9ad696f = _0x9934987c.Instance._0x67847b42(_0x228d52ef._0x87f8de56.WIN);
        this._0x233c478a._0x47efc8de(_0xc9ad696f, _0x71459ee4._0x59310ca5(new byte[13] { 115, 110, 116, 117, 100, 1, 98, 109, 100, 96, 115, 100, 101 }, 33), _0x5b09b348.Amber, this._0xcfbc6474 + _0x71459ee4._0x59310ca5(new byte[3] { 79, 64, 79 }, 111) + this._0xeec394c2._0x8a0f87ee + _0x71459ee4._0x59310ca5(new byte[17] { 30, 125, 108, 127, 106, 123, 109, 30, 122, 123, 114, 119, 104, 123, 108, 123, 122 }, 62), _0x71459ee4._0x59310ca5(new byte[9] { 199, 197, 197, 211, 212, 199, 197, 223, 166 }, 134) + this._0xdbc39da8() + _0x71459ee4._0x59310ca5(new byte[13] { 212, 251, 179, 180, 162, 165, 209, 178, 185, 176, 184, 191, 209 }, 241) + this._0x1817f73b, _0x71459ee4._0x59310ca5(new byte[10] { 241, 250, 231, 235, 159, 237, 240, 234, 235, 250 }, 191), () => this._0x6203465d(), _0x71459ee4._0x59310ca5(new byte[5] { 245, 226, 243, 245, 254 }, 167), () => this._0x14f6af34(), _0x71459ee4._0x59310ca5(new byte[4] { 30, 22, 29, 6 }, 83), () => this._0x18a22fd9());
        _0x9934987c.Instance._0x84d3ea6b(_0x228d52ef._0x87f8de56.WIN);
    }

    private _0x76eb34d4 _0xefd8e063;
    // The pop buttons sit inside the same screen band the steering taps read, and
    // the order in which UGUI and this component see one frame is not defined. A
    // short lock after the card closes keeps the tap that pressed RESUME from also
    // moving the cart.
    private float _0x46de8703;
    private _0x0a9f4dbc _0x6ce450f8;
    // -- steering: a horizontal flick, or a tap on the free half of the yard ---
    private void _0x02285bad()
    {
        if (this._0xa2619c33 == null)
            return;
        int _0xf1af9f03 = ETouch.activeTouches.Count;
        for (int _0x7622a1ec = 0; _0x7622a1ec < _0xf1af9f03; _0x7622a1ec++)
        {
            ETouch _0x787a767c = ETouch.activeTouches[_0x7622a1ec];
            if (_0x787a767c.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                this._0xf25b346b = _0x787a767c.touchId;
                this._0x833453a9 = _0x787a767c.screenPosition;
                this._0xa951766e = Time.unscaledTime;
                continue;
            }

            bool _0xf473a5ba = _0x787a767c.phase == UnityEngine.InputSystem.TouchPhase.Ended;
            if (!_0xf473a5ba || _0x787a767c.touchId != this._0xf25b346b)
                continue;
            this._0xf25b346b = -1;
            this.Steer(this._0x833453a9, _0x787a767c.screenPosition, Time.unscaledTime - this._0xa951766e);
        }

        if (_0xf1af9f03 > 0)
            return;
        Pointer _0x08cee909 = Pointer.current;
        if (_0x08cee909 == null)
            return;
        if (_0x08cee909.press.wasPressedThisFrame)
        {
            this._0x833453a9 = _0x08cee909.position.ReadValue();
            this._0xa951766e = Time.unscaledTime;
        }
        else if (_0x08cee909.press.wasReleasedThisFrame)
        {
            this.Steer(this._0x833453a9, _0x08cee909.position.ReadValue(), Time.unscaledTime - this._0xa951766e);
        }
    }

    [SerializeField]
    private Sprite _cartHero;
    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        this._0xa2619c33 = Camera.main;
        this._0x955a78b1 = new _0x385ff28c
        {
            CartHero = this._cartHero,
            Crates = this._crateSprites,
            HazardBarrier = this._hazardBarrier,
            HazardCrate = this._hazardCrate,
            RailTile = this._railTile,
            StationMarker = this._stationMarker,
            SlotFrame = this._slotFrame,
            PlatePanel = this._platePanel,
            PipLive = this._pipLive,
            PipDead = this._pipDead,
            IconBack = this._iconBack,
            IconPause = this._iconPause,
            IconClose = this._iconClose,
            IconChevron = this._iconChevron,
        };
        this._0x860dcd34 = new _0x4e3c8ac5
        {
            Crate = this._cratePrefab,
            Hazard = this._hazardPrefab,
            RailTile = this._railTilePrefab,
            StationMarker = this._stationMarkerPrefab,
            Cart = this._cartPrefab,
        };
    }

    [SerializeField]
    private GameObject _cratePrefab;
    private _0xf7566934 _0x9ce45062;
    private void _0x8ef94310()
    {
        if (this._0x32370174 == _0x2646be6a.Finished || this._0x32370174 == _0x2646be6a.Halted)
            return;
        this._0x32370174 = _0x2646be6a.Halted;
        if (_0x639e6ff3.Instance != null)
            _0x639e6ff3.Instance._0xd3f68e63(false);
        _0x9297c78f _0xfe0ae5b7 = _0x9934987c.Instance._0x67847b42(_0x228d52ef._0x87f8de56.PAUSE);
        this._0x233c478a._0x47efc8de(_0xfe0ae5b7, _0x71459ee4._0x59310ca5(new byte[9] { 54, 51, 52, 63, 90, 50, 63, 54, 62 }, 122), _0x5b09b348.TextPrimary, _0x6f92d6a9.Pad(this._0xcfbc6474) + _0x71459ee4._0x59310ca5(new byte[3] { 174, 161, 174 }, 142) + _0x6f92d6a9.Pad(this._0xeec394c2._0x8a0f87ee) + _0x71459ee4._0x59310ca5(new byte[17] { 128, 227, 242, 225, 244, 229, 243, 128, 228, 229, 236, 233, 246, 229, 242, 229, 228 }, 160), _0x71459ee4._0x59310ca5(new byte[55] { 247, 243, 237, 244, 225, 132, 235, 246, 132, 240, 229, 244, 132, 232, 225, 226, 240, 132, 139, 132, 246, 237, 227, 236, 240, 132, 240, 235, 132, 231, 236, 229, 234, 227, 225, 132, 240, 246, 229, 231, 239, 174, 247, 237, 227, 234, 229, 232, 247, 132, 232, 225, 226, 240, 132 }, 164) + (_0x6f92d6a9.StrikeBudget - this._0xb3d14554) + _0x71459ee4._0x59310ca5(new byte[3] { 28, 19, 28 }, 60) + _0x6f92d6a9.StrikeBudget, _0x71459ee4._0x59310ca5(new byte[6] { 200, 223, 201, 207, 215, 223 }, 154), () => this._0xe72e2652(), _0x71459ee4._0x59310ca5(new byte[7] { 125, 106, 124, 123, 110, 125, 123 }, 47), () => this._0x14f6af34(), _0x71459ee4._0x59310ca5(new byte[4] { 175, 167, 172, 183 }, 226), () => this._0x18a22fd9());
        _0x9934987c.Instance._0x84d3ea6b(_0x228d52ef._0x87f8de56.PAUSE);
    }

    [SerializeField]
    private Sprite _iconChevron;
    private void _0x89df58f2()
    {
        this._0x32370174 = _0x2646be6a.Finished;
        this._0x12b9ca42._0xeac90e22();
        _0x5d1b9d8b.Record(this._0x6d2b741a, this._0xcfbc6474, this._0xdbc39da8(), false);
        if (_0x639e6ff3.Instance != null)
            _0x639e6ff3.Instance._0xd3f68e63(false);
        _0x9297c78f _0x5681f2e2 = _0x9934987c.Instance._0x67847b42(_0x228d52ef._0x87f8de56.LOSE);
        this._0x233c478a._0x47efc8de(_0x5681f2e2, this._0x9c0c1427 ? _0x71459ee4._0x59310ca5(new byte[11] { 96, 122, 123, 15, 96, 105, 15, 123, 102, 98, 106 }, 47) : _0x71459ee4._0x59310ca5(new byte[14] { 57, 60, 59, 48, 85, 38, 61, 32, 33, 85, 49, 58, 34, 59 }, 117), _0x5b09b348.Cyan, this._0xcfbc6474 + _0x71459ee4._0x59310ca5(new byte[3] { 73, 70, 73 }, 105) + this._0xeec394c2._0x8a0f87ee + _0x71459ee4._0x59310ca5(new byte[17] { 179, 208, 193, 210, 199, 214, 192, 179, 215, 214, 223, 218, 197, 214, 193, 214, 215 }, 147), _0x71459ee4._0x59310ca5(new byte[9] { 108, 110, 110, 120, 127, 108, 110, 116, 13 }, 45) + this._0xdbc39da8() + _0x71459ee4._0x59310ca5(new byte[13] { 161, 142, 198, 193, 215, 208, 164, 199, 204, 197, 205, 202, 164 }, 132) + this._0x1817f73b, _0x71459ee4._0x59310ca5(new byte[5] { 137, 158, 143, 137, 130 }, 219), () => this._0x14f6af34(), _0x71459ee4._0x59310ca5(new byte[4] { 127, 119, 124, 103 }, 50), () => this._0x18a22fd9(), string.Empty, () => this._0x18a22fd9());
        _0x9934987c.Instance._0x84d3ea6b(_0x228d52ef._0x87f8de56.LOSE);
    }

    private void _0xc293171f()
    {
        this._0x3af406c6++;
        this._0x0a46764a();
    }

    [SerializeField]
    private Sprite _platePanel;
    private _0x2646be6a _0x32370174 = _0x2646be6a.Waiting;
    private void _0x18a22fd9()
    {
        if (_0x639e6ff3.Instance == null)
            return;
        _0x639e6ff3.Instance._0xd3f68e63(true);
        _0x639e6ff3.Instance.LoadSceneByIndex(_0x228d52ef._0x8a0db87c.SCENE_0);
    }

    private float _0xa951766e;
    private int _0x1817f73b;
    private float _0xa1dbc5ae;
    // -- outcomes --------------------------------------------------------------
    private void _0x1bf1f163()
    {
        this._0xcfbc6474++;
        this._0x205af47c++;
        this._0x1817f73b = Mathf.Max(this._0x1817f73b, this._0x205af47c);
        this._0x8eeed9ae = Mathf.Min(this._0x8eeed9ae + 1, this._0xeec394c2._0x8a0f87ee);
        this._0x9ce45062._0xf9a1a31c();
        _0x5d1b9d8b.Buzz();
        if (this._0xe6743597 != null)
        {
            this._0xe6743597._0xb04d838b(this._0xeec394c2, this._0x8eeed9ae);
            this._0xe6743597._0xa1162e0a(this._0xcfbc6474, this._0xeec394c2._0x8a0f87ee);
        }

        // Every fifth crate in a row buys time back, so the goal stays reachable for
        // a player who is actually driving (rule C.5).
        if (this._0x205af47c % _0x6f92d6a9.StreakBonusEvery == 0)
        {
            this._0xa1dbc5ae = Mathf.Min(this._0xfeaeffa8, this._0xa1dbc5ae + _0x6f92d6a9.StreakBonusSeconds);
            if (this._0xe6743597 != null)
            {
                this._0xe6743597._0xd272eaa9(this._0xa1dbc5ae, this._0xfeaeffa8);
                this._0xe6743597._0x252e9c68(_0x6f92d6a9.StreakBonusSeconds);
            }
        }

        if (this._0xcfbc6474 >= this._0xeec394c2._0x8a0f87ee)
            this._0x17ca2869();
    }

    private bool _0x9c0c1427;
    private Vector2 _0x833453a9;
    [SerializeField]
    private Sprite _pipLive;
    private float _0xd5baab0d;
    private _0xbddf612c _0xeec394c2;
    [SerializeField]
    private Sprite _hazardCrate;
    private _0xec8ea307 _0x233c478a;
    private void Update()
    {
        if (this._0x32370174 == _0x2646be6a.Waiting || this._0x32370174 == _0x2646be6a.Finished || this._0x32370174 == _0x2646be6a.Halted)
            return;
        if (_0x639e6ff3.Instance != null && !_0x639e6ff3.Instance._0x80a41f77)
            return;
        float dt = Time.deltaTime;
        if (this._0xf47d1c2d > 0f)
        {
            this._0xf47d1c2d -= dt;
            if (this._0xf47d1c2d <= 0f && this._0xe6743597 != null)
                this._0xe6743597._0x7bc289ad(false);
        }

        if (this._0x32370174 == _0x2646be6a.Rolling)
        {
            this._0xd5baab0d -= dt;
            if (this._0xd5baab0d <= 0f)
                this._0x32370174 = _0x2646be6a.Running;
        }

        this._0x02285bad();
        int _0xb0e14ef0;
        _0xa5242243 _0xf7083900 = this._0x12b9ca42._0xac54842d(dt, this._0xeec394c2._0xa819aef1(this._0x8eeed9ae), out _0xb0e14ef0);
        if (_0xf7083900 == _0xa5242243.Delivered)
            this._0x1bf1f163();
        else if (_0xf7083900 == _0xa5242243.WrongCrate)
            this._0xc293171f();
        else if (_0xf7083900 == _0xa5242243.Crash)
            this._0x6555128f();
        if (this._0x32370174 != _0x2646be6a.Running)
            return;
        this._0xa1dbc5ae -= dt;
        if (this._0xe6743597 != null)
            this._0xe6743597._0xd272eaa9(this._0xa1dbc5ae, this._0xfeaeffa8);
        if (this._0xa1dbc5ae <= 0f)
        {
            this._0x9c0c1427 = true;
            this._0x89df58f2();
        }
    }
}

internal static class _0x71459ee4
{
    internal static string _0x59310ca5(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}