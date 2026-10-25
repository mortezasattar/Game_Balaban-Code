using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;


public class LoadGoal : MonoBehaviour
{
    [SerializeField] Goal goals;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        SetGoal();
    }

    private void SetGoal()
    {
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;


        VisualElement parent = root.Q<VisualElement>("Goal_Parent");

        // Create and add the image
        Image img = new Image();
        img.image = Resources.Load<Texture2D>("goal"); // Put image in Resources folder
        parent.Add(img);
        int index = PlayerPrefs.GetInt("LevelIndex", 0);
        if (index >= goals.sprites.Count)
        {
            index = 0;
            PlayerPrefs.SetInt("LevelIndex", 0);
        }
        img.sprite = goals.sprites[index];

        //VisualElement goal = root.Q<VisualElement>("goal_01");
        
        //Sprite goalSprite = goals.sprites[index]; // از لیست Spriteها
        //Texture2D cropped = SpriteToTexture(goalSprite);
        //goal.style.backgroundImage = new StyleBackground(cropped);
        //goal.style.width = cropped.width;
        //goal.style.height = cropped.height;

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
