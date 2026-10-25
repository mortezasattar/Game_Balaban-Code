using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CollectNftCard : MonoBehaviour
{
    // Start is called before the first frame update
    private UIDocument uiDocument;
    private VisualElement root;
    private int level = 0;
    void Start()
    {
        uiDocument =GetComponent<UIDocument>();
        // دریافت ریشه UI
        root = uiDocument.rootVisualElement;
        root.Q<Button>("skip").clicked += () =>
        {
            level = PlayerPrefs.GetInt("LevelIndex", 0);
            PlayerPrefs.SetInt("LevelIndex", level + 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        };
    }

    
}
