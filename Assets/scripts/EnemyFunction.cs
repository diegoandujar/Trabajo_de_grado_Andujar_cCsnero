using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFunction : MonoBehaviour
{
    public int health = 100;

    public GameObject Item;

    private int numberDead = 0;

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

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            patrolRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            patrolRange = false;
        }
    }
    

    public void TakeDamege(int damage)
    {
        health -= damage;
        Debug.Log(health);

        if(health <= 0 && numberDead == 0)
        {
            Die();
            //getRandomItem();
            SpawnItem();
            numberDead++;
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

    public void SpawnItem()
    {
        Vector2 EnemyPos = new Vector2(transform.position.x + 1, transform.position.y - 0.4f);
        Instantiate(Item, EnemyPos, Quaternion.identity);
    }

}
