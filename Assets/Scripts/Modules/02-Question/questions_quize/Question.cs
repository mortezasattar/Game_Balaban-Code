using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string questionText;   // متن سوال
    public string[] options;      // لیستی از گزینه‌ها (۲، ۴ یا ۶ گزینه)
    public int correctAnswerIndex; // اندیس گزینه صحیح (۰ تا n-1)
}
