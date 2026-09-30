using UnityEngine;
using UnityEngine.UI;

public class _0x730309ac : MonoBehaviour
{
    public bool IsPhysicsRunOnClick;
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    private void Start()
    {
        this.Button.onClick.AddListener(() => _0x639e6ff3.Instance._0xd3f68e63(this.IsPhysicsRunOnClick));
    }

    public Button Button;
}