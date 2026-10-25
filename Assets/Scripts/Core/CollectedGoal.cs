using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CollectedGoal : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset goalItemTemplate;
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] Goal goals;


    
    private void OnEnable()
    {
        var root = uiDocument.rootVisualElement;

        ScrollView scrollView = root.Q<ScrollView>("scroll-goals");
       

        for (int i = 0; i < SaveLoadSystem.instance.LoadGoals().goalID.Count; i++)
        {
            VisualElement goalItem = goalItemTemplate.Instantiate();
            SetGoal(goalItem.Q<VisualElement>("Goal_Parent"), SaveLoadSystem.instance.LoadGoals().goalID[i]);
            scrollView.Add(goalItem);
        }
        root.Q<Button>("close").clicked += () =>
        {
            SceneManager.LoadScene("01-main_menu");
        };

        //test
        //for (int i = 0; i < 5; i++)
        //{
        //    VisualElement goalItem = goalItemTemplate.Instantiate();
        //    SetGoal(goalItem.Q<VisualElement>("goal_sprite"), i);
        //    scrollView.Add(goalItem);
        //}
    }
    private void SetGoal(VisualElement goalparent,int index)
    {
        Image img = new Image();
        img.image = Resources.Load<Texture2D>("goal"); // Put image in Resources folder
        goalparent.Add(img);
       
        if (index >= goals.sprites.Count)
        {
            index = 0;
            PlayerPrefs.SetInt("LevelIndex", 0);
        }
        img.sprite = goals.sprites[index];

    }
    //private Texture2D SpriteToTexture(Sprite sprite)
    //{
    //    Texture2D texture = sprite.texture;
    //    Rect rect = sprite.textureRect;

    //    // چک کردن محدودیت‌ها
    //    if (rect.x < 0 || rect.y < 0 || rect.x + rect.width > texture.width || rect.y + rect.height > texture.height)
    //    {
    //        Debug.LogError($"Sprite textureRect is out of bounds! Rect: {rect} Texture size: {texture.width}x{texture.height}");
    //        return null;
    //    }

    //    Texture2D newTexture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGBA32, false);

    //    Color[] pixels = texture.GetPixels(
    //        (int)rect.x,
    //        (int)rect.y,
    //        (int)rect.width,
    //        (int)rect.height);

    //    newTexture.SetPixels(pixels);
    //    newTexture.Apply();

    //    return newTexture;
    //}

}
