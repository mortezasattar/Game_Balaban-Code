//using AptabaseSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SelecStageUI : MonoBehaviour
{
    private UIDocument uiDocument;
    private Label moneyLabel;
    // Start is called before the first frame update
    void Start()
    {
        uiDocument = GetComponent<UIDocument>();
        // دریافت ریشه UI
        VisualElement root = uiDocument.rootVisualElement;

        // پیدا کردن دکمه
        Button myButton = root.Q<Button>("lets_go"); // نام دکمه‌ای که در UI Builder تنظیم کردید

        // اضافه کردن رویداد کلیک
        if (myButton != null)
        {
            myButton.clicked += () => OnStartGameClicked();
        }
        if(!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetInt("money", 500);
        }
        ShowMoney();
        //Aptabase.TrackEvent("app_selectstage");
    }
    private void ShowMoney()
    {
        uiDocument = GameObject.FindFirstObjectByType<UIDocument>();
        // دریافت ریشه UI
        VisualElement root = uiDocument.rootVisualElement;

        // پیدا کردن دکمه
        moneyLabel = root.Q<Label>("money");

        // اضافه کردن رویداد کلیک
        if (moneyLabel != null)
        {
            moneyLabel.text = (PlayerPrefs.HasKey("money") != null ? PlayerPrefs.GetInt("money") : 0).ToString();
        }
    }
    public void OnStartGameClicked()
    {
        SceneManager.LoadScene(2);
    }
}
