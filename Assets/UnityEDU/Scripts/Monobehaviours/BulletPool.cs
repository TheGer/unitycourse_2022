using System;
using UnityEngine;
using System.Collections.Generic;


public class BulletPool : Singleton<BulletPool>
{
   
    public List<GameObject> bulletPool;
    
    
    [Header("Set the bullet Prefab here")][SerializeField]
    private GameObject bullet;
    
    [Header("Set the size of the bullet pool here, Min 0 Max 50")] [Range(0, 50)] [SerializeField]
    private int poolSize = 10;

    [Header("BulletAnchor to collect bullets")] [SerializeField]
    private GameObject bulletAnchor;

    private void Start()
    {
        bulletPool = new List<GameObject>();
        GameObject b;
        for (int i = 0; i < poolSize; i++)
        {
            b = Instantiate(bullet);
            b.transform.SetParent(bulletAnchor.transform);
            b.SetActive(false);
            bulletPool.Add(b);
        }
    }

    public GameObject GetAvailableBullet()
    {
        foreach (GameObject b in bulletPool)
        {
            if (!b.activeInHierarchy) return b;
        }
        return null;
    }
    
}