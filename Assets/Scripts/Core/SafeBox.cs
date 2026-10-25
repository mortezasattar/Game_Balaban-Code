using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SafeBox : MonoBehaviour
{
    // Start is called before the first frame update
    private UIDocument uiDocument;
    private Label moneyLabel;
    VisualElement root;
    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();

        root = uiDocument.rootVisualElement;

        moneyLabel = root.Q<Label>("user_money");
        if (moneyLabel != null)
        {
            moneyLabel.text = PlayerPrefs.GetInt("money", 0).ToString();
        }
        LoadNextScene();

    }

    private async Task LoadNextScene()
    {
        await Task.Delay(5000);
        SceneManager.LoadSceneAsync("03-game_play_start");
       
    }
}
