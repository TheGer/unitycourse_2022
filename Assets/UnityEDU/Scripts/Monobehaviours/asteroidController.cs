using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour
{

	public float asteroidSpeed;
	public float direction;
	
	// Use this for initialization
	void Start ()
	{
		direction = Random.Range(-1f, 1f);
	}


	void spawnChildren()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(asteroidSpeed * direction,asteroidSpeed * direction);
		transform.position = transform.position.keepOnScreen(Camera.main);
	}
}
