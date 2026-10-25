using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Goal", menuName = "Goals")]
public class Goal : ScriptableObject
{
   public List<Sprite> sprites;
}
