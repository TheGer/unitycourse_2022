using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour
{

	public float asteroidSpeed;
	public float directionX,directionY;

	public int asteroidLevel;

	public bool hit;
	
	
	// Use this for initialization
	void Start()
	{
		RandomizeDirection();
	}

	public void RandomizeDirection()
	{
		directionX = Random.Range(-1f, 1f);
		directionY = Random.Range(-1f, 1f);
	
	}


	public void SpawnChildren(int level,asteroidData[] asteroids)
	{
		for (int i = 0; i < 3; i++)
		{
			 	if (level<3){
			 		GameObject childAsteroid = Instantiate(asteroids[level].asteroidprefab,this.transform);
			 		childAsteroid.transform.position = transform.position;
			 		asteroidController controller = childAsteroid.AddComponent<asteroidController>();
					
				childAsteroid.GetComponent<asteroidController>().asteroidSpeed = asteroids[level].asteroidSize;
				childAsteroid.transform.localScale =  childAsteroid.transform.localScale * (asteroids[level].asteroidSize * asteroids[level].asteroidScale);
				childAsteroid.GetComponent<asteroidController>().SpawnChildren(level+1,asteroids);
			 		childAsteroid.SetActive(false);
		}
		 }
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(asteroidSpeed * directionX,asteroidSpeed * directionY,0);
		transform.position = transform.position.keepOnScreen(Camera.main);
	}
}
