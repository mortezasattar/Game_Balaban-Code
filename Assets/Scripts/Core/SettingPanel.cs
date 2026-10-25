using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SettingPanel : MonoBehaviour
{
    private UIDocument uiDocument;
    // Start is called before the first frame update
    void Start()
    {
        uiDocument = GetComponent<UIDocument>();
        // دریافت ریشه UI
        VisualElement root = uiDocument.rootVisualElement;

        root.Q<Button>("setting").clicked += () =>
        {
            SceneManager.LoadScene(9);
        };
    }

    
}
