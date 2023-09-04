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


    private Transform player;

    private EnemyWeapon weapon;

    [SerializeField] private GameObject arma;
    [SerializeField] private AudioSource morir;

    private bool vivo = true;

    //[SerializeField] AudioSource Gun;

    private enum MovementStates {idle, running};

    private bool tooClose;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        SpRen = GetComponent<SpriteRenderer>();
        weapon = GetComponent<EnemyWeapon>();
        
    }

    void Update()
    {
        /*if (patrolRange == true && right)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if(patrolRange == true && !right)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        }*/
        if (vivo == true)
        {

        
            if (player.position.x > transform.position.x && patrolRange)
            {
                if (!right)
                {
                    flip();
                    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                    tooClose = false;
                }
                else
                {
                    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                    tooClose = false;
                }

            }
            else if (player.position.x < transform.position.x && patrolRange)
            {
                if (right)
                {
                    flip();
                    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                    tooClose = false;
                }
                else
                {
                    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                    tooClose = false;
                }
            }

            if (weapon.PlayerOnRange == true && weapon.attack <= 0)//
            {
                weapon.attack = weapon.timeToAttack;
                Debug.Log("dispara Enemigo");
                //Gun.Play();
                weapon.shoot();

            }
            else if (weapon.PlayerOnRange == true && weapon.attack > 0)//PlayerOnRange == true 
            {
                weapon.attack -= Time.deltaTime;
            }
            
            AnimantionUpdate();
        
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        patrolRange = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        patrolRange = true;
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
            vivo = false;
            weapon.PlayerOnRange = false;
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
        morir.Play();
        //Debug.Log(gameObject.name);
        Destroy(arma);
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
