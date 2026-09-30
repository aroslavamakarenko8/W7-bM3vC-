using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0x6330b92a : MonoBehaviour
{
    private void _0xbfe02420()
    {
        if (this.OuterBackground != null)
        {
            Image _0x077298f1 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x077298f1, true);
            _0x077298f1.DOFade(1f, 0f);
        }
    }

    public TMP_Text HeaderText;
    public void _0xf248aab5()
    {
        this._0xde9393cf();
        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.DOScale(0f, this.ScaleDuration).SetEase(this.Ease).OnComplete(() =>
        {
            this.Content.SetActive(false);
        });
    }

    public float ScaleDuration = 0.4f;
    public bool IsScaledDownOnAwake = true;
    public GameObject OuterBackground;
    private void _0xf18601e0()
    {
        if (this.OuterBackground != null)
        {
            Image _0x0ebc787b = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x0ebc787b, true);
            _0x0ebc787b.DOFade(1f, this.ScaleDuration / 2f);
        }
    }

    public void _0x426564c4()
    {
        this._0xbfe02420();
        this.Content.SetActive(true);
        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.localScale = Vector3.one;
        _0x76586aa9.Instance._0x60a1077c(_0x76586aa9.Instance.CurrentPanelIndex);
    }

    public TMP_Text MainText;
    private bool _0x362daec9 => this.Content.transform.localScale.x > 0.5f && this.Content.transform.localScale.y > 0.5f;

    private void _0xde9393cf()
    {
        if (this.OuterBackground != null)
        {
            Image _0x0c988fc0 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x0c988fc0, true);
            _0x0c988fc0.DOFade(0f, this.ScaleDuration);
        }
    }

    public GameObject Content;
    private void Awake()
    {
        this.Content.SetActive(true);
        if (this.OuterBackground != null)
            this.OuterBackground.gameObject.SetActive(true);
        if (this.IsScaledDownOnAwake)
            this._0x82f33411();
    }

    public void Show()
    {
        this._0xf18601e0();
        if (this.Content != null)
        {
            DOTween.Kill(this.Content.transform, true);
            this.Content.SetActive(true);
            this.Content.transform.DOScale(1f, this.ScaleDuration).SetEase(this.Ease).OnComplete(() =>
            {
                _0x76586aa9.Instance._0x60a1077c(_0x76586aa9.Instance.CurrentPanelIndex);
            });
        }
    }

    public Ease Ease = Ease.OutSine;
    private void _0x82f33411()
    {
        if (this.OuterBackground != null)
        {
            Image _0x73849db2 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x73849db2, true);
            _0x73849db2.DOFade(0f, 0.01f);
        }

        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.DOScale(0f, 0.01f);
    }
}