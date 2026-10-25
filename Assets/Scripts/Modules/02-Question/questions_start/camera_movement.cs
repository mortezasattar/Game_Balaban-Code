using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class camera_movement : MonoBehaviour
{
    private Animator anim;
    public UIDocument _document;
    public float delay = 1f;
    public float duration = 1f;
    public float startTop = 2000f;    // نقطه شروع top
    public float endTop = 0f;         // نقطه پایان top
    public VisualTreeAsset _vquize;
    private VisualElement mainContainer;
    private Button _button;

    void Start()
    {
        anim = GetComponent<Animator>();
        _button = _document.rootVisualElement.Q<Button>("start_quiz");
        _button.clicked += go_to_quiz;
    }

    IEnumerator FadeOut(VisualElement element, float duration)
    {
        element.style.opacity = 1f; // شروع از ۱
        float elapsed = 0f;

        while (element.style.opacity.value > 0.01f)
        {
            elapsed += Time.deltaTime;
            float newOpacity = Mathf.Lerp(1f, 0f, elapsed / duration);
            element.style.opacity = newOpacity;
            yield return null;
        }

        element.style.opacity = 0f; // پایان در ۰
    }

    IEnumerator MoveIn(VisualElement element, float duration)
    {
        yield return new WaitForSeconds(delay); // تأخیر قبل از اجرا
        element.style.opacity = 0f; // شروع از ۰
        element.style.top = startTop; // مقدار اولیه top

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / duration;

            // حرکت از startTop به endTop
            element.style.opacity = Mathf.Clamp01(progress);
            element.style.top = Mathf.Lerp(startTop, endTop, progress);

            yield return null;
        }

        // مقدار نهایی
        element.style.opacity = 1f;
        element.style.top = endTop;
    }

    void go_to_quiz()
    {
        mainContainer = _document.rootVisualElement.Q<VisualElement>("main_container");
        
        // اجرای FadeOut و بعد جایگزینی VisualTree
        StartCoroutine(SwitchToQuiz());
    }

    IEnumerator SwitchToQuiz()
    {
        // محو کردن صفحه فعلی
        yield return StartCoroutine(FadeOut(mainContainer, duration));

        // جایگزینی VisualTreeAsset
        _document.visualTreeAsset = _vquize;

        // دریافت المان جدید
        mainContainer = _document.rootVisualElement.Q<VisualElement>("main_container");

        // آماده‌سازی برای ورود با انیمیشن
        mainContainer.style.opacity = 0f;
        mainContainer.style.top = startTop;

        // اجرای انیمیشن Unity
        anim.SetTrigger("Start");

        // اجرای انیمیشن MoveIn
        StartCoroutine(MoveIn(mainContainer, duration));
    }
}
