using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerWeapon : MonoBehaviour
{
    public Transform FirePoint;

    public GameObject BulletPrefab;

    private bool PlayerOnRange = false;
    private int cargador;

    private float timeToAttack = 1.5f;
    private float attack;

    void Update()
    {

        if (PlayerOnRange == true && attack <= 0)
        {
            shoot();
            attack = timeToAttack;
        }
        else if (PlayerOnRange == true && attack > 0)
        {
            attack -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerOnRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerOnRange = false;
        }

    }


    void shoot()
    {
        //que se spawn, donde y la rotacion
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}

