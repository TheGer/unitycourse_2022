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
		bigAsteroid.GetComponent<asteroidController>().SpawnChildren(0,asteroids);
		



	}

	
	
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
