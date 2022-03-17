using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class bullet : MonoBehaviour {

    //a bool to store whether or not this has collided

    public bool collided = false;

    private void FixedUpdate()
    {
        if (transform.position.keepOnScreen(Camera.main) != transform.position)
        {
            transform.position = transform.position.keepOnScreen(Camera.main);
        }
    }

    private List<Collider> objectsCollidedWith = new List<Collider>();
    
    void OnCollisionEnter(Collision col)
    {
        collided = true;
       
        if (col.collider.gameObject.CompareTag("Asteroid"))
        {
            objectsCollidedWith.Add(col.collider);

            int childcount = col.collider.gameObject.transform.childCount;


            for (int childCounter=0;childCounter<childcount;childCounter++)
            {
                Transform childAsteroid = col.collider.gameObject.transform.GetChild(0);
                Debug.Log(childAsteroid.gameObject.name);
                
                childAsteroid.parent = null;
                childAsteroid.position = transform.position;
                childAsteroid.GetComponent<asteroidController>().RandomizeDirection();
                childAsteroid.gameObject.SetActive(true);
                ////   childAsteroid.position = col.gameObject.transform.position;
                //   
                
            }
           // 
           Destroy(objectsCollidedWith[0].gameObject,1);
         
             gameObject.SetActive(false);    
        }
        
        
    }

    //Broken ---NEEDS FIX
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
