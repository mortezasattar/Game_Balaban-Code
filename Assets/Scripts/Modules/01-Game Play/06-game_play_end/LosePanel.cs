using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LosePanel : MonoBehaviour
{
    private UIDocument uiDocument;
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root;
        uiDocument = GameObject.FindFirstObjectByType<UIDocument>();
        // دریافت ریشه UI
        root = uiDocument.rootVisualElement;
        // پیدا کردن دکمه
        root.Q<Button>("retry").clicked += LoadSceneAgain;

        root.Q<Button>("close").clicked += GoToMainMenu;
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync("01-main_menu");
    }

    private async void LoadSceneAgain()
    {
        SceneManager.LoadSceneAsync("03-game_play_start");
    }
    private async Task WaitUntilDone(AsyncOperation operation)
    {
        while (!operation.isDone)
            await Task.Yield();
    }
}
