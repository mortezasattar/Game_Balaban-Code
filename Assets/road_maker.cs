
using UnityEngine;
using System.Collections.Generic;
using System;

public class road_maker : MonoBehaviour
{[Space(20)]
    [Header("Gameplay")]
    public int length = 50;
    public int questions=1;
    public int moneys =1500;
    public int powerups =3;
    public int powerdowns =5;
    [Space(20)]
[Header("visuals")]
public GameObject Camera_character;
public GameObject[] backgroundElements;
    public GameObject[] roads;
    public GameObject[] decreaser;
    public GameObject[] increaser;
    public GameObject powerup, powerdown;
    public List<Color> wallColors;
    public Replacer replacer;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPosition = transform.position;
        SpawnRandomRoads(length, roads, startPosition);
        
        replacer.ReplaceTaggedObjects("Background Elements",backgroundElements);
    }

    void SpawnRandomRoads(int count, GameObject[] roads, Vector3 startPosition)
    {
        void ChangeMaterialsColor(GameObject targetObject, Color newColor)
        {
            Renderer[] renderers = targetObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                foreach (Material mat in renderer.materials)
                {
                    mat.color = newColor;
                    mat.SetColor("_EmissionColor", newColor);
                }
            }
        }

        // List<GameObject> FindChildrenByName(GameObject parentObject, string targetName)
        // {
        //     List<GameObject> resultList = new List<GameObject>();
        //     Transform[] children = parentObject.GetComponentsInChildren<Transform>(true);

        //     foreach (Transform child in children)
        //     {
        //         if (child.name == targetName)
        //         {
        //             resultList.Add(child.gameObject);
        //         }
        //     }

        //     return resultList;
        // }
        
        List<GameObject> FindChildrenByTag(GameObject parentObject, string targetTag)
        {
            List<GameObject> resultList = new List<GameObject>();
            Transform[] children = parentObject.GetComponentsInChildren<Transform>(true);

            foreach (Transform child in children)
            {
                if (child.CompareTag(targetTag))
                {
                    resultList.Add(child.gameObject);
                }
            }

            return resultList;
        }

        Transform startPoint = null;
        Transform endPoint = null;
        float space = 0f;
        int queue = 0;
       Camera_character.transform.position =transform.position;
        for (int i = 0; i < count; i++)
        {
            
            if (roads.Length == 0) return;

            int randomIndex = UnityEngine.Random.Range(0, roads.Length);
            Vector3 spawnPosition = new Vector3(space, 0f, 0f);

            GameObject spawned = Instantiate(roads[randomIndex], spawnPosition, Quaternion.identity);
            Transform[] children = spawned.GetComponentsInChildren<Transform>();
            List<GameObject> barriers = FindChildrenByTag(spawned, "Barrier Wall");
            
            

            for (int b = 0; b < barriers.Count; b++) 
            {
                queue++;
                ChangeMaterialsColor(barriers[b], wallColors[queue % wallColors.Count]);
            }


            startPoint = null;
            endPoint = null;

            foreach (Transform t in children)
            {
                if (t.CompareTag("Road Start Point")) startPoint = t;
                if (t.CompareTag("Road End Point")) endPoint = t;
            }

            if (startPoint != null && endPoint != null)
            {
                // if (i == 0)
                // {
                //     space -= Mathf.Abs(endPoint.position.x - startPoint.position.x) / 2;
                // }
                space += Mathf.Abs(endPoint.position.x - startPoint.position.x);

            }
            else
            {
                Debug.LogWarning("StartPoint یا EndPoint پیدا نشد!");
            }
        }

 GameObject[] powerupWalls = GameObject.FindGameObjectsWithTag("Powerup Wall");
        int countWalls = powerupWalls.Length;

        int upCount = powerups;
        int downCount = powerdowns;
        int allCount = upCount + downCount;

        int interval = Mathf.FloorToInt((float)countWalls / allCount);
        int allWallsCount = allCount;

        for (int i = 0; i < countWalls; i++)
        {
            GameObject wall = powerupWalls[i];

            if (i % interval == 0 && allWallsCount > 0)
            { 
                GameObject newWall = null;

                if (upCount > 0 && i % 2 == 0)
                {
                    int randIndex = UnityEngine.Random.Range(0, decreaser.Length);
                    newWall = Instantiate(decreaser[randIndex]);
                    upCount--;
                    Debug.Log("upCount instanciated: " + upCount);
                }
                else if (downCount > 0 && i % 2 == 1)
                {
                    int randIndex = UnityEngine.Random.Range(0, increaser.Length);
                    newWall = Instantiate(increaser[randIndex]);
                    downCount--;
                    Debug.Log("upCount instanciated: " + upCount);
                }

                if (newWall != null)
                {
                    newWall.transform.position = wall.transform.position;
                    newWall.transform.rotation = wall.transform.rotation;
                    newWall.transform.parent = wall.transform.parent;
                    newWall.transform.localScale = wall.transform.localScale;
                }

                Destroy(wall);
                allWallsCount--;
            }
            else
            {
                Destroy(wall);
            }
        }
    }








    
}

