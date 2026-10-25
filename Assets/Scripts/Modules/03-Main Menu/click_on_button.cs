using UnityEngine;
using UnityEngine.UIElements;

public class click_on_button : MonoBehaviour
{
      public AudioSource audioSource;
    public AudioClip clickSound;

    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null) return;

        var root = uiDocument.rootVisualElement;

        // گرفتن همه دکمه‌ها
        var allButtons = root.Query<Button>().ToList();

        foreach (var btn in allButtons)
        {
            btn.RegisterCallback<ClickEvent>(evt =>
            {
                if (audioSource != null && clickSound != null)
                {
                    audioSource.PlayOneShot(clickSound);
                }
            });
        }
    }
}
