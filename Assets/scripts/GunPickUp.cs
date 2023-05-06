using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    private Inventory invetory;
    public GameObject itemButton;
    private bool canTake = false;

    private void Awake()
    {
        invetory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (canTake == true && Input.GetKeyDown("z"))
        {
            for (int i = 0; i < invetory.slots.Length; i++)
            {
                if (invetory.isFull[i] == false)
                {
                    //se toma el arma
                    invetory.isFull[i] = true;
                    Instantiate(itemButton, invetory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTake = true; 
        }
        else if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("BulletEnemy")) 
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTake = false;
        }
    }

}
