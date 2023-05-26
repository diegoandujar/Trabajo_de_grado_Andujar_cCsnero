using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    //OnTriggerEnter2D ya que se coloco en Cherry la casilla is trigger
    //Si no se coloco la casilla is trigger se utiliza OnCollisionEnter2D

    public int Bullets = 0;


    [SerializeField] private AudioSource CollectSound;

    [SerializeField] private Text BulletsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletColect"))
        {
            CollectSound.Play();
            Destroy(collision.gameObject);
            Bullets++;
            WriteOntext(Bullets);
        } 
        else if (collision.CompareTag("Botiquin"))
        {
            transform.GetComponent<PlayerDeath>().takeHealth(0);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Venda"))
        {
            transform.GetComponent<PlayerDeath>().takeHealth(1);
            Destroy(collision.gameObject);
        }
        


    }

    public void WriteOntext(int bullets)
    {
        BulletsText.text = "Bullets: " + Bullets;
    }

}
