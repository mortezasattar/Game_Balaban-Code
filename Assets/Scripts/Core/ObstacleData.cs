using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ObstacleData", menuName = "Game/Obstacle Data")]
public class ObstacleData : ScriptableObject
{
    public string obstacleName;
    public ObstacleType type;
    public GameObject prefab;
    public int moneyEffect; // تأثیر بر پول (مثبت یا منفی)
}

public enum ObstacleType { Positive, Negative, Question,Shoping,IncreamentalGate,DecreamentalGate }