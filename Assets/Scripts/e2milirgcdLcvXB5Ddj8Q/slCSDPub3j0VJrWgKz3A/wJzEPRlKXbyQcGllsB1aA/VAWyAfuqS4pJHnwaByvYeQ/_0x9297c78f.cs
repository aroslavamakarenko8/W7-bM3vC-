using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0x9297c78f : MonoBehaviour
{
    public void _0xf1193384()
    {
        if (this.Content.gameObject.activeSelf)
        {
            DOTween.Kill(this.Content.transform, true);
            if (this.IsOnlyYScale)
                this.Content.transform.DOScaleY(0f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
                {
                    this.Content.SetActive(false);
                });
            else
                this.Content.transform.DOScale(0f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
                {
                    this.Content.SetActive(false);
                });
        }
    }

    private void Start()
    {
    // Content.SetActive(false);
    }

    private void _0xc70b9766()
    {
        DOTween.Kill(this.Content.transform, true);
        if (this.IsOnlyYScale)
            this.Content.transform.DOScaleY(0f, 0.01f);
        else
            this.Content.transform.DOScale(0f, 0.01f);
        this.Content.SetActive(false);
    }

    public TMP_Text ContentHeaderText;
    public Image ContentImage;
    public static void HideAllPops()
    {
        _0x9934987c.Instance._0x628aa6a9();
    }

    private void Awake()
    {
        this.Content.SetActive(true);
        if (this.IsScaledDownOnAwake)
            this._0xc70b9766();
    }

    public float scaleDuration = 0.4f;
    private bool _0xbe390be2 => this.Content.transform.localScale.x > 0.5f && this.Content.transform.localScale.y > 0.5f;

    public GameObject Content;
    public void Show()
    {
        this.Content.SetActive(true);
        if ((DOTween.TweensByTarget(this.Content.transform)?.Count ?? 0) > 0)
            DOTween.Kill(this.Content.transform, true);
        if (this.IsOnlyYScale)
            this.Content.transform.DOScaleY(1f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
            {
            });
        else
            this.Content.transform.DOScale(1f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
            {
            });
    }

    public bool IsOnlyYScale;
    public bool IsScaledDownOnAwake = true;
    public TMP_Text ContentAdditionalText;
    public Ease ease = Ease.OutSine;
    public TMP_Text ContentMainText;
}