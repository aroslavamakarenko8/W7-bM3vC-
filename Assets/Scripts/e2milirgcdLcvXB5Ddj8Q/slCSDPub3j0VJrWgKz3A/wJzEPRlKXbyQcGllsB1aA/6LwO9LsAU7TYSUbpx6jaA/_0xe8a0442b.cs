using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _0xe8a0442b : MonoBehaviour
{
    public float FirstAnimationTime = 10.0f;
    public GameObject Error;
    private void _0x8f3334d4()
    {
        this.AnimationSlider.value = 0.05f;
        _0xa0d7c9cd = !_0xa0d7c9cd;
        this.AnimSliderSequence = DOTween.Sequence().Append(DOTween.To(() => this.AnimationSlider.value, _0x1d18469e => this.AnimationSlider.value = _0x1d18469e, 1f, this.FirstAnimationTime)).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (!_0x22cc60c8._0x40524e59._0xaf398bc9)
            {
                {
#if B_LOGS
                    {
                        Debug.Log($"[Test] Timer out -> move to scene");
                    }
#endif
                }

                _0x22cc60c8._0x40524e59._0x1964b544();
            }
        });
    }

    public float SecondPassSliderValue = 0.5f;
    public Sequence AnimSliderSequence;
    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0xe8a0442b>();
    }

    private static bool _0xa0d7c9cd = false;
    public Slider AnimationSlider;
    public float DefaultAnimationTime = 0.4f;
    public GameObject Background;
    public void _0xbf41e265()
    {
        this._0x4080c453();
        bool _0x52ad0210 = _0xa0d7c9cd;
        this.AnimSliderSequence = DOTween.Sequence().Append(DOTween.To(() => this.AnimationSlider.value, _0x1d18469e => this.AnimationSlider.value = _0x1d18469e, _0x52ad0210 ? 1f : this.SecondPassSliderValue, this.DefaultAnimationTime)).SetEase(Ease.Linear);
        _0xa0d7c9cd = !_0xa0d7c9cd;
    }

    public GameObject Content;
    public void _0x9e9c6afe()
    {
        {
#if B_LOGS
            {
                Debug.Log($"[Test] Animate Force");
            }
#endif
        }

        this.AnimSliderSequence?.Kill();
        if (AnimationSlider != null)
            this.AnimationSlider.value = 1f;
        _0xa0d7c9cd = false;
    }

    public void _0x4080c453()
    {
        this.AnimSliderSequence?.Kill();
        this.AnimationSlider.value = _0xa0d7c9cd ? this.SecondPassSliderValue : 0.05f;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == _0x228d52ef._0x8a0db87c.SCENE_0 && !_0xa0d7c9cd)
        {
            this._0x8f3334d4();
        }
        else
        {
            this._0xbf41e265();
        }
    }

    public static _0xe8a0442b Instance;
}