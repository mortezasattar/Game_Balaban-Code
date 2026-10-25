using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UpgradeHouse : MonoBehaviour
{
    [SerializeField] List<GameObject> house;

    
    private UIDocument uiDocument;
    private VisualElement root;
    private Button updateHouse;
    int houseIndex = -1;


    private void Start()
    {
       
        uiDocument = GetComponent<UIDocument>();
        // دریافت ریشه UI
        root = uiDocument.rootVisualElement;
        updateHouse = root.Q<Button>("update");
        updateHouse.clicked += () => OnHouseUpdate();
        updateHouse.visible = false;
        if (PlayerPrefs.GetInt("House", 0) > 0)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("House", 0); i++)
            {
                house[i].gameObject.SetActive(false);
            }
        }
           
        house[PlayerPrefs.GetInt("House", 0)].gameObject.SetActive(true);
        checkLevel(PlayerPrefs.GetInt("LevelIndex", 1));
    }
    
    private void checkLevel(int level)
    {
        if(house.Count > 0)
        {
            houseIndex = Mathf.Clamp(level / 20, 0, house.Count - 1);
            if (houseIndex > 0)
            {
                updateHouse.visible = true;
            }
        }
    }

    private void OnHouseUpdate()
    {
        if(houseIndex > 0)
            house[houseIndex - 1].gameObject.SetActive(false);
        house[houseIndex].gameObject.SetActive(true);
        updateHouse.visible = false;
        PlayerPrefs.SetInt("House", houseIndex);
    }

}
