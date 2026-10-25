using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    //[SerializeField] Level[] levels;
    //[Header("Road")]
    //[SerializeField] Transform pathStart;  
    //[SerializeField] Transform pathEnd;
    //[SerializeField] Material roadMeterial;
    //[SerializeField] float obstacleSpacing = 5f;
    //[SerializeField] Transform goalPosition;
    //[SerializeField] float zRange = 1f;  // بازه تغییرات تصادفی محور Z
    //[SerializeField] float endBufferDistance = 5f;


    //private Level currentLevel;
    //private List<Vector3> obstaclePositions = new List<Vector3>();  // لیستی از موقعیت‌های موانع قرار داده‌شده
    //private int levelSeed = -1;  // ذخیره Seed تصادفی
    //void Start()
    //{
    //    LoadLevel(0);  
    //}

    //void LoadLevel(int index)
    //{
    //    if (index >= 0 && index < levels.Length)
    //    {
    //        currentLevel = levels[index];
    //        ApplyLevelSettings();
    //    }
    //}

    //void ApplyLevelSettings()
    //{
    //    // تنظیم رنگ جاده و دوربین
    //    if (roadMeterial != null)
    //        roadMeterial.color = currentLevel.roadColor;

    //    if (Camera.main != null)
    //        Camera.main.backgroundColor = currentLevel.cameraColor;

    //    // تنظیم هدف بازی
    //    if (currentLevel.goal != null && goalPosition != null)
    //        Instantiate(currentLevel.goal, goalPosition.position, Quaternion.Euler(0, 0, 90));

    //    // تنظیم Seed برای تولید تصادفی ثابت
    //    if (levelSeed == -1)
    //        levelSeed = Random.Range(0, int.MaxValue);

    //    Random.InitState(levelSeed);

    //    // لیست موقعیت‌های موانع
    //    obstaclePositions.Clear();

    //    float pathLength = Vector3.Distance(pathStart.position, pathEnd.position);
    //    int maxObstacles = Mathf.FloorToInt(pathLength / obstacleSpacing);

    //    // استفاده از Perlin Noise برای تغییرات طبیعی
    //    List<Vector3> availablePositions = new List<Vector3>();
    //    for (int i = 0; i < maxObstacles; i++)
    //    {
    //        // استفاده از Perlin Noise برای پخش موانع به‌صورت تصادفی
    //        float t = Mathf.Pow(i / (float)maxObstacles, 1.2f);
    //        Vector3 pos = GetPositionAtT(t);
    //        pos.z += Mathf.PerlinNoise(t, 0) * zRange * 2f - zRange;  // تغییرات طبیعی در محور Z

    //        if (Vector3.Distance(pos, pathEnd.position) > endBufferDistance)
    //        {
    //            availablePositions.Add(pos);
    //        }
    //    }

    //    // **دیوار سوال در ابتدای مسیر**
    //    Vector3 wallPos = GetPositionAtT(Random.Range(0.1f, 0.2f));
    //    if (currentLevel.wallQuestion != null)
    //    {
    //        Instantiate(currentLevel.wallQuestion, wallPos, Quaternion.identity);
    //        availablePositions.Remove(wallPos);
    //    }

    //    // **چیدن موانع افزایشی و کاهشی به صورت تصادفی و طبیعی**
    //    foreach (ObstacleItem obstacleItem in currentLevel.obstacleItemsIncreasing)
    //    {
    //        for (int i = 0; i < obstacleItem.obstacleCount && availablePositions.Count > 0; i++)
    //        {
    //            // انتخاب تصادفی یک موقعیت
    //            int randIndex = Random.Range(0, availablePositions.Count);
    //            Vector3 obstaclePos = availablePositions[randIndex];
    //            availablePositions.RemoveAt(randIndex);

    //            // چرخش تصادفی مانع
    //            //float randomRotation = Random.Range(0f, 360f);

    //            // ایجاد مانع افزایشی
    //            Instantiate(obstacleItem.obstacle, obstaclePos, Quaternion.identity);
    //            obstaclePositions.Add(obstaclePos);
    //        }
    //    }

    //    foreach (ObstacleItem obstacleItem in currentLevel.obstacleItemsDecreasing)
    //    {
    //        for (int i = 0; i < obstacleItem.obstacleCount && availablePositions.Count > 0; i++)
    //        {
    //            // انتخاب تصادفی یک موقعیت
    //            int randIndex = Random.Range(0, availablePositions.Count);
    //            Vector3 obstaclePos = availablePositions[randIndex];
    //            availablePositions.RemoveAt(randIndex);

    //            // چرخش تصادفی مانع
    //            //float randomRotation = Random.Range(0f, 360f);

    //            // ایجاد مانع کاهشی
    //            Instantiate(obstacleItem.obstacle, obstaclePos, Quaternion.identity);
    //            obstaclePositions.Add(obstaclePos);
    //        }
    //    }
    //}

    ////Vector3 GetRandomPositionAlongPath()
    ////{
    ////    float t = Random.Range(0f, 1f);  // مقدار تصادفی بین 0 و 1
    ////    Vector3 position = GetPositionAtT(t);  // محاسبه موقعیت بر اساس t

    ////    // محدود کردن مقدار تغییرات تصادفی محور Z
    ////    float minZ = Mathf.Min(pathStart.position.z, pathEnd.position.z);
    ////    float maxZ = Mathf.Max(pathStart.position.z, pathEnd.position.z);

    ////    // تغییرات تصادفی در محور Z در بازه معتبر
    ////    position.z = Random.Range(minZ, maxZ);

    ////    return position;  // بازگشت موقعیت تصادفی
    ////}
    //Vector3 GetPositionAtT(float t)
    //{
    //    // محاسبه موقعیت بر اساس t در راستای مسیر (در محورهای X و Z)
    //    float x = Mathf.Lerp(pathStart.position.x, pathEnd.position.x, t);
    //    float z = Mathf.Lerp(pathStart.position.z, pathEnd.position.z, t);

    //    // در اینجا محور Y را ثابت می‌گذاریم (مثلاً Y = 0)
    //    Vector3 position = new Vector3(x, 0.8f, z);

    //    return position;
    //}

    ////bool IsPositionTooClose(Vector3 position)
    ////{
    ////    foreach (Vector3 obstaclePos in obstaclePositions)
    ////    {
    ////        if (Vector3.Distance(obstaclePos, position) < obstacleSpacing)
    ////        {
    ////            return true;  // اگر فاصله کمتر از حد مجاز باشد، موقعیت نزدیک است
    ////        }
    ////    }
    ////    return false;  // موقعیت به هیچ مانعی نزدیک نیست
    ////}

    //public void RestartLevel()
    //{
    //    foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Obstacle"))
    //        Destroy(obj);
    //    foreach (GameObject obj in GameObject.FindGameObjectsWithTag("WallQuestion"))
    //        Destroy(obj);

    //    ApplyLevelSettings();
    //}

    public static LevelManager Instance; 
    public Level[] levelItem; 
    public Transform levelSpawnPoint;
    [SerializeField] Transform goalPosition;
    [SerializeField] Transform parent;
    [HideInInspector] public Level currentLevel;


    private GameObject currentLevelInstance;
    private GameObject currentGoal;
    private int currentLevelIndex = 0;
    private UIDocument uiDocument;
    private Label goalPrice;
    private Label levelIndex;
    private RenderTexture goalTexture;
    VisualElement root;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
            Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

        SetUI();
        LoadLevel(PlayerPrefs.GetInt("LevelIndex", 0));
    }

    private void SetUI()
    {
        uiDocument = GameObject.FindFirstObjectByType<UIDocument>();
        // دریافت ریشه UI
        root = uiDocument.rootVisualElement;
        // پیدا کردن دکمه
        goalPrice = root.Q<Label>("GoalPrice");

        levelIndex = root.Q<Label>("level_index");
        if(levelIndex != null)
        {
            levelIndex.text = "Level " +(PlayerPrefs.GetInt("LevelIndex", 0) + 1).ToString();
        }
        if (goalPrice != null)
            goalPrice.text = PlayerPrefs.GetInt("GoalPrice", 0).ToString();
       
    }
    private void OnEnable()
    {

        SetUI();
    }
    public void LoadLevel(int index)
    {
        if (index < 0 || index >= levelItem.Length)
        {
            PlayerPrefs.SetInt("LevelIndex", 0);
            PlayerPrefs.SetInt("money", 0);
            PlayerPrefs.SetInt("GoalPrice", 0);
            PlayerPrefs.Save(); 
            SceneManager.LoadSceneAsync("01-main_menu");
        }

        if (currentLevelInstance != null)
            Destroy(currentLevelInstance);

        
        currentLevelIndex = index;
        currentLevel = levelItem[index];
        currentLevelInstance = Instantiate(levelItem[index].levelPref, levelSpawnPoint.position, Quaternion.identity);
        currentLevelInstance.transform.SetParent(parent);
        if(goalPrice != null)
            goalPrice.text = currentLevel.goalPrice.ToString();
        SetGoalPosition();
       
    }


    private void SetGoalPosition()
    {
        //if (currentGoal != null)
        //    DestroyObjeDect(currentGoal);
        //currentGoal = Instantiate(currentLevel.goal, goalPosition.position, Quaternion.Euler(0, 0, 0));
        //currentGoal.transform.SetParent(parent);
        PlayerPrefs.SetInt("GoalPrice", currentLevel.goalPrice);
        if(currentLevelIndex + 1 <= levelItem.Length - 1)
            PlayerPrefs.SetInt("NextGoalPrice", levelItem[currentLevelIndex + 1].goalPrice);

    }
    //public void RestartLevel()
    //{
    //    if (currentLevelInstance != null)
    //        Destroy(currentLevelInstance);
    //    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    currentLevelInstance = Instantiate(levelItem[currentLevelIndex].levelPref, levelSpawnPoint.position, Quaternion.identity);
    //    currentLevelInstance.transform.SetParent(parent);
    //    goalPrice.text = currentLevel.goalPrice.ToString();
    //    SetGoalPosition();
    //    PlayerPrefs.SetInt("LevelIndex", currentLevelIndex);
    //    //AudioManager.Instance.StopPlay();
    //}


    //public void LoadNextLevel()
    //{
    //    int nextLevel = (currentLevelIndex + 1) % levelItem.Length;
    //    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    LoadLevel(nextLevel);
    //}

    private void OnApplicationQuit()
    {
        
    }
}
