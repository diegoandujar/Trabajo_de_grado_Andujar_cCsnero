using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFunction : MonoBehaviour
{
    public int health = 100;

    private Animator anim;
    private SpriteRenderer SpRen;

    public bool patrolRange = false;

    public bool right = true;

    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private float dirX = 0f;


    private enum MovementStates {idle, running};

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        SpRen = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (patrolRange == true && right)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if(patrolRange == true && !right)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        }

        AnimantionUpdate();
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            patrolRange = true;

            if (collision.transform.position.x < transform.position.x && right)
            {
                flip();
            }
            else if(collision.transform.position.x > transform.position.x && !right)
            {
                flip();
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            patrolRange = false;
        }
    }
    */

    public void TakeDamege(int damage)
    {
        health -= damage;
        Debug.Log(health);

        if(health <= 0)
        {
            Die();
        }

    }

    private void AnimantionUpdate()
    {
        MovementStates states;
        if (patrolRange == true)
        {
            states = MovementStates.running;
        } else
        {
            states = MovementStates.idle;
        }
        
        anim.SetInteger("state", (int)states);
    }

    private void Die()
    {
        Debug.Log(gameObject.name);
        anim.SetTrigger("deathEnemy");
        //Destroy(gameObject);   
    }

    public void destroyEnemySprite()
    {
        Destroy(gameObject);
    }

    public void flip()
    {
        right = !right;

        transform.Rotate(0f, 180f, 0f);

    }

}
