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
