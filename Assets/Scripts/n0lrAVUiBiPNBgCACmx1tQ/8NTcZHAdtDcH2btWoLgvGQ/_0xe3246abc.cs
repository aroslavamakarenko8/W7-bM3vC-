using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class _0xe3246abc : MonoBehaviour
{
    private List<string> _0xf42ec391 = new();
    private float _0x13da7e38;
    private float _0x3481085c = 1.5f;
    private float _0x1a527105 = 4;
    private AspectRatioFitter _0xfe3eba94;
    private void Update()
    {
        int _0x424b09c7 = 1;
        if (this._0xf42ec391.Count > 0)
        {
            string _0x0243ec8d = this._0x67d21215.text;
            foreach (string _0xc38310af in this._0xf42ec391)
                while (_0x0243ec8d.Contains(_0xc38310af))
                    _0x0243ec8d = _0x0243ec8d.Replace(_0xc38310af, "");
            _0x424b09c7 = _0x0243ec8d.Length;
        }
        else
        {
            _0x424b09c7 = this._0x67d21215.text.Length;
        }

        float _0x77e17bcd = Mathf.Clamp(this._0x13da7e38 + this._0x2987c333 * _0x424b09c7, this._0x3481085c, this._0x1a527105);
        if (!Mathf.Approximately(this._0xfe3eba94.aspectRatio, _0x77e17bcd))
            this._0xfe3eba94.aspectRatio = _0x77e17bcd;
    }

    private float _0x2987c333 = 0.6f;
    private TMP_Text _0x67d21215;
}