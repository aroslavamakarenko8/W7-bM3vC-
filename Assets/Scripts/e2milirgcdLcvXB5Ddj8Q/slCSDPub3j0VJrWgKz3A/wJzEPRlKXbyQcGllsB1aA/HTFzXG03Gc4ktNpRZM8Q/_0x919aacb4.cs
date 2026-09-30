using TMPro;
using UnityEngine;
using static _0x228d52ef;

public class _0x919aacb4 : MonoBehaviour
{
    public TMP_Text MoneyCountText;
    public void _0x1f8fa8f3()
    {
        this.MoneyCountText.text = _0x9d930ff8._0x8709d36a.ToString();
    }

    private void Start()
    {
        if (this.MoneyCountText == null)
        {
            TMP_Text _0xf97ea370;
            if (this.gameObject.TryGetComponent(out _0xf97ea370))
                this.MoneyCountText = _0xf97ea370;
        }

        this._0x1f8fa8f3();
    }
}