using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullletMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float speed = 17f;
    //public int damage;

    private GunHolderFunction gun;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right  * speed; // * Time.deltaTime
    }

    /*public void setDamage(int power)
    {
        damage = power;
        Debug.Log("el dano seteado es de " + power);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gun = GameObject.Find("GunHolder").GetComponent<GunHolderFunction>(); 

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyFunction>().TakeDamege(gun.BulletDamage); //EnemyFunction enemy = collision.GetComponent<EnemyFunction>()
            Debug.Log("el dano hecho al enemigo es de: "+gun.BulletDamage);

        } else if (collision.gameObject.CompareTag("Bunker"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<BunkerFunction>().TakeDamege(gun.BulletDamage);
            Debug.Log("el dano hecho al bunker es de: "+gun.BulletDamage);
        }

       

    }

}
