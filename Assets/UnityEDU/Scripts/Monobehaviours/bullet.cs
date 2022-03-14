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

    void OnCollisionEnter(Collision col)
    {
        collided = true;
        if (col.collider.gameObject.CompareTag("Asteroid"))
        {
            foreach (Transform childAsteroid in col.collider.gameObject.transform)
            {
                Debug.Log(childAsteroid.gameObject.name);
                
                childAsteroid.parent = null;
                childAsteroid.gameObject.SetActive(true);
                childAsteroid.position = transform.position;
                ////   childAsteroid.position = col.gameObject.transform.position;
                //   

            }
           // Destroy(col.collider.gameObject);
            gameObject.SetActive(false);    
        }
        
        
    }

    //Broken ---NEEDS FIX
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
