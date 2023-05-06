using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    //OnTriggerEnter2D ya que se coloco en Cherry la casilla is trigger
    //Si no se coloco la casilla is trigger se utiliza OnCollisionEnter2D

    public int CherryCount = 0;


    [SerializeField] private AudioSource CollectSound;

    [SerializeField] private Text CherriesText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            CollectSound.Play();
            Destroy(collision.gameObject);
            CherryCount++;
            CherriesText.text = "Cherries: " + CherryCount;

        } 
        else if (collision.CompareTag("Botiquin"))
        {
            transform.GetComponent<PlayerDeath>().PlayerHealth = 100;
            Debug.Log(transform.GetComponent<PlayerDeath>().PlayerHealth);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Venda"))
        {
            if(transform.GetComponent<PlayerDeath>().PlayerHealth + 25 > 100)
            {
                transform.GetComponent<PlayerDeath>().PlayerHealth = 100;
            }  else
            {
                transform.GetComponent<PlayerDeath>().PlayerHealth += 25;
            }

            Debug.Log(transform.GetComponent<PlayerDeath>().PlayerHealth);
            Destroy(collision.gameObject);
        }
        


    }
}
