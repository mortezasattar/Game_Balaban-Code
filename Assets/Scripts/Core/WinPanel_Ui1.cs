using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WinPanel_Ui1 : MonoBehaviour
{
    private UIDocument uiDocument;
    private Label moneyLabel;
    private Label starLabel;
    VisualElement root;
    // Start is called before the first frame update
    void OnEnable()
    {
        
        uiDocument = GameObject.FindFirstObjectByType<UIDocument>();
        root = uiDocument.rootVisualElement;
        moneyLabel = root.Q<Label>("Money");
        if (moneyLabel != null)
        {
            moneyLabel.text = PlayerPrefs.GetInt("money", 0).ToString();
        }
        ShowStars();
    }
    private void ShowStars()
    {

        starLabel = root.Q<Label>("stars_label");

        if (starLabel != null)
        {
            starLabel.text = PlayerPrefs.GetInt("Stars", 0).ToString();
        }
    }

}
