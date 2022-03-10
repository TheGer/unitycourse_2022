using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class ShipControls : MonoBehaviour {


    //Get the turret rotator so we have the correct
    //transform directions
    Transform turretRotator;

    [Header("Don't forget to put a bullet here" +
        "Never Leave without ammunition")]
    [SerializeField] GameObject bullet;
    //use the rigibody to move ship around. 
    Rigidbody rb;

    //capture the direction the ship is supposed to move. 
    float xDirection;
    float yDirection;

    //BulletAnchor to collect bullets in the hierarcy view
    public GameObject bulletAnchor;

    //expose the move speed for a designer
    [Header ("Set ship speed here, Min 0 Max 10")]

    [Range(0,10)]
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        turretRotator = transform.Find("TurretRotator");
        
	}


    void TurretLookAt()
    {

        Vector3 mousePos = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, 0f);


        turretRotator.transform.LookAt(Camera.main.ScreenToWorldPoint(mousePos));
    }
    
    
    
	// Update is called once per frame
	void Update () {
        MoveShip();
        TurretLookAt();

            if(Input.GetMouseButtonDown(0))
            {
                FireBullet();
            }

            Vector3 currentViewportPoint = Camera.main.WorldToViewportPoint(transform.position);
            
            if (currentViewportPoint.x > 1)
            {
                transform.position = new Vector3(
                    Camera.main.ViewportToWorldPoint(new Vector3(0, currentViewportPoint.y)).x,
                    Camera.main.ViewportToWorldPoint(new Vector3(0, currentViewportPoint.y)).y, 0f);
                
            }

            if (currentViewportPoint.x < 0)
            {
                transform.position = new Vector3(
                    Camera.main.ViewportToWorldPoint(new Vector3(1, currentViewportPoint.y)).x,
                    Camera.main.ViewportToWorldPoint(new Vector3(0, currentViewportPoint.y)).y, 0f);
            }
            
            if (currentViewportPoint.y > 1)
            {
                transform.position = new Vector3(
                    Camera.main.ViewportToWorldPoint(new Vector3(currentViewportPoint.x, 0)).x,
                    Camera.main.ViewportToWorldPoint(new Vector3(currentViewportPoint.x, 0)).y, 0f);
            }

            if (currentViewportPoint.y < 0)
            {
                transform.position = new Vector3(
                    Camera.main.ViewportToWorldPoint(new Vector3(currentViewportPoint.x, 1)).x,
                    Camera.main.ViewportToWorldPoint(new Vector3(currentViewportPoint.x, 0)).y, 0f);
            }

            

    }
    
    

    //this method controls ship movement and looks for axis direction

    public void MoveShip()
    {
        xDirection = CrossPlatformInputManager.GetAxis("Horizontal");
        yDirection = CrossPlatformInputManager.GetAxis("Vertical");
        rb.velocity = new Vector3(xDirection * moveSpeed, yDirection * moveSpeed, 0);

    }

    //Fire a bullet on left mouse click
    //lock it to anchor point "BULLETANCHOR"
    //so we can store the bullets somewhere easy

    public void FireBullet()
    {
        GameObject firedBullet = Instantiate<GameObject>(bullet);
        firedBullet.transform.SetParent(bulletAnchor.transform);
        firedBullet.transform.position = turretRotator.position;
        firedBullet.transform.rotation = turretRotator.rotation;

    }
}
