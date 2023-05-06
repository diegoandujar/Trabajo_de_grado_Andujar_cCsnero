using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullletMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float speed = 17f;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right  * speed; // * Time.deltaTime
    }

    public void setDamage(int power)
    {
        damage = power;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyFunction>().TakeDamege(damage); //EnemyFunction enemy = collision.GetComponent<EnemyFunction>()
            Debug.Log("el dano hecho al enemigo es de: "+damage);

        } else if (collision.gameObject.CompareTag("Bunker"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<BunkerFunction>().TakeDamege(damage);
            Debug.Log("el dano hecho al bunker es de: "+damage);
        }

       

    }

}
