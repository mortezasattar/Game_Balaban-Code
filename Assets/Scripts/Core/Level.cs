using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public Color roadColor;
    public Color cameraColor;
    public GameObject levelPref;
    //public GameObject goal;
    public int goalPrice;
    public int questionIndex;
}

