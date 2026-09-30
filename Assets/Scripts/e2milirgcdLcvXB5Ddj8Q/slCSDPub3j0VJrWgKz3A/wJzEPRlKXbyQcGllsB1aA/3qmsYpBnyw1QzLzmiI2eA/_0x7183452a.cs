using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _0x7183452a : MonoBehaviour
{
    public bool IsLoadCurrentScene;
    private void Start()
    {
        if (this.IsLoadCurrentScene)
            this.Button.onClick.AddListener(() =>
            {
                _0x639e6ff3.Instance.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);
            });
        else
            this.Button.onClick.AddListener(() => _0x639e6ff3.Instance.LoadSceneByIndex(this.LoadSceneId));
    }

    public int LoadSceneId;
    public Button Button;
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }
}