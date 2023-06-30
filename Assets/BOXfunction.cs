using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOXfunction : MonoBehaviour
{

    private videoFunction video;

    public bool rango;
    public bool abierto;

    private void Awake()
    {
        video = GameObject.Find("Video").GetComponent<videoFunction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rango == true && Input.GetKeyDown("x"))
        {
            abierto = true;
            popup();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rango = false;
        }
    }

    private void popup()
    {
        video.playVideo();
    }

}
