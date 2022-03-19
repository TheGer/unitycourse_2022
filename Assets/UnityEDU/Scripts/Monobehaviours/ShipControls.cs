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

    //expose the fire rate for designer
    [Header("How fast is your bullet?")] [SerializeField]
    private float fireRate = 25f;
    
    //expose the bullet lifetime for designer
    [Header("Set how long the bullet exists")] [Range(1, 100)] [SerializeField]
    private float bulletLifetime = 5f;
    
    //use the rigibody to move ship around. 
    Rigidbody _rb;

    //capture the direction the ship is supposed to move. 
    private float _xDirection, _yDirection;
    

    //expose the move speed for a designer
    [Header("Set ship speed here, Min 0 Max 10")] [Range(0, 10)] [SerializeField]
    private float moveSpeed;

    
    
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

        if (Input.GetKeyDown(KeyCode.J))
        {
            JumpToRandomLocation();
        }
    }



    private void JumpToRandomLocation()
    {
        Vector3 randomLocation = Vector3.zero;
        randomLocation = randomLocation.randomPositionOnScreen(Camera.main);
        Collider[] objects = new Collider[1];
        if (Physics.OverlapSphereNonAlloc(randomLocation, 1, objects) == 0)
        {
            transform.position = randomLocation;
        }
        else
        {
            JumpToRandomLocation();
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
        GameObject b = BulletPool.Instance.GetAvailableBullet();

        if (b != null)
        {
            //Spawn bullet in front turret
            b.transform.position = _turretRotator.position + (transform.up * 1.1f);
            //Set the bullet at the correct angle
            Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            delta.Normalize();
            b.GetComponent<Rigidbody>().velocity = delta * fireRate;
            b.SetActive(true);
            StartCoroutine(DestroyBullet(b, bulletLifetime));
        }
    }


    private IEnumerator DestroyBullet(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        bullet.SetActive(false);
    }
}