using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;
using UnityEngine.Events;
public class TimelineWaitForButton : MonoBehaviour
{
    public PlayableDirector timeline;
    public UIDocument uiDocument;

    void Start()
    {
        // در ابتدا Timeline به صورت عادی پلی می‌شه
        var root = uiDocument.rootVisualElement;
        var startButton = root.Q<Button>("start_quiz");

        if (startButton != null)
        {
            startButton.RegisterCallback<ClickEvent>(evt =>
            {
                timeline.Play();  // با کلیک روی دکمه، ادامه Timeline
                startButton.SetEnabled(false);  // غیرفعال کردن دکمه بعد از کلیک
            });
        }
    }

    // این تابع از Signal Receiver صدا زده می‌شه
    public void PauseTimeline()
    {
        timeline.Pause();  // توقف در ثانیه ۱
    }
}