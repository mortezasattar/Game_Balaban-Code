using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public ObstacleHit playerMoney; 
    [SerializeField] public GameObject mainRoot;
    [SerializeField] public Transform camera;
    [SerializeField] GameObject explodeWallQuestion;
    [SerializeField] GameObject secondWallQuestion;
    [SerializeField] private Button taptoPlay;

    private Vector3 initialPlayerPosition;
    private Vector3 initialCameraPosition;
    private string winScene = "11-question_succeds";
    private string loseScene = "12-question_fails";

    [HideInInspector]
    public bool isEnd;
    [HideInInspector]
    public bool isWaiting;
    [HideInInspector]
    public Transform wallpos;
   

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
        secondWallQuestion.SetActive(false);
        isEnd = false;
        isWaiting = false;
    }

    private void Start()
    {
        if (playerMoney != null)
        {
            initialPlayerPosition = playerMoney.gameObject.transform.position;
        }

        
        if (camera != null)
        {
            initialCameraPosition = camera.position;
        }


        taptoPlay.onClick.AddListener(() => StartGame());
    }


    private void StartGame()
    {
        isWaiting = false;
    }
    public void ResetPositions()
    {
       
        if (playerMoney != null)
        {
            playerMoney.gameObject.transform.position = initialPlayerPosition;
        }

        
        if (camera != null)
        {
            camera.position = initialCameraPosition;
        }
    }
    //private void ResetData()
    //{
    //    isEnd = false;
    //    ResetPositions();
    //    AnimationController.instance.ResetAnimator();
    //}
    public void CheckWinCondition()
    {
        isEnd = true; 
        if (playerMoney.GetMoney() >= LevelManager.Instance.currentLevel.goalPrice)
        {
            StartCoroutine(Win());
            
        }
        else
        {
            StartCoroutine(Lose());
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(winScene);
        mainRoot.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        isEnd = false;
    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(loseScene);
        mainRoot.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        isEnd = false;
    }

    //public void RestartGame()
    //{
    //    ResetData();
    //    LevelManager.Instance.RestartLevel();
    //    Time.timeScale = 1;
        
    //}
    //public void NextLevel()
    //{
    //    ResetData();
    //    LevelManager.Instance.LoadNextLevel();
    //    Time.timeScale = 1;
    //    isEnd = false;
    //}
    public void ActiveWall(bool correctAnswer)
    {
        if (correctAnswer)
            secondWallQuestion.SetActive(true);
    }

    public void ActiveMainScene(bool isActive)
    {
        mainRoot.SetActive(isActive);
    }

    public void ExplodeWallQuestion()
    {
        AudioManager.Instance.PlayWallExplosion();
        GameObject explosion = Instantiate(explodeWallQuestion,wallpos.position,Quaternion.Euler(0,90,0));
        explosion.transform.SetParent(mainRoot.transform);
    }

    public void MainCamera(bool isActive)
    {
        camera.gameObject.SetActive(isActive);
    }

    public void ChangePlayerMoney()
    {
        playerMoney.DecreaseMoney(LevelManager.Instance.currentLevel.goalPrice);
    }
}
