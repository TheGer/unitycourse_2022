using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class bullet : MonoBehaviour {

    //a bool to store whether or not this has collided

    public bool collided = false;

    void OnCollisionEnter(Collision col)
    {
        collided = true;
        gameObject.SetActive(false);
    }

    //Broken ---NEEDS FIX
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
