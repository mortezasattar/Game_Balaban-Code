using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class TimelineJumpUI : MonoBehaviour
{
    public PlayableDirector director; // تایم‌لاین مورد نظر
    public float jumpTime = 5f;       // زمان دلخواه برای پرش در ثانیه

    private void OnEnable()
    {
        // گرفتن رفرنس به ریشه UI
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("No UIDocument component found on this GameObject.");
            return;
        }

        VisualElement root = uiDocument.rootVisualElement;

        // گرفتن رفرنس به دکمه
        Button jumpButton = root.Q<Button>("ok_next"); // نام دکمه در uxml

        if (jumpButton != null)
        {
            jumpButton.clicked += () =>
            {
                JumpToTime();
            };
        }
        else
        {
            Debug.LogError("No button with name 'jumpButton' found in UI Document.");
        }
    }

    private void JumpToTime()
    {
        if (director != null)
        {
            director.time = jumpTime;
            director.Play();
        }
    }
}
