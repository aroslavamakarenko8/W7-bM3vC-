using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0x91958194 : MonoBehaviour
{
    private void _0x9638a85a()
    {
        if (this._0xe35c506a.canvasRenderer.GetColor() != this._0xd5fb8b5a.canvasRenderer.GetColor())
            this._0xd5fb8b5a.canvasRenderer.SetColor(this._0xe35c506a.canvasRenderer.GetColor());
    }

    private void Update()
    {
        this._0x9638a85a();
    }

    private TMP_Text _0xd5fb8b5a;
    private Image _0xe35c506a;
}