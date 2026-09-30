using UnityEngine;
using UnityEngine.UI;

public class _0x70bd5d4d : MonoBehaviour
{
    private int _0x4baf44df;
    private void Awake()
    {
        if (this._0x78f1b175 == null)
            if (!this.TryGetComponent(out this._0x78f1b175))
                this._0x78f1b175 = this.GetComponentInChildren<Button>();
    }

    private bool _0x510046c5;
    private void Start()
    {
        if (this._0x510046c5)
            this._0x78f1b175.onClick.AddListener(() => _0x76586aa9.Instance._0xc2bcd1a9());
        else
            this._0x78f1b175.onClick.AddListener(() => _0x76586aa9.Instance._0x2d1a656b(this._0x4baf44df));
    }

    private Button _0x78f1b175;
}