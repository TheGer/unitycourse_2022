using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour
{

	public float asteroidSpeed;
	public float directionX,directionY;

	private asteroidData asteroidSO;

	public int asteroidLevel;

	public bool hit;
	
	
	// Use this for initialization
	void Start()
	{
		RandomizeDirection();
		asteroidSO = GameManager.Instance.asteroids[asteroidLevel];
	}

	public void RandomizeDirection()
	{
		directionX = Random.Range(-1f, 1f);
		directionY = Random.Range(-1f, 1f);
	
	}


	public void SpawnChildren(int level,asteroidData[] asteroids)
	{
		for (int i = 0; i < LevelInfo.NumberOfChildren; i++)
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
	
	
	void OnCollisionEnter(Collision col)
	{
	
       
		if (col.collider.gameObject.CompareTag("Bullet"))
		{
            
			int childCount = transform.childCount;
			
            
			ParticleSystem explosion = asteroidSO.getAsteroidParticlePrefab();

			ParticleSystem instancedExplosion = Instantiate(explosion,transform.position,transform.rotation);
			
			
			
			
			
            
			for (int childCounter=0;childCounter<childCount;childCounter++)
			{
				Transform childAsteroid = transform.GetChild(0);
				Debug.Log(childAsteroid.gameObject.name);

				childAsteroid.parent = null;
				childAsteroid.position = transform.position;
				childAsteroid.GetComponent<asteroidController>().RandomizeDirection();
				childAsteroid.gameObject.SetActive(true);
                
				////   childAsteroid.position = col.gameObject.transform.position;
				//   

			}
			// 
			
			col.gameObject.SetActive(false);
			Destroy(gameObject);
		
         
              
		}
        
        
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(asteroidSpeed * directionX,asteroidSpeed * directionY,0);
		transform.position = transform.position.keepOnScreen(Camera.main);
	}
}
