using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;

    public GameObject BulletPrefab;

    public bool canShoot;

    // Update is called once per frame
    void Update()
    {

        // edit project settings input, etc
        if (Input.GetKeyDown("space") && canShoot)
        {
            shoot();
        }

    }

    void shoot()
    {
        //que se spawn, donde y la rotacion
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }

}
