using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0x907e012d : MonoBehaviour
{
    public void _0x9f3e9eeb()
    {
        if (!this.IsGameEnd)
        {
            this._0xf56aee37();
            _0x639e6ff3.IsAfterLevelComplete = true;
            _0x639e6ff3.IsAfterLevelFailed = false;
            _0x9297c78f _0x20f63864 = _0x9934987c.Instance._0x67847b42(_0x228d52ef._0x87f8de56.WIN).GetComponent<_0x9297c78f>();
            if (_0xac261965.Instance.IsCheckScoreEnabled)
                _0x20f63864.ContentMainText.text = $"{this.ScoreCurrent}/{this._0x84bb9365}";
            else
                _0x20f63864.ContentMainText.text = $"{this.ScoreCurrent}";
            if (_0xac261965.Instance.IsBestScoreEnabled)
            {
                if (this.ScoreCurrent > _0x228d52ef._0x9d930ff8._0x8709d36a)
                    _0x228d52ef._0x9d930ff8._0x8709d36a = this.ScoreCurrent;
                _0x20f63864.ContentAdditionalText.text = $"{_0x228d52ef._0x9d930ff8._0x8709d36a}";
            }
            else
            {
                _0x20f63864.ContentAdditionalText.text = $"{this._0xa9248d91}";
                _0x228d52ef._0x9d930ff8._0x8709d36a += this._0xa9248d91;
            }

            if (_0xac261965.Instance.IsLevelIncrementOnWin)
                ++_0x639e6ff3._0xcb3ab8f7._0x5c19c4ee;
            _0x9934987c.Instance._0x84d3ea6b(_0x228d52ef._0x87f8de56.WIN);
        }
    }

    private void Awake()
    {
        _0x256b75bd = this.gameObject.GetComponent<_0x907e012d>();
    }

    public List<TMP_Text> TimerText = new();
    public void _0xd5b2f70e(int scoreToAdd)
    {
        if (!this.IsGameEnd)
        {
            this.ScoreCurrent += scoreToAdd;
            this._0x742cb38f();
            this._0x7c30f056();
        }
    }

    public List<Button> HomeButtons = new();
    private int _0x84bb9365 => this.CustomTargetScore + _0x639e6ff3._0xcb3ab8f7._0x5c19c4ee * 10;

    private void _0x354e01b3()
    {
        if (this.ScoreCurrent >= this._0x84bb9365)
            this._0x9f3e9eeb();
        else
            this._0x5c9e4d20();
    }

    public List<TMP_Text> SubtitleText = new();
    private void _0x4bf51f9a()
    {
        this.TimerText.ForEach(_0xb8c57276 => _0xb8c57276.text = TimeSpan.FromSeconds(this.TimeLeft).ToString(_0x2cffb11f._0x360b731e(new byte[6] { 225, 225, 208, 182, 255, 255 }, 140)));
    }

    public List<Button> PauseButtons = new();
    private void _0x7c30f056()
    {
        if (this.ScoreCurrent > _0x639e6ff3._0xcb3ab8f7._0x4c792aee)
            _0x639e6ff3._0xcb3ab8f7._0x4c792aee = this.ScoreCurrent;
        if (_0xac261965.Instance.IsCheckScoreEnabled)
            if (this.ScoreCurrent >= this._0x84bb9365)
                this._0x9f3e9eeb();
    }

    private IEnumerator _0x7dab6f68()
    {
        this._0x4bf51f9a();
        while (!this.IsGameEnd && this.TimeLeft > 0 && _0x639e6ff3.Instance._0xb0a403de == this.CurrentGameIndex)
        {
            yield return new WaitForSeconds(1f);
            if (_0x639e6ff3.Instance._0x80a41f77)
            {
                if (this.IsGameEnd)
                    break;
                this.TimeLeft--;
                this._0x4bf51f9a();
            }
        }

        if (!this.IsGameEnd)
            this._0x5c9e4d20();
    }

    [HideInInspector]
    public int CurrentGameIndex;
    private int _0xa9248d91 => this.ScoreCurrent;

    [HideInInspector]
    public int ScoreCurrent;
    private int _0xb185327a => this.CustomTimeInitial + _0x639e6ff3._0xcb3ab8f7._0x5c19c4ee * 10;

    public List<TMP_Text> LevelNumberText = new();
    [HideInInspector]
    public bool IsGameEnd;
    private void Start()
    {
        this.IsGameEnd = false;
        this.TimeLeft = this._0xb185327a;
        this.CurrentGameIndex = _0x639e6ff3.Instance._0xb0a403de;
        foreach (Button _0x53a19115 in this.HomeButtons)
            _0x53a19115.onClick.AddListener(() =>
            {
                this._0x8c8e944d();
            });
        foreach (Button _0xf4be14bc in this.PauseButtons)
            _0xf4be14bc.onClick.AddListener(() =>
            {
                _0x639e6ff3.Instance._0xd3f68e63(false);
                _0x9934987c.Instance._0x84d3ea6b(_0x228d52ef._0x87f8de56.PAUSE);
            });
        this._0x742cb38f();
        this.LevelNumberText.ForEach(_0xb8c57276 => _0xb8c57276.text = $"LVL {_0x639e6ff3._0xcb3ab8f7._0x5c19c4ee + 1}");
        if (_0xac261965.Instance.IsTimerEnabled)
        {
            this._0x4bf51f9a();
            this.StartCoroutine(this._0x7dab6f68());
        }
    }

    private static _0x907e012d _0x256b75bd;
    private void _0xf56aee37()
    {
        this.IsGameEnd = true;
        _0x639e6ff3.IsAfterLevelComplete = true;
    }

    public void _0x5c9e4d20()
    {
        if (_0xac261965.Instance.IsOnlyWinGameEndEnabled)
            this._0x9f3e9eeb();
        if (!this.IsGameEnd)
        {
            this._0xf56aee37();
            _0x639e6ff3.IsAfterLevelComplete = false;
            _0x639e6ff3.IsAfterLevelFailed = true;
            _0x9297c78f _0x42f8a298 = _0x9934987c.Instance._0x67847b42(_0x228d52ef._0x87f8de56.LOSE).GetComponent<_0x9297c78f>();
            if (_0xac261965.Instance.IsCheckScoreEnabled)
                _0x42f8a298.ContentMainText.text = $"{this.ScoreCurrent}/{this._0x84bb9365}";
            else
                _0x42f8a298.ContentMainText.text = $"{this.ScoreCurrent}";
            _0x42f8a298.ContentAdditionalText.text = $"{0}";
            _0x228d52ef._0x9d930ff8._0x8709d36a += 0;
            _0x9934987c.Instance._0x84d3ea6b(_0x228d52ef._0x87f8de56.LOSE);
        }
    }

    public List<TMP_Text> ScoreText = new();
    public int CustomTargetScore = 10;
    private void _0x742cb38f()
    {
        if (_0xac261965.Instance.IsCheckScoreEnabled)
            this.ScoreText.ForEach(_0xb8c57276 => _0xb8c57276.text = $"{this.ScoreCurrent}/{this._0x84bb9365}");
        else
            this.ScoreText.ForEach(_0xb8c57276 => _0xb8c57276.text = $"{this.ScoreCurrent}");
    }

    public void _0x8c8e944d()
    {
        _0x639e6ff3.Instance._0xd3f68e63(true);
        _0x639e6ff3.Instance.LoadSceneByIndex(_0x228d52ef._0x8a0db87c.SCENE_0);
    }

    public int CustomTimeInitial = 30;
    [HideInInspector]
    public int TimeLeft;
}

internal static class _0x2cffb11f
{
    internal static string _0x360b731e(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}