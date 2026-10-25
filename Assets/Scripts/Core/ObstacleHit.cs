using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ObstacleHit : MonoBehaviour
{
    [SerializeField] private GameObject moneyIndicator;
    [SerializeField] private GameObject moneyIndicatorPos;


    private UIDocument uiDocument;
    private Label moneyLabel;
    private Label starLabel;
    VisualElement root;
    private int tempMoney = 0;
    private int playerMoney = 0;
    private string questionStart = "09-questions_start";
    GameObject indicator;
    private bool boosterIsOn = false;
    private void Awake()
    {
       
        //DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        uiDocument = GameObject.FindFirstObjectByType<UIDocument>();
        // دریافت ریشه UI
        root = uiDocument.rootVisualElement;
        ShowMoney();
        ShowStars();
        UsedMoneyBooster();
    }
    private void ShowMoney()
    {
        // پیدا کردن دکمه
        moneyLabel = root.Q<Label>("Label"); // نام دکمه‌ای که در UI Builder تنظیم کردید

       

        // اضافه کردن رویداد کلیک
        if (moneyLabel != null)
        {
            playerMoney = PlayerPrefs.GetInt("money", 0);
            moneyLabel.text = playerMoney.ToString();
        }
    }

    private void ShowStars()
    {

        starLabel = root.Q<Label>("stars_label");

        if (starLabel != null)
        {
            starLabel.text = PlayerPrefs.GetInt("Stars", 0).ToString();
        }
    }
    private void UsedMoneyBooster()
    {
        Button booster = root.Q<Button>("use_powerup");
        booster.clicked += () =>
        {
            if (int.Parse(starLabel.text) > 0)
            {
                starLabel.text = (int.Parse(starLabel.text) - 10).ToString();
                PlayerPrefs.SetInt("Stars", int.Parse(starLabel.text));
                booster.SetEnabled(false);
                //booster.style.backgroundColor = new StyleColor(Color.red);

                StartCoroutine(Timer(booster)); // پاس دادن دکمه
            }
        };
    }

    IEnumerator Timer(Button booster)
    {
        boosterIsOn = true;
        int i = 10;

        while (i > 0)
        {
            Debug.Log("Countdown: " + i);
            yield return new WaitForSeconds(1f);
            i--;
        }

        boosterIsOn = false;

        // رنگ رو بعد از تموم شدن تایمر سفید کن
        //booster.style.backgroundColor = new StyleColor(Color.white);
        booster.SetEnabled(true); // دوباره فعال کن اگر خواستی
    }
    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("QuestionWall"))
        {
            AudioManager.Instance.PlayPowerUpWall();
            //AnimationController.instance.PlayAnimation("Idle", true);
            //Time.timeScale = 0;
            GameManager.Instance.isWaiting = true;
            AsyncOperation loadOp = SceneManager.LoadSceneAsync(questionStart, LoadSceneMode.Additive);
            await WaitUntilDone(loadOp);
            GameManager.Instance.ActiveMainScene(false);
            GameManager.Instance.MainCamera(false);
            GameManager.Instance.wallpos = other.gameObject.transform;
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Reducer"))
        {
            AudioManager.Instance.PlayObstacleSound();
            DecreaseMoney(100);
        }
        else if (other.CompareTag("Increaser"))
        {
            AudioManager.Instance.PlayPowerUpWall();
            IncreaseMoney(40);  // افزایش پول
        }
        else if (other.CompareTag("Collectable"))
        {
            AudioManager.Instance.PlayCollectableSound();
            IncreaseMoney(boosterIsOn ? 2 * 20 : 20);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("GroupCollectable"))
        {
            AudioManager.Instance.PlayCollectableSound();
            IncreaseMoney(boosterIsOn ? 2 * 20 : 150);
            Destroy(other.gameObject);
        }
    }
    
    private async Task WaitUntilDone(AsyncOperation operation)
    {
        while (!operation.isDone)
            await Task.Yield();
    }
    private void ShowIndicator(int value, bool ispositive)
    {
        GameObject newIndicator = Instantiate(moneyIndicator, moneyIndicatorPos.transform.position, moneyIndicatorPos.transform.rotation * Quaternion.Euler(0, 90, 0));
        if (ispositive)
        {
            newIndicator.GetComponent<MoneyIndicatorValue>().impactValue.text = string.Format("+" + "{0:0}", value);
            newIndicator.GetComponent<MoneyIndicatorValue>().impactValue.color = Color.green;
        }
        else
        {
            newIndicator.GetComponent<MoneyIndicatorValue>().impactValue.text = string.Format("-" + "{0:0}", value);
            newIndicator.GetComponent<MoneyIndicatorValue>().impactValue.color = Color.red;
        }
        Vector3 originalScale = newIndicator.transform.localScale;
        newIndicator.transform.SetParent(moneyIndicatorPos.transform, true);
        newIndicator.transform.localScale = originalScale;
        StartCoroutine("DelayIndicatorDisable", newIndicator);
        indicator = newIndicator;
    }
    IEnumerator DelayIndicatorDisable(GameObject newIndicator)
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(newIndicator);
    }
    public void IncreaseMoney(int money, float percent = 0)
    {
        tempMoney = 0;
        tempMoney = percent > 0 ? Mathf.RoundToInt((playerMoney + money) * percent) : money;
        playerMoney += tempMoney;
        moneyLabel.text = playerMoney.ToString();
        ShowIndicator(tempMoney, true);
        PlayerPrefs.SetInt("money", playerMoney);
    }


    public void DecreaseMoney(int money, float percent = 0)
    {
        tempMoney = 0;
        if ((playerMoney - money) > 0)
        {
            tempMoney = percent > 0 ? Mathf.RoundToInt((playerMoney - money) * percent) : money;
            playerMoney -= tempMoney;
            ShowIndicator(tempMoney, false);
        }
        else
        {
            playerMoney = 0;
        }
        moneyLabel.text = playerMoney.ToString();
        PlayerPrefs.SetInt("money", playerMoney);
    }

    public int GetMoney()
    {
        return int.Parse(moneyLabel.text);
    }
    private void OnDisable()
    {
        Destroy(indicator);
    }
}
