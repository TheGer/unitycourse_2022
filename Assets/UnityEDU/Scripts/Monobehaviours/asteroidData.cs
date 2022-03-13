using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Asteroid", menuName = "Asteroid Data", order = 1)]
public class asteroidData : ScriptableObject {
  
    //Cannot inherit singleton class as only one class can be inherited
    //Might need to implement this manually
    //Asking whether you can inherit other classes in scriptable objects or alternatives //David

    public float minVelocity = 5;
    public float maxVelocity = 10;
    public float maxAngularVelocity = 10;
    public int asteroidSize = 3;
    public float asteroidScale = 0.75f;
    public int children = 2;
    public int[] score = {0, 400, 200, 100};
    public GameObject[] prefabs;

    public GameObject GetPrefab()
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }
}
