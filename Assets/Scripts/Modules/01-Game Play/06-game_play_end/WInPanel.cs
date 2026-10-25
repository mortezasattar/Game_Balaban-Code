using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class WInPanel : MonoBehaviour
{
    private UIDocument uiDocument;
    private string safeboxScene = "16-safebox";
    private string thisScene = "11-question_succeds";
    private string collectGoalScene = "17-collect_nft_card";
    private Label moneyLabel;
    private int tempMoney;
    private int level;

    // Start is called before the first frame update
    void OnEnable()
    {
        VisualElement root;
        uiDocument = GameObject.FindFirstObjectByType<UIDocument>();
        root = uiDocument.rootVisualElement;
        root.Q<Button>("trade_sell").clicked += PurchaseGoal;
        root.Q<Button>("trade_save").clicked += SaveMoney;

        moneyLabel = root.Q<Label>("Money");
        if (moneyLabel != null)
        {
            moneyLabel.text = PlayerPrefs.GetInt("money", 0).ToString();
        }
      
    }

    public void SaveMoney()
    {
        level = PlayerPrefs.GetInt("LevelIndex", 0);
        PlayerPrefs.SetInt("LevelIndex", level + 1);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(safeboxScene);
      

    }
    public async void PurchaseGoal()
    {
        level = PlayerPrefs.GetInt("LevelIndex", 0);
        PlayerPrefs.Save();
        DecreasePlayerMoney();
        SaveGoal(level);
        await Task.Delay(500);
        SceneManager.LoadSceneAsync(collectGoalScene);
        
    }

    private void SaveGoal(int goalID)
    {
        PurchasedGoal goals = SaveLoadSystem.instance.LoadGoals();       
        if (goals.goalID == null)
        {
            goals = new PurchasedGoal();
          
        }
        goals.goalID.Add(goalID);
        SaveLoadSystem.instance.SaveGoals(goals);
    }

    private void DecreasePlayerMoney()
    {
        tempMoney = PlayerPrefs.GetInt("money", 0) - PlayerPrefs.GetInt("GoalPrice", 0);
        if (tempMoney > 0)
        {
            if (moneyLabel != null)
            {
                moneyLabel.text = tempMoney.ToString();
            }
            PlayerPrefs.SetInt("money", tempMoney);
        }
    }
    private async Task WaitUntilDone(AsyncOperation operation)
    {
        while (!operation.isDone)
            await Task.Yield();
    }

    
}
