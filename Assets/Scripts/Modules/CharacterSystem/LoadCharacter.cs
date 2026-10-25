using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] private Transform spawnCharacter;
    [SerializeField] private Transform parent;
    [SerializeField] private int yDegree;


    private GameObject currentCharacter;
    // Start is called before the first frame update
    void Start()
    {
        if (currentCharacter != null) { return; }
        else
        {
            SpawnCharacter();
        }
    }

    void OnEnable()
    {
        if (AnimationController.instance.animator == null && currentCharacter != null)
        {
            Animator animator = currentCharacter.transform.GetChild(0).GetComponent<Animator>();
            AnimationController.instance.animator = animator;
        }
        else
        {
            SpawnCharacter(); // احتیاطی در صورتی که null باشه
        }
    }

    private void SpawnCharacter()
    {
        currentCharacter = Instantiate(Resources.Load<GameObject>("Character/character_" + PlayerPrefs.GetInt("SelectedCharacter", 0)), spawnCharacter.position, Quaternion.Euler(0, yDegree, 0));
        currentCharacter.transform.SetParent(parent);
        AnimationController.instance.animator =  currentCharacter.transform.GetChild(0).gameObject.GetComponent<Animator>();
        currentCharacter.transform.localScale = Vector3.one;
    }
}
