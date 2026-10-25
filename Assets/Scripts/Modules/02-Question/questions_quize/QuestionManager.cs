using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;
    public QuestionBank questionBank; // لیست سوالات
    public string currentLanguage = "en"; // زبان پیش‌فرض    
    [HideInInspector]public Question currentQuestion;
    public TMP_Text questionTxt;
    public List<Button> answerButtons;
    public Button closeBtn;


    private List<Question> availableQuestions;
    
    
    private int stars = 0;

    private string questionStart = "09-questions_start";
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
            Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        availableQuestions = new List<Question>(questionBank.questions);
        GetQuestion();
        stars = PlayerPrefs.GetInt("Stars", 0);
    }

    public void GetQuestion()
    {
       
        if (availableQuestions.Count == 0)
        {
            Debug.Log("همه سوالات استفاده شدند!");
            return;
        }

        int index = LevelManager.Instance.currentLevel.questionIndex;
        currentQuestion = availableQuestions[index];
        DisplayQuestion();
        gameObject.SetActive(true);
    }

    private void DisplayQuestion()
    {
     
        questionTxt.text = currentQuestion.questionText;

        closeBtn.onClick.RemoveAllListeners();
        closeBtn.onClick.AddListener(ClosePanel);
        closeBtn.interactable = false;

        int correctIndex = currentQuestion.correctAnswerIndex;

        for (int i = 0; i < answerButtons.Count; i++)
        {
            int index = i;
            Button btn = answerButtons[i];

            btn.onClick.RemoveAllListeners();
            btn.interactable = true;

            // متن گزینه
            TMP_Text btnText = btn.GetComponentInChildren<TMP_Text>();
            if (btnText != null)
                btnText.text = currentQuestion.options[i];

            // ریست رنگ دکمه
            ColorBlock colors = btn.colors;
            colors.normalColor = Color.white;
            colors.selectedColor = Color.white;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white;
            btn.colors = colors;

            btn.image.color = Color.white;

            btn.onClick.AddListener(() =>
            {
                closeBtn.interactable = true;

                foreach (var b in answerButtons)
                    b.interactable = false;

                // اول گزینه صحیح سبز شود
                answerButtons[correctIndex].image.color = Color.green;

                if (index == correctIndex)
                {
                    btn.image.color = Color.green;
                    stars += 3;
                }
                else
                {
                    btn.image.color = Color.red;
                    stars += 2;
                    GameManager.Instance.ActiveWall(true);
                }
            });
        }
    }

    private void ClosePanel()
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("Stars", stars);
        GameManager.Instance.isWaiting = false;
    }


    private async Task WaitUntilDone(AsyncOperation operation)
    {
        while (!operation.isDone)
            await Task.Yield();
    }
    //public async void ClosePanel()
    //{
    //    AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(questionStart);
    //    await WaitUntilDone(unloadOp);
    //    //Time.timeScale = 1;
      
    //    GameManager.Instance.ActiveMainScene(true);
    //    GameManager.Instance.MainCamera(true);
       
    //    GameManager.Instance.ExplodeWallQuestion();
    //}

    public void SetLanguage(string languageCode)
    {
        currentLanguage = languageCode;
        DisplayQuestion();
    }

}