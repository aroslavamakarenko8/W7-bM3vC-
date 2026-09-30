using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static _0x228d52ef;

public class _0x9934987c : MonoBehaviour
{
    public float ScaleDuration = 0.4f;
    public void _0x84d3ea6b(int _0x842d4f34)
    {
        this.CurrentPopIndex = _0x842d4f34;
        this.LastPopIndexes.Add(this.CurrentPopIndex);
        this._0x93b7dc58(true);
        this._0xc4c1c5a1();
        this.Pops[_0x842d4f34].Show();
        foreach (GameObject _0x6a0ce18a in this.GameObjectsToHide)
            _0x6a0ce18a.SetActive(false);
    }

    private void _0xc4c1c5a1()
    {
        this.BlurBackground.gameObject.SetActive(true);
    }

    public void _0xce94183f()
    {
        this.LastPopIndexes.RemoveAll(_0x2aad64aa => _0x2aad64aa == this.CurrentPopIndex);
        if (this.LastPopIndexes.Count <= 0)
            this._0x628aa6a9();
        else
            this._0x84d3ea6b(this.LastPopIndexes.Last());
    }

    private void _0x93b7dc58(bool _0x3833bfe1 = false)
    {
        for (int _0x75f9137e = 0; _0x75f9137e < this.Pops.Count; ++_0x75f9137e)
            if (this.Pops[_0x75f9137e] != null && !(_0x75f9137e == this.CurrentPopIndex && _0x3833bfe1))
                this.Pops[_0x75f9137e]._0xf1193384();
    }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x9934987c>();
    }

    public GameObject BlurBackground;
    public static _0x9934987c Instance;
    private void _0x5e19ab3a()
    {
        this.Invoke(nameof(this.BackgroundHidden), this.ScaleDuration);
    }

    private void BackgroundHidden()
    {
        this.BlurBackground.gameObject.SetActive(false);
    }

    private void Start()
    {
        this.BackgroundHidden();
        foreach (_0x9297c78f _0x865286c7 in this.Pops)
            if (_0x865286c7 != null)
                _0x865286c7.gameObject.SetActive(true);
    }

    public List<GameObject> GameObjectsToHide;
    public void _0x628aa6a9()
    {
        this.LastPopIndexes.Clear();
        this._0x93b7dc58();
        foreach (GameObject _0x0f47067b in this.GameObjectsToHide)
            if (_0x0f47067b != null)
                _0x0f47067b.SetActive(true);
        this._0x5e19ab3a();
    }

    public List<int> LastPopIndexes = new();
    public int CurrentPopIndex;
    public _0x9297c78f _0x67847b42(int _0xc1416861)
    {
        return this.Pops[_0xc1416861];
    }

    public List<_0x9297c78f> Pops;
}