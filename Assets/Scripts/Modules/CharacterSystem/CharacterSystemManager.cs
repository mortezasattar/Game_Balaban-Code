using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class CharacterSystemManager : MonoBehaviour
{
    [SerializeField] private List<CharacterData> allCharacters;
    [SerializeField] private Transform characterSpawnPoint;
    [SerializeField] private int selectedCharacterIndex = 0;
    [SerializeField] private GameObject lockedItem;

    private GameObject currentCharacter;
    private int currentIndex = 0;
    private UIDocument uiDocument;
    private Label characterNameText;
    private string unlockCharacter = "15-unlock_item";

    void Start()
    {
        LoadUnlockedCharacters();
        LoadSelectedCharacter();
        uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        root.Q<Button>("Right").clicked += NextCharacter;
        root.Q<Button>("left").clicked += PreviousCharacter;
        root.Q<Button>("select_character").clicked += SelectCharacter;
        root.Q<Button>("close").clicked += () =>
        {
            SceneManager.LoadScene(0);
        };
        characterNameText = root.Q<Label>("name");
    }

    public void NextCharacter()
    {
        int nextIndex = (currentIndex + 1) % allCharacters.Count;
        AnimateCharacterOut(Vector3.left * 4f, () => SpawnCharacter(currentIndex));
        currentIndex = nextIndex;
        
    }
    public void PreviousCharacter()
    {
        int nextIndex = (currentIndex - 1 + allCharacters.Count) % allCharacters.Count;
        AnimateCharacterOut(Vector3.right * 4f, () => SpawnCharacter(currentIndex));
        currentIndex = nextIndex;
    }

    void AnimateCharacterOut(Vector3 direction, Action onComplete)
    {
        if (currentCharacter != null)
        {
            currentCharacter.transform.DOMove(characterSpawnPoint.position + direction, 0.4f).OnComplete(() => {
                Destroy(currentCharacter);
                onComplete?.Invoke();
            });
        }
        else
        {
            onComplete?.Invoke();
        }
    }
    void LoadUnlockedCharacters()
    {
        foreach (var character in allCharacters)
        {
            
            if (PlayerPrefs.GetInt("LevelIndex", 1) >= character.unlockLevel)
                character.isUnlocked = true;
        }
    }

    public async void SelectCharacter()
    {
        if (!allCharacters[currentIndex].isUnlocked) return;

        selectedCharacterIndex = currentIndex;
        PlayerPrefs.SetInt("SelectedCharacter", currentIndex);
        SceneManager.UnloadSceneAsync("14-select_character");
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(unlockCharacter);
        await WaitUntilDone(loadOp);
        //SpawnCharacter(index);
    }

    private async Task WaitUntilDone(AsyncOperation operation)
    {
        while (!operation.isDone)
            await Task.Yield();
    }
    void LoadSelectedCharacter()
    {
        int index = PlayerPrefs.GetInt("SelectedCharacter", 0);
        selectedCharacterIndex = index;
        SpawnCharacter(index);
    }

    void SpawnCharacter(int index)
    {
        currentCharacter = Instantiate(allCharacters[index].prefab, characterSpawnPoint.position, Quaternion.Euler(0, 180, 0));

        // حفظ مقیاس اصلی
        currentCharacter.transform.localScale = Vector3.one;
        if(characterNameText != null)
            characterNameText.text = allCharacters[index].characterName;
        if (allCharacters[index].isUnlocked)
            lockedItem.SetActive(false);
        else
            lockedItem.SetActive(true);

    }

   
}
