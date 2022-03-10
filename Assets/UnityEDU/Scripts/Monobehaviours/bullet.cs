using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class bullet : MonoBehaviour {

    //how long will the bullet stay on screen?
    public float aliveTime;

    //Set the bullet Speed leave available for designer
    public float bulletSpeed;

    //Get the bullets rigidbody to set and control velocity
    Rigidbody bulletRb;

    //a bool to store whether or not this has collided

    public bool collided = false;

    public bool Collided { get { return collided; } }

   


    Vector3 fireDirection;
	// Use this for initialization
	void Start () {

        bulletRb = gameObject.GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;
        DestroyBullet(aliveTime);
    }
	


    public void DestroyBullet(float t)
    {
        Destroy(gameObject, t);
    }

    void OnCollisionEnter(Collision col)
    {
        //collided = true;
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
