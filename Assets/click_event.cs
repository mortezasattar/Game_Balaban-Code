using UnityEngine;
using UnityEngine.UIElements;

public class click_event : MonoBehaviour
{
    public string btn = "";
private void Start(){
    Debug.Log("start().....");
}
    private void OnEnable()
    {
        // گرفتن UIDocument
        var uiDocument = GetComponent<UIDocument>();

        // گرفتن Root
        var root = uiDocument.rootVisualElement;

        // گرفتن دکمه با نام مشخص‌شده در Inspector
        var selectButton = root.Q<Button>(btn);

        // بررسی اینکه دکمه پیدا شده
        if (selectButton != null)
        {
            selectButton.clicked += () =>
            {
                Debug.Log($"Button '{btn}' clicked");
            };
        }
        else
        {
            Debug.LogWarning($"Button '{btn}' not found");
        }
    }
}
