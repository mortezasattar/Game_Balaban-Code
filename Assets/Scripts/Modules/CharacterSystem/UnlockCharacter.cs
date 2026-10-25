using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UnlockCharacter : MonoBehaviour
{
    private UIDocument uiDocument;
    // Start is called before the first frame update
    void Start()
    {
       
        GoTOMainMenu();
    }
    private void GoTOMainMenu()
    {
        uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        root.Q<Button>("skip").clicked += LoadMainMenu;
    }
    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
