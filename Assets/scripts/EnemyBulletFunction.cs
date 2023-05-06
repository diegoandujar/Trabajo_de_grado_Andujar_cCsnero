using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletFunction : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 17f;
    private int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed; // * Time.deltaTime
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerDeath>().TakeDamege(damage); //EnemyFunction enemy = collision.GetComponent<EnemyFunction>()

        }



    }

}
