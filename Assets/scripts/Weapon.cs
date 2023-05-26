using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;

    public GameObject BulletPrefab;
    public GameObject BulletPrefab2;

    public bool canShoot;

    private int itemCollector;

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
        if ( GameObject.Find("GunHolder").GetComponent<GunHolderFunction>().BulletDamage < 36)   //GameObject.Find("Player").GetComponent<Weapon>().BulletPrefab.GetComponent<BullletMovement>().damage
        {
            Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        }
        else if (GameObject.Find("GunHolder").GetComponent<GunHolderFunction>().BulletDamage > 35)  //GameObject.Find("Player").GetComponent<Weapon>().BulletPrefab.GetComponent<BullletMovement>().damage
        {
            Instantiate(BulletPrefab2, FirePoint.position, FirePoint.rotation);
        }
        
    }

}
