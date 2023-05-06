using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slots : MonoBehaviour
{

    private Inventory invetory;
    private GunHolderFunction GunHolder;

    public int Slotnumber;
    public bool usando = false;

    private void Awake()
    {
        invetory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        GunHolder = GameObject.Find("GunHolder").GetComponent<GunHolderFunction>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            invetory.isFull[Slotnumber] = false;
        }
    }

    public void DorpItem()
    {
        if (usando == false)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Spawn>().SpawnItem();
                GameObject.Destroy(child.gameObject);
            }
        }
        else if (usando == true)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Spawn>().SpawnItem();
                GameObject.Destroy(child.gameObject);
            }
            GunHolder.ChangeSprite(0, 0);
        }

        
    }
}
