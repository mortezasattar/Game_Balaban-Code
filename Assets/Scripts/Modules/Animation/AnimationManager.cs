using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    // نوع انیمیشن
    public enum AnimationType
    {
        Move,
        Scale,
        Rotate,
        Fade
    }

    // تنظیمات انیمیشن
    public AnimationType animationType;
    public Vector3 targetPosition;
    public Vector3 targetScale;
    public float targetRotation;
    public float duration = 1f;
    public float delay = 0f;
    public float fadeTo = 1f;
    public bool loop = false;

    private void Start()
    {
        // اجرای انیمیشن بر اساس نوع انتخاب شده
        switch (animationType)
        {
            case AnimationType.Move:
                AnimateMove();
                break;
            case AnimationType.Scale:
                AnimateScale();
                break;
            case AnimationType.Rotate:
                AnimateRotate();
                break;
            case AnimationType.Fade:
                AnimateFade();
                break;
        }
    }

    // انیمیشن حرکت
    private void AnimateMove()
    {
        transform.DOMove(targetPosition, duration)
            .SetDelay(delay)
            .SetLoops(loop ? -1 : 0, LoopType.Yoyo);
    }

    // انیمیشن مقیاس
    private void AnimateScale()
    {
        transform.DOScale(targetScale, duration)
            .SetDelay(delay)
            .SetLoops(loop ? -1 : 0, LoopType.Yoyo);
    }

    // انیمیشن چرخش
    private void AnimateRotate()
    {
        transform.DORotate(new Vector3(0, targetRotation, 0), duration, RotateMode.FastBeyond360)
            .SetDelay(delay)
            .SetLoops(loop ? -1 : 0, LoopType.Yoyo);
    }

    // انیمیشن تغییر شفافیت
    private void AnimateFade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.DOFade(fadeTo, duration)
            .SetDelay(delay)
            .SetLoops(loop ? -1 : 0, LoopType.Yoyo);
    }
}
