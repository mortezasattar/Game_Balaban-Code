using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class LevelGenerator : EditorWindow
{
    public List<ObstacleDefinition> obstacles = new List<ObstacleDefinition>();
    private List<bool> foldouts = new List<bool>(); // برای باز و بسته بودن هر آیتم
    private Vector2 scrollPos;

    public int numberOfLevels = 100;
    public string savePath = "Assets/GeneratedLevels/";
    public float minDistanceBetweenObstacles = 2.0f;

    [MenuItem("Tools/Flexible Level Generator")]
    public static void ShowWindow()
    {
        GetWindow<LevelGenerator>("Flexible Level Generator");
    }

    private void OnGUI()
    {
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        numberOfLevels = EditorGUILayout.IntField("Number of Levels", numberOfLevels);
        savePath = EditorGUILayout.TextField("Save Path", savePath);
        minDistanceBetweenObstacles = EditorGUILayout.FloatField("Min Distance Between Obstacles", minDistanceBetweenObstacles);

        EditorGUILayout.Space();
        if (GUILayout.Button("Add Obstacle Type"))
        {
            obstacles.Add(new ObstacleDefinition());
            foldouts.Add(true); // حالت پیش‌فرض باز
        }

        for (int i = 0; i < obstacles.Count; i++)
        {
            EditorGUILayout.BeginVertical("box");

            foldouts[i] = EditorGUILayout.Foldout(foldouts[i], $"Obstacle {i + 1}", true);
            if (foldouts[i])
            {
                obstacles[i].prefab = (GameObject)EditorGUILayout.ObjectField("Obstacle Prefab", obstacles[i].prefab, typeof(GameObject), false);
                obstacles[i].count = EditorGUILayout.IntField("Max Count", obstacles[i].count);
                obstacles[i].minPosition = EditorGUILayout.Vector3Field("Min Position", obstacles[i].minPosition);
                obstacles[i].maxPosition = EditorGUILayout.Vector3Field("Max Position", obstacles[i].maxPosition);
                obstacles[i].required = EditorGUILayout.Toggle("Required", obstacles[i].required);
                if (!obstacles[i].required)
                    obstacles[i].spawnChance = EditorGUILayout.Slider("Spawn Chance", obstacles[i].spawnChance, 0f, 1f);
                EditorGUILayout.Space();
                if (GUILayout.Button("Remove"))
                {
                    obstacles.RemoveAt(i);
                    foldouts.RemoveAt(i);
                    i--; // اصلاح index
                    continue;
                }
            }

            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.Space();
        if (GUILayout.Button("Generate Levels"))
        {
            GenerateLevels();
        }

        EditorGUILayout.EndScrollView();
    }

    private void GenerateLevels()
    {
        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        for (int i = 1; i <= numberOfLevels; i++)
        {
            GameObject levelRoot = new GameObject($"Level_{i:D3}");
            List<Vector3> usedPositions = new List<Vector3>();

            foreach (var def in obstacles)
            {
                int toGenerate = 0;

                if (def.required)
                {
                    toGenerate = def.count;
                }
                else
                {
                    if (Random.value <= def.spawnChance)
                        toGenerate = Random.Range(1, def.count + 1);
                }

                for (int j = 0; j < toGenerate; j++)
                {
                    Vector3 pos;
                    int tryCount = 0;
                    int maxTries = 100;

                    do
                    {
                        pos = new Vector3(
                            Random.Range(def.minPosition.x, def.maxPosition.x),
                            Random.Range(def.minPosition.y, def.maxPosition.y),
                            Random.Range(def.minPosition.z, def.maxPosition.z)
                        );
                        tryCount++;
                    } while (IsTooClose(pos, usedPositions) && tryCount < maxTries);

                    if (tryCount >= maxTries)
                    {
                        Debug.LogWarning($"Position conflict for {def.prefab?.name} in Level {i}");
                        continue;
                    }

                    GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(def.prefab);
                    obj.transform.SetParent(levelRoot.transform);
                    obj.transform.localPosition = pos;
                    usedPositions.Add(pos);
                }
            }

            string levelName = $"Level_{i:D3}";
            string prefabPath = Path.Combine(savePath, levelName + ".prefab");
            PrefabUtility.SaveAsPrefabAsset(levelRoot, prefabPath);
            DestroyImmediate(levelRoot);
        }

        AssetDatabase.Refresh();
        Debug.Log($"{numberOfLevels} dynamic levels generated at {savePath}");
    }

    private bool IsTooClose(Vector3 newPos, List<Vector3> existing)
    {
        foreach (var pos in existing)
        {
            if (Vector3.Distance(pos, newPos) < minDistanceBetweenObstacles)
                return true;
        }
        return false;
    }
}

[System.Serializable]
public class ObstacleDefinition
{
    public GameObject prefab;
    public int count;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public bool required = false;
    public float spawnChance = 1.0f;
}
