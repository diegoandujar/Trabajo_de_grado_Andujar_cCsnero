using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BateriaFunction : MonoBehaviour
{

    private bool Onrange = false;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Onrange == true && Input.GetKeyDown("c") )
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Onrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Onrange = false;
        }
    }

}
