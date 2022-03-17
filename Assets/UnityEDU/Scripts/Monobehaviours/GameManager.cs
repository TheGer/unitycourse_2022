using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class LevelInfo
{
	
	public string levelProgression = "1:3/2,2:4/2,3:3/3,4:4/3,5:5/3,6:3/4,7:4/4,8:5/4,9:6/4,10:3/5";


	private int currentLevel, numberOfAsteroids, numberOfChildren;

	void ParseLevelProgression()
	{
		foreach (string l in levelProgression.Split(','))
		{
			string[] eachLevel = l.Split(':');
			currentLevel = Int32.Parse(eachLevel[0]);
			numberOfAsteroids = Int32.Parse(eachLevel[0].Split('/')[0]);
			numberOfChildren = Int32.Parse(eachLevel[0].Split('/')[1]);

		}
	}


}

public class GameManager : Singleton<GameManager> {


	
	// Use this for initialization
	public asteroidData[] asteroids;
	public int numberOfClusters;
	LevelInfo currentLevel;
	
	
	
	void Start () {
		for (int counter = 0; counter < numberOfClusters; counter++)
		{
			SpawnCluster();
		}
	}
	
	
	

	void SpawnCluster()
	{
		Debug.Log(asteroids);
		int r = 0; //Random.Range(0, asteroids.Length);
		GameObject bigAsteroid = Instantiate(asteroids[r].asteroidprefab);
		
		bigAsteroid.transform.position = new Vector3().randomPositionOnScreen(Camera.main);
		bigAsteroid.transform.localScale = bigAsteroid.transform.localScale * (asteroids[r].asteroidSize * asteroids[r].asteroidScale);
		bigAsteroid.AddComponent<asteroidController>();
		bigAsteroid.GetComponent<asteroidController>().asteroidSpeed = asteroids[r].asteroidSize;
		bigAsteroid.GetComponent<asteroidController>().SpawnChildren(r+1,asteroids);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
