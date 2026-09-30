using UnityEngine;
using UnityEngine.UI;

public class _0xae3226d8 : MonoBehaviour
{
    private void Start()
    {
        if (this.IsShowLastPop)
            this.Button.onClick.AddListener(() =>
            {
                _0x9934987c.Instance._0xce94183f();
            });
        else if (this.IsHideAllPops)
            this.Button.onClick.AddListener(() => _0x9934987c.Instance._0x628aa6a9());
        else
            this.Button.onClick.AddListener(() => _0x9934987c.Instance._0x84d3ea6b(this.PopToShowIndex));
    }

    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    public bool IsShowLastPop;
    public bool IsHideAllPops;
    public Button Button;
    public int PopToShowIndex;
}