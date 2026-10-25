using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadNftCardGoal : MonoBehaviour
{
    [SerializeField] Goal goals;
    [SerializeField] SpriteRenderer goal;

    // Start is called before the first frame update
    void Start()
    {
        SetGoal();
    }

    private void SetGoal()
    {
        int index = PlayerPrefs.GetInt("LevelIndex", 0);
        if (index >= goals.sprites.Count)
        {
            index = 0;
            PlayerPrefs.SetInt("LevelIndex", 0);
        }
        goal.sprite = goals.sprites[index]; // از لیست Spriteها

    }

}
