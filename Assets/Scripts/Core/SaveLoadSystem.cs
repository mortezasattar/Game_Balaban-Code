using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public static SaveLoadSystem instance;

    private void Awake()
    {
        instance = instance != null ? instance: this;
        DontDestroyOnLoad(gameObject);
    }
    public void SaveGoals(PurchasedGoal goals)
    {
        string json = JsonUtility.ToJson(goals);
        PlayerPrefs.SetString($"FinTeen_Goals", json);
        PlayerPrefs.Save();
    }

    public PurchasedGoal LoadGoals()
    {
        string key = $"FinTeen_Goals";

        if (!PlayerPrefs.HasKey(key))
        {
            return new PurchasedGoal(); // اولین بار هنوز چیزی ذخیره نشده
        }

        string json = PlayerPrefs.GetString(key);
        return JsonUtility.FromJson<PurchasedGoal>(json);
    }

}

[System.Serializable]
public class PurchasedGoal
{
    public List<int> goalID = new List<int>();
}
