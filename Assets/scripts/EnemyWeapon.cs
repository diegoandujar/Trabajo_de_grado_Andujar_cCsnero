using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform FirePoint;

    public GameObject BulletPrefab;

    public bool PlayerOnRange = false;
    public float timeToAttack = 1.5f;
    public float delay = 0.5f;
    public float attack;
    public bool first = false;


    /*void Update()
    {
        if (PlayerOnRange == true && attack <= 0)//
        {
            attack = timeToAttack;
            shoot();
        
        }
        else if(PlayerOnRange == true && attack > 0)//PlayerOnRange == true 
        {
            attack -= Time.deltaTime; 
        }

    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerOnRange = true;

            /*if (collision.transform.position.x < transform.position.x && transform.GetComponentInParent<EnemyFunction>().right)
            {
                transform.GetComponentInParent<EnemyFunction>().flip();
            }
            else if (collision.transform.position.x > transform.position.x && !transform.GetComponentInParent<EnemyFunction>().right)
            {
                transform.GetComponentInParent<EnemyFunction>().flip();
            }*/
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerOnRange = false;
        }
        
    }


    public void shoot()
    {
        //que se spawn, donde y la rotacion
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
