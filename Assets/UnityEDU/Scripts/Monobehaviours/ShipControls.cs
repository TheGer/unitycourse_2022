using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class ShipControls : MonoBehaviour
{
    //Get the turret rotator so we have the correct
    //transform directions
    Transform _turretRotator;

    [Header("Don't forget to put a bullet here. Never Leave without ammunition!")]
    [SerializeField]
    GameObject bullet;

    [Header("How fast is your bullet?")]
    [SerializeField]
    private float fireRate = 25f;
    
    
    //use the rigibody to move ship around. 
    Rigidbody _rb;

    //capture the direction the ship is supposed to move. 
    private float _xDirection, _yDirection;
    

    //expose the move speed for a designer
    [Header("Set ship speed here, Min 0 Max 10")] [Range(0, 10)] [SerializeField]
    private float moveSpeed;

    // Use this for initialization
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _turretRotator = transform.Find("TurretRotator");
    }


    void TurretLookAt()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, 0f);
        
        //Calculating angle using Pythagoras
        Vector2 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        //Setting rotation
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();
        TurretLookAt();
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }


    //this method controls ship movement and looks for axis direction

    private void MoveShip()
    {
        _xDirection = CrossPlatformInputManager.GetAxis("Horizontal");
        _yDirection = CrossPlatformInputManager.GetAxis("Vertical");
        _rb.velocity = new Vector3(_xDirection * moveSpeed, _yDirection * moveSpeed, 0);
        transform.position = transform.position.keepOnScreen(Camera.main);
    }

    private void FireBullet()
    {
        GameObject b = BulletPool.SharedInstance.GetAvailableBullet();

        if (b != null)
        {
            //Spawn bullet in front turret
            b.transform.position = _turretRotator.position + (transform.up * 1.1f);
            //Set the bullet at the correct angle
            Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            delta.Normalize();
            b.GetComponent<Rigidbody>().velocity = delta * fireRate;
            b.SetActive(true);
        }
    }
}