using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionItem : MonoBehaviour
{
    [SerializeField] private Button answer;
    [SerializeField] private TMP_Text questionText;
    public int answeredIndex;
    public QuestionManager questionManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateUI(string text)
    {
        questionText.text = text;
    }

    public void checkAnswerUI(bool isCorrect = false)
    {
        if (!isCorrect)
            answer.image.color = Color.red;
        else
            answer.image.color = Color.green;
    }

    public void ResetQuestionItem()
    {
        answer.image.color = Color.white;
    }
    public void OnAnswerButton(int answerIndex)
    {
        //answeredIndex = answerIndex;
        //bool isCorrect = questionManager.CheckAnswer(answeredIndex);
        //checkAnswerUI(isCorrect);
    }
}
