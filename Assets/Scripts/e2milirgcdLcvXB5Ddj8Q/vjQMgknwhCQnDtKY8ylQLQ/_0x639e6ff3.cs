using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static _0x228d52ef;

public class _0x639e6ff3 : MonoBehaviour
{
    public void LoadSceneByIndex(int _0xde1a376d)
    {
        //if (SceneManager.GetActiveScene().buildIndex == sceneIndex)
        //    AdsInitializer.Instance?.ShowAd();
        this.StartCoroutine(this._0x73f36c3c(_0xde1a376d));
    }

    public void _0xf368c329()
    {
        foreach (_0x919aacb4 _0x39d6735d in this.MoneyCountContainers)
            _0x39d6735d._0x1f8fa8f3();
    }

    private static _0x050d3ccd GAME_INDEX_SETTINGS(int _0x4a12aeb6)
    {
        return _0x050d3ccd.ALL_SCENES_SETTING_SINGLETONS[_0x4a12aeb6];
    }

    private static _0x050d3ccd _0xa496947d => _0x050d3ccd.ALL_SCENES_SETTING_SINGLETONS[0];

    public Button DeleteProgressDataButton;
    public static bool IsAfterLevelFailed = false;
    public void _0xcc08efb5()
    {
        _0xcb3ab8f7._0xa872f7b9 = true;
    }

    public bool _0x80a41f77 { get; private set; }

    public void _0xd3f68e63(bool _0xd9192ac6)
    {
        this._0x80a41f77 = _0xd9192ac6;
        this._0x94dcef06(!this._0x80a41f77);
        Physics2D.simulationMode = this._0x80a41f77 ? SimulationMode2D.FixedUpdate : SimulationMode2D.Script;
        if (this.EnvironmentWithTweensToToggle != null)
            this._0x4ac5d2a3(this.EnvironmentWithTweensToToggle);
    }

    public static bool IsAfterLevelComplete;
    private void _0x4ac5d2a3(Transform _0x901d804a)
    {
        Transform[] _0x45aa60f2 = _0x901d804a.GetComponentsInChildren<Transform>();
        foreach (Transform _0x7f868fac in _0x45aa60f2)
            if (_0x7f868fac != null && DOTween.IsTweening(_0x7f868fac))
            {
                if (this._0x80a41f77)
                    DOTween.Play(_0x7f868fac);
                else
                    DOTween.Pause(_0x7f868fac);
            }
    }

    public Transform EnvironmentWithTweensToToggle;
    public Transform Environment;
    public Button ShowResetTutorialButton;
    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x639e6ff3>();
        this.RootGameObject = GameObject.FindWithTag(_0x73171176._0x3d0c4004(new byte[4] { 30, 35, 35, 56 }, 76));
        if (this._0xb0a403de == _0x8a0db87c.SCENE_0)
            this._0xd3f68e63(true);
        else
            this._0xd3f68e63(false);
        this.MoneyCountContainers = this.RootGameObject.GetComponentsInChildren<_0x919aacb4>(true).ToList();
    }

    private IEnumerator _0x73f36c3c(int _0xe13cbe67)
    {
        _0x76586aa9.Instance._0x2d1a656b(_0x837759f6.SPLASH);
        AsyncOperation _0xac804dae = SceneManager.LoadSceneAsync(_0xe13cbe67);
        while (!_0xac804dae.isDone)
            yield return null;
    }

    [HideInInspector]
    public List<_0x919aacb4> MoneyCountContainers = new();
    public Canvas MainCanvas;
    private static void ExitGame()
    {
        Application.Quit();
    }

    private void _0xd5994db4()
    {
        IsAfterLevelComplete = true;
        Instance.LoadSceneByIndex(_0x8a0db87c.SCENE_0);
    }

    [HideInInspector]
    public GameObject RootGameObject; // tag - "Root"
    private IEnumerator _0x4a1311ed(string _0xbec1e056)
    {
        _0x76586aa9.Instance._0x2d1a656b(_0x837759f6.SPLASH);
        //AudioController.Instance.SaveLastMusicTimes();
        AsyncOperation _0x2a274947 = SceneManager.LoadSceneAsync(_0xbec1e056);
        while (!_0x2a274947.isDone)
            yield return null;
    }

    public static _0x639e6ff3 Instance;
    public void _0xfdddc27d()
    {
        this.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);
    }

    private void _0x94dcef06(bool _0x26626258)
    {
        Rigidbody2D[] _0xd0f7ac9e = this.RootGameObject.GetComponentsInChildren<Rigidbody2D>(true);
        foreach (Rigidbody2D _0x53793d43 in _0xd0f7ac9e)
            if (_0x26626258)
                _0x53793d43.constraints = RigidbodyConstraints2D.FreezeAll;
            else
                _0x53793d43.constraints = RigidbodyConstraints2D.None;
    }

    private void Start()
    {
        if (this._0xb0a403de != _0x8a0db87c.SCENE_0)
            Screen.orientation = ScreenOrientation.Portrait;
        this.DeleteProgressDataButton?.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteAll();
            //AudioController.Instance.UpdateMusics();
            //AudioController.Instance.UpdateSfxes();
            Instance.LoadSceneByIndex(_0x8a0db87c.SCENE_0);
        });
        this.ShowResetTutorialButton?.onClick.AddListener(() =>
        {
            _0xcb3ab8f7._0xa872f7b9 = false;
            _0x9934987c.Instance._0x628aa6a9();
            _0x76586aa9.Instance._0x2d1a656b(_0x837759f6.TUTORIAL0);
        });
    }

    public static _0x050d3ccd _0xcb3ab8f7 => _0x050d3ccd.ALL_SCENES_SETTING_SINGLETONS[Instance._0xb0a403de];

    private static void MakeGrid(List<RectTransform> _0xd462bec2, AspectRatioFitter _0x2bdac419, float _0xf8611750, int _0x4875ad04, int _0xa449133c)
    {
        _0x2bdac419.aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
        _0x2bdac419.aspectRatio = _0xf8611750;
        foreach (RectTransform _0x0efaf169 in _0xd462bec2)
        {
            int _0x2d087e70 = _0x0efaf169.transform.GetSiblingIndex();
            _0x0efaf169.anchorMin = new Vector3(Mathf.FloorToInt((float)_0x2d087e70 % _0x4875ad04) * (1f / _0x4875ad04), (_0xa449133c - (Mathf.FloorToInt((float)_0x2d087e70 / _0x4875ad04) % _0xa449133c + 1f)) * (1f / _0xa449133c));
            _0x0efaf169.anchorMax = new Vector3(Mathf.FloorToInt((float)_0x2d087e70 % _0x4875ad04 + 1f) * (1f / _0x4875ad04), (_0xa449133c - Mathf.FloorToInt((float)_0x2d087e70 / _0x4875ad04) % _0xa449133c) * (1f / _0xa449133c));
            _0x0efaf169.offsetMin = Vector2.zero;
            _0x0efaf169.offsetMax = Vector2.zero;
        }
    }

    public int _0xb0a403de => SceneManager.GetActiveScene().buildIndex;
}

internal static class _0x73171176
{
    internal static string _0x3d0c4004(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}