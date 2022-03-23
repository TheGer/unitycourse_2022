using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class bullet : MonoBehaviour {

    //a bool to store whether or not this has collided

    public bool collided = false;
    public bool wrappedScreen = false;
    private void FixedUpdate()
    {
        if (transform.position.keepOnScreen(Camera.main) != transform.position)
        {
            transform.position = transform.position.keepOnScreen(Camera.main);
        }
    }


   

    //Broken ---NEEDS FIX
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
