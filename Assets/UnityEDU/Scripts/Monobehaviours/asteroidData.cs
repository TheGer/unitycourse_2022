using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Asteroid", menuName = "Asteroid Data", order = 1)]
public class asteroidData : ScriptableObject {
  
    public int asteroidSize;
    public string name;
    public int score;

}
