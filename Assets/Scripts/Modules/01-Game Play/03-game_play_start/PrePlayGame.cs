//using AptabaseSDK;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PrePlayGame : MonoBehaviour
{
    private UIDocument uiDocument;
    private Label moneyLabel;
    private Label starLabel;
    private Label goalPrice;
    private ProgressBar loadingBar;
    private VisualElement root;
    private Button myButton;
    private AsyncOperation ScenePreloaded;

    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        // برچسب‌ها
        moneyLabel = root.Q<Label>("user_money");
        starLabel = root.Q<Label>("stars_label");
        goalPrice = root.Q<Label>("goal_price");

        // دکمه‌ها
        myButton = root.Q<Button>("start");
        var closeButton = root.Q<Button>("close");

        // ProgressBar
        loadingBar = root.Q<ProgressBar>("loading_bar");
        // تنظیم اندازه
        loadingBar.style.width = 500;   
        loadingBar.style.height = 40;   


  
        loadingBar.style.backgroundColor = new Color(0.2f, 0.2f, 0.2f);

  
        loadingBar.Q(null, "unity-progress-bar__progress").style.backgroundColor = new Color(0.4f, 0f, 0.8f);


        ShowMoney();
        ShowStars();

        // بستن به منو
        if (closeButton != null)
        {
            closeButton.clicked += () =>
            {
                SceneManager.LoadScene("01-main_menu");
            };
        }

        // شروع بازی
        if (myButton != null)
        {
            myButton.clicked += OnStartGameClicked;
        }

        // Aptabase.TrackEvent("app_preplaygame");
    }

    void Start()
    {
        StartCoroutine(PreloadLevel(2)); // صحنه بعدی (مثلاً Level 1)
    }

    private void ShowMoney()
    {
        if (moneyLabel != null)
            moneyLabel.text = PlayerPrefs.GetInt("money", 0).ToString();

        if (goalPrice != null)
            goalPrice.text = PlayerPrefs.GetInt("NextGoalPrice", 200).ToString();
    }

    private void ShowStars()
    {
        if (starLabel != null)
            starLabel.text = PlayerPrefs.GetInt("Stars", 0).ToString();
    }

    public void OnStartGameClicked()
    {
        // پنهان کردن دکمه Start
        myButton.style.display = DisplayStyle.None;

        // نمایش ProgressBar
        if (loadingBar != null)
        {
            loadingBar.style.display = DisplayStyle.Flex;
            loadingBar.value = 0;
        }

        // شروع لودینگ فیکی
        StartCoroutine(FakeLoading());
    }

    private IEnumerator PreloadLevel(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
            yield return null;

        ScenePreloaded = asyncLoad;
    }

    private IEnumerator FakeLoading()
    {
        float fakeProgress = 0f;

        // مرحله ۱: تا رسیدن واقعی به 0.9
        while (ScenePreloaded != null && ScenePreloaded.progress < 0.9f)
        {
            fakeProgress = Mathf.Lerp(fakeProgress, ScenePreloaded.progress * 100f, Time.deltaTime * 2f);
            if (loadingBar != null)
                loadingBar.value = fakeProgress;
            yield return null;
        }

        // مرحله ۲: لودینگ فیکی تا 100%
        while (fakeProgress < 100f)
        {
            fakeProgress += Time.deltaTime * 40f;
            if (loadingBar != null)
                loadingBar.value = fakeProgress;
            yield return null;
        }

        yield return new WaitForSeconds(0.3f);

        // فعال‌سازی صحنه
        if (ScenePreloaded != null)
        {
            ScenePreloaded.allowSceneActivation = true;
        }
        else
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
}
