using UnityEngine;
using System;

public class Replacer : MonoBehaviour
{
    public void ReplaceTaggedObjects(string tag, GameObject[] replacementPrefabs, Action<GameObject> onReplaced = null)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        int queue = 0;
        foreach (GameObject oldObj in taggedObjects)
        {
            Vector3 pos = oldObj.transform.position;
            Quaternion rot = oldObj.transform.rotation;
            Transform parent = oldObj.transform.parent;
            Destroy(oldObj);
            Debug.Log("Destroying: " + oldObj.name);
            if (replacementPrefabs.Length == 0)continue;
            GameObject newObj = Instantiate(replacementPrefabs[queue % replacementPrefabs.Length],pos,rot);
            newObj.transform.parent = parent;
            newObj.tag = tag;
            // اعمال اکشن دلخواه
            onReplaced?.Invoke(newObj);
            queue++;
        }
    }
}