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
        if (col.collider.gameObject.tag == "Asteroid")
        {
            Destroy(col.collider.gameObject);
            gameObject.SetActive(false);    
        }
        
        
    }

    //Broken ---NEEDS FIX
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
