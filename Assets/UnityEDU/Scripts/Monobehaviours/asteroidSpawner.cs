using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour {

	// Use this for initialization
	public asteroidData[] asteroids;
	public int numberOfClusters;
	
	
	
	void Start () {
		for (int counter = 0; counter < numberOfClusters; counter++)
		{
			SpawnCluster();
		}
	}
	
	
	

	void SpawnCluster()
	{
		GameObject bigAsteroid = Instantiate(asteroids[0].asteroidprefab);
		bigAsteroid.transform.position = new Vector3().randomPositionOnScreen(Camera.main);
		bigAsteroid.AddComponent<asteroidController>();
		bigAsteroid.GetComponent<asteroidController>().asteroidSpeed = asteroids[0].asteroidSize;
		for (int i = 0; i < 2; i++)
		{
			GameObject mediumAsteroid = Instantiate(asteroids[1].asteroidprefab);
			mediumAsteroid.transform.position = bigAsteroid.transform.position;
			mediumAsteroid.AddComponent<asteroidController>();
			mediumAsteroid.GetComponent<asteroidController>().asteroidSpeed = asteroids[1].asteroidSize;
			
			for (int j = 0; j < 2; j++)
			{
				GameObject smallAsteroid = Instantiate(asteroids[2].asteroidprefab);
				smallAsteroid.transform.position = mediumAsteroid.transform.position;
				smallAsteroid.AddComponent<asteroidController>();
				smallAsteroid.GetComponent<asteroidController>().asteroidSpeed = asteroids[2].asteroidSize;
				
			}
		}


	}

	
	
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
