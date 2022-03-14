using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour
{

	public float asteroidSpeed;
	public float directionX,directionY;

	public int asteroidLevel;
	
	// Use this for initialization
	void Start ()
	{
		directionX = Random.Range(-1f, 1f);
		directionY = Random.Range(-1f, 1f);
	}


	public void SpawnChildren(int level,asteroidData[] asteroids)
	{
		Debug.Log(level);
		
		for (int i = 0; i < 2; i++)
		{
			if (level<2){
				GameObject childAsteroid = Instantiate(asteroids[level+1].asteroidprefab,this.transform);
				childAsteroid.transform.position = childAsteroid.transform.position;
				childAsteroid.AddComponent<asteroidController>();
				childAsteroid.GetComponent<asteroidController>().asteroidSpeed = asteroids[level+1].asteroidSize;
			
				childAsteroid.GetComponent<asteroidController>().SpawnChildren(level+1,asteroids);
				childAsteroid.SetActive(false);
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(asteroidSpeed * directionX,asteroidSpeed * directionY);
		transform.position = transform.position.keepOnScreen(Camera.main);
	}
}
