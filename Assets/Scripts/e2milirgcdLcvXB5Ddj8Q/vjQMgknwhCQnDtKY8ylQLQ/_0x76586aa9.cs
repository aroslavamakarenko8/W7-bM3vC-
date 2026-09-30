using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static _0x228d52ef;

public class _0x76586aa9 : MonoBehaviour
{
    private void _0x84f40526(int _0x4fccdb9d)
    {
        this.LastPanelIndexes.Add(_0x4fccdb9d);
        this.CurrentPanelIndex = _0x4fccdb9d;
        for (int _0x3b4dfc26 = 0; _0x3b4dfc26 < this.Panels.Count; _0x3b4dfc26++)
            if (_0x3b4dfc26 != _0x4fccdb9d && this.Panels[_0x3b4dfc26] != null)
                this.Panels[_0x3b4dfc26]._0xf248aab5();
    }

    public bool IsShowSplashOnStart = true;
    public List<_0x6330b92a> Panels;
    private void Start()
    {
        this._0x836d938f();
    }

    [HideInInspector]
    public List<int> LastPanelIndexes = new()
    {
        1
    };
    public float StaticBlurMaterialInitialValue;
    private _0x6330b92a _0xb6beb079(int _0x53c40be0)
    {
        return this.Panels[_0x53c40be0];
    }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x76586aa9>();
    }

    public void _0x2d1a656b(int _0xcafde2e1)
    {
        this._0x84f40526(_0xcafde2e1);
        this._0x7d28798f(_0xcafde2e1);
        this.CurrentPanelIndex = _0xcafde2e1;
        this.Panels[_0xcafde2e1].Show();
    }

    private void _0x88ea97e4(int _0x9230def5)
    {
        this._0x84f40526(_0x9230def5);
        this._0x7d28798f(_0x9230def5);
        this.CurrentPanelIndex = _0x9230def5;
        this.Panels[_0x9230def5]._0x426564c4();
    }

    private void _0x944d92e3(int _0xe1480ba1)
    {
        this.LastPanelIndexes.Add(_0xe1480ba1);
        this.CurrentPanelIndex = _0xe1480ba1;
        for (int _0x687e2814 = 0; _0x687e2814 < this.Panels.Count; _0x687e2814++)
            if (_0x687e2814 != _0xe1480ba1 && this.Panels[_0x687e2814] != null)
                this.Panels[_0x687e2814]._0xf248aab5();
    }

    private void SwitchSplash()
    {
        if (_0xac261965.Instance.IsTutorialEnabled && !_0x639e6ff3._0xcb3ab8f7._0xa872f7b9)
            this._0x2d1a656b(_0x837759f6.TUTORIAL0);
        else
            this._0x2d1a656b(_0x837759f6.DEFAULT);
    }

    public float ScaleDuration = 0.4f;
    private void _0x7d28798f(int _0x131a6774)
    {
        if (_0x131a6774 == _0x837759f6.SPLASH)
            _0xe8a0442b.Instance._0x4080c453();
        if (_0x639e6ff3.Instance._0xb0a403de == _0x8a0db87c.SCENE_0)
        {
        }
    }

    public void _0xc2bcd1a9()
    {
        this.LastPanelIndexes.RemoveAll(_0x2aad64aa => _0x2aad64aa == this.CurrentPanelIndex);
        int _0x8e018165 = this.LastPanelIndexes.Last();
        this._0x7d28798f(_0x8e018165);
        this._0x944d92e3(_0x8e018165);
        this.CurrentPanelIndex = _0x8e018165;
        this.Panels[_0x8e018165].Show();
    }

    public int CurrentPanelIndex;
    private void _0x836d938f()
    {
        this._0x88ea97e4(_0x837759f6.SPLASH);
        if (_0x639e6ff3.Instance._0xb0a403de == _0x8a0db87c.SCENE_0)
        {
        }
        else
        {
            this.Invoke(nameof(this.SwitchSplash), _0xe8a0442b.Instance.DefaultAnimationTime);
        }
    }

    public void _0x60a1077c(int _0xea2c1037)
    {
        if (_0xea2c1037 == _0x837759f6.SPLASH && _0x639e6ff3.Instance._0xb0a403de != _0x8a0db87c.SCENE_0)
            _0xe8a0442b.Instance._0xbf41e265();
        if (_0x639e6ff3.Instance._0xb0a403de != _0x8a0db87c.SCENE_0)
        {
            if (_0xea2c1037 == _0x837759f6.SPLASH || _0xea2c1037 == _0x837759f6.TUTORIAL0)
                _0x639e6ff3.Instance._0xd3f68e63(false);
            else if (_0xea2c1037 == _0x837759f6.DEFAULT)
                _0x639e6ff3.Instance._0xd3f68e63(true);
        }
    }

    public static _0x76586aa9 Instance;
}