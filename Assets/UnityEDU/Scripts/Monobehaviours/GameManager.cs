using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;





class LevelInfo
{
	
	public static string levelProgression = "1:3/2,2:4/2,3:3/3,4:4/3,5:5/3,6:3/4,7:4/4,8:5/4,9:6/4,10:3/5";

	
	public static int CurrentLevel, NumberOfAsteroids, NumberOfChildren;

	public static void GetLevel(int level)
	{

		string currentLevelData = levelProgression.Split(',')[level - 1];
		
		string[] thisLevel = currentLevelData.Split(':');
		CurrentLevel = Int32.Parse(thisLevel[0]);
		NumberOfAsteroids = Int32.Parse(thisLevel[1].Split('/')[0]);
		NumberOfChildren = Int32.Parse(thisLevel[1].Split('/')[1]);

		
	}


}

public class GameManager : Singleton<GameManager> {


	
	// Use this for initialization
	public asteroidSO[] asteroids;
	
	
	public int currentLevel = 1; 
	public int shotsFired = 0;
	public int asteroidsHit = 0;
	public int score = 0;
	public int luckyShots=0;
	
	public Dictionary<string, bool> monitorableProperties;


	
	void Start ()
	{
		monitorableProperties = new Dictionary<string, bool>();
		monitorableProperties.Add("currentLevel",false);
		monitorableProperties.Add("shotsFired",false);
		monitorableProperties.Add("asteroidsHit",false);
		monitorableProperties.Add("score",false);
		monitorableProperties.Add("luckyShot",false);

		
		
		SetupLevel();

	}

	void SetupLevel()
	{
		LevelInfo.GetLevel(currentLevel);
		
		for (int counter = 0; counter < LevelInfo.NumberOfAsteroids; counter++)
		{
			SpawnCluster();
		}
	}


	void SpawnCluster()
	{

		int r = 0; //Random.Range(0, asteroids.Length);
		GameObject bigAsteroid = Instantiate(asteroids[r].asteroidprefab);
		
		bigAsteroid.transform.position = new Vector3().randomPositionOnScreen(Camera.main);
		bigAsteroid.transform.localScale = bigAsteroid.transform.localScale * (asteroids[r].asteroidSize * asteroids[r].asteroidScale);
		bigAsteroid.AddComponent<asteroidController>();
		bigAsteroid.GetComponent<asteroidController>().asteroidSpeed = asteroids[r].asteroidSize;
		bigAsteroid.GetComponent<asteroidController>().SpawnChildren(r+1,asteroids);
	}

	
}
