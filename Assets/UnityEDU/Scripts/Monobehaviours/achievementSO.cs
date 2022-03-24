using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement Data", order = 2)]
public class achievementSO : ScriptableObject
{
    public List<Achievement> achievements = new List<Achievement>();
    

}


