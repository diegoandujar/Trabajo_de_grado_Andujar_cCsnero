using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    //OnTriggerEnter2D ya que se coloco en Cherry la casilla is trigger
    //Si no se coloco la casilla is trigger se utiliza OnCollisionEnter2D

    public int Bullets = 0;
    public int Bullets2 = 0;
    public int Soldiers = 0;

    [SerializeField] private AudioSource CollectSound;

    [SerializeField] private Text BulletsText;
    [SerializeField] private Text bullets2Text;

    [SerializeField] private Text salvadosText;
    public int salvados = 0;
    public int TotalSoldados;

    public int bateries = 0;
    //public int TotalBaterias;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletColect"))
        {
            CollectSound.Play();
            Destroy(collision.gameObject);
            Bullets = Bullets + 5;
            WriteOntext(Bullets,0);
        }
        else if (collision.gameObject.CompareTag("BulletCollect2"))
        {
            CollectSound.Play();
            Destroy(collision.gameObject);
            Bullets2 = Bullets2 + 5;
            WriteOntext(Bullets2,1);
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

    public void WriteOntext(int bullets, int bala)
    {
        if (bala == 0)
        {
            BulletsText.text = "Balas peque�as: " + Bullets;
        }
        else
        {
            bullets2Text.text = "Balas grandes: " + Bullets2;
        }
       
    }

    public void WriteBaterias(int bateriasDestruidas)
    {
        salvadosText.text = "Baterias: " + bateriasDestruidas+"/9";
    }

    public int Bulletcoutns()
    {
        return Bullets;
    }

    public int bulletcounts2()
    {
        return Bullets2;
    }

    public void deleteBullet(int bullet)
    {
        if (bullet == 0)
        {
            Bullets = Bullets - 1;
            WriteOntext(Bullets,0);
        }
        else
        {
            Bullets2 = Bullets2 - 1;
            WriteOntext(Bullets2, 1);
        }
        
    }

    public void writeSalvados(int soldadoSalvado)
    {
        salvadosText.text = "Salvados: " + soldadoSalvado+"/"+TotalSoldados;
    }

}
