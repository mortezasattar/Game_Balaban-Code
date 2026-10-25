//using AptabaseSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;

    //private Label starLabel;
    //private Label level;
    //VisualElement root;
    void Start()
    {
        Time.timeScale = 1f;
        if(!PlayerPrefs.HasKey("money"))
            PlayerPrefs.SetInt("money", 100);
        PlayerPrefs.Save();
        
        playButton.onClick.AddListener(() => OnPlayClicked());
        
        //ShowMoney();
        //ShowLevel();
        //ShowStars();


        //root.Q<Button>("avatar").clicked += () =>
        //{
        //    SceneManager.LoadScene(4);
        //};
        //root.Q<Button>("Goals").clicked += () =>
        //{
        //    SceneManager.LoadScene(10);
        //};
        //root.Q<Button>("setting").clicked += () =>
        //{
        //    SceneManager.LoadScene(11);
        //};
    }

    //private void ShowMoney()
    //{

    //    moneyLabel = root.Q<Label>("Label");

    //    if (moneyLabel != null)
    //    {
    //        moneyLabel.text = PlayerPrefs.GetInt("money",0).ToString();
    //    }
        
    //}

    //private void ShowStars()
    //{

    //    starLabel = root.Q<Label>("stars_label");

    //    if (starLabel != null)
    //    {
    //        starLabel.text = PlayerPrefs.GetInt("Stars", 0).ToString();
    //    }
    //}
    //private void ShowLevel()
    //{
    //    level = root.Q<Label>("level");
       
    //    if (level != null)
    //    {
    //        level.text = "Level "+PlayerPrefs.GetInt("LevelIndex", 1).ToString();
    //    }
    //}
    private void OnPlayClicked()
    {
        SceneManager.LoadScene(1);
    }
}
