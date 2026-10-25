//using AptabaseSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TradeUI : MonoBehaviour
{
    [SerializeField] Button sellBtn;
    [SerializeField] Button saveBtn;
    [SerializeField] Button cancelBtn;

    private UIDocument uiDocument;
    private Label moneyLabel;
    VisualElement root;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        uiDocument = GetComponent<UIDocument>();
        // دریافت ریشه UI
        root = uiDocument.rootVisualElement;

        // پیدا کردن دکمه
        sellBtn = root.Q<Button>("trade_sell"); // نام دکمه‌ای که در UI Builder تنظیم کردید
        saveBtn = root.Q<Button>("trade_save"); // نام دکمه‌ای که در UI Builder تنظیم کردید
        cancelBtn = root.Q<Button>("close"); // نام دکمه‌ای که در UI Builder تنظیم کردید


        ShowMoney();
        sellBtn.clicked += () => SellClicked();
        saveBtn.clicked += () =>  SaveClicked();
        cancelBtn.clicked += () =>  SaveClicked();

        //Aptabase.TrackEvent("app_trade");
    }

    private void ShowMoney()
    {

        // پیدا کردن دکمه
        moneyLabel = root.Q<Label>("Label"); 

        // اضافه کردن رویداد کلیک
        if (moneyLabel != null)
        {
            moneyLabel.text = (PlayerPrefs.HasKey("money") != null ? PlayerPrefs.GetInt("money") : 0).ToString();
        }
    }
    

    public void SaveClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void SellClicked()
    {
        moneyLabel.text = (PlayerPrefs.HasKey("money") != null ? PlayerPrefs.GetInt("money") + 250 : 0).ToString();
        PlayerPrefs.SetInt("money", int.Parse(moneyLabel.text));
        sellBtn.clicked -= SellClicked;
    }
    public void CancelClicked()
    {
        SceneManager.LoadScene(0);
    }
}
