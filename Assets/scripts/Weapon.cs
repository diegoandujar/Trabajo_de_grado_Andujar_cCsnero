using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;

    private int bullets;
    private int bullets2;
    private ItemCollector balas;

    public GameObject BulletPrefab;
    public GameObject BulletPrefab2;

    public bool canShoot;

    [SerializeField] private AudioSource gunShot;

    private int itemCollector;

    private void Start()
    {
        balas = GetComponent<ItemCollector>();
    }

    // Update is called once per frame
    void Update()
    {

        bullets = balas.Bulletcoutns();
        bullets2 = balas.bulletcounts2();

        // edit project settings input, etc
        if (Input.GetKeyDown("space") && canShoot && bullets > 0 && GameObject.Find("GunHolder").GetComponent<GunHolderFunction>().tipo == 2)
        {
            Debug.Log("dispara player 1");
            shoot();
            balas.deleteBullet(0);
        }
        else if (Input.GetKeyDown("space") && canShoot && bullets2 > 0 && GameObject.Find("GunHolder").GetComponent<GunHolderFunction>().tipo == 1) // && 
        {
            Debug.Log("dispara player 1");
            shoot();
            balas.deleteBullet(1);
        }

    }

    void shoot()
    {
        //que se spawn, donde y la rotacion
        if ( GameObject.Find("GunHolder").GetComponent<GunHolderFunction>().BulletDamage < 36)   //GameObject.Find("Player").GetComponent<Weapon>().BulletPrefab.GetComponent<BullletMovement>().damage
        {            
            gunShot.Play();
            Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            
        }
        else if (GameObject.Find("GunHolder").GetComponent<GunHolderFunction>().BulletDamage > 35)  //GameObject.Find("Player").GetComponent<Weapon>().BulletPrefab.GetComponent<BullletMovement>().damage
        {
            gunShot.Play();
            Instantiate(BulletPrefab2, FirePoint.position, FirePoint.rotation);
            
        }
        
    }

}
