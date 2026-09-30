using UnityEngine;
using UnityEngine.UI;

public class _0xcf4c3e4b : MonoBehaviour
{
    public int NextTutorialPanelIndex;
    public bool IsTutorialEndPanel;
    public Button NextTutorialButton;
    private void Start()
    {
        if (this.NextTutorialButton != null)
        {
            if (this.IsTutorialEndPanel)
            {
                this.NextTutorialButton.onClick.AddListener(() => _0x76586aa9.Instance._0x2d1a656b(this.EndTutorialPanelIndex));
                this.NextTutorialButton.onClick.AddListener(() => _0x639e6ff3.Instance._0xcc08efb5());
            }
            else
            {
                this.NextTutorialButton.onClick.AddListener(() => _0x76586aa9.Instance._0x2d1a656b(this.NextTutorialPanelIndex));
            }
        }

        if (this.TutorialEndButton != null)
        {
            this.TutorialEndButton.onClick.AddListener(() => _0x76586aa9.Instance._0x2d1a656b(this.EndTutorialPanelIndex));
            this.TutorialEndButton.onClick.AddListener(() => _0x639e6ff3.Instance._0xcc08efb5());
        }
    }

    public Button TutorialEndButton;
    public int EndTutorialPanelIndex = 1;
}