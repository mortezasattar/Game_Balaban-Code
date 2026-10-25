using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocalizedText
{
    public string en; // انگلیسی
    public string fa; // فارسی
    public string fr; // فرانسوی
    public string es; // اسپانیایی

    public string GetText(string languageCode)
    {
        switch (languageCode)
        {
            case "en": return en;
            case "fa": return fa;
            case "fr": return fr;
            case "es": return es;
            default: return en; // زبان پیش‌فرض
        }
    }
}