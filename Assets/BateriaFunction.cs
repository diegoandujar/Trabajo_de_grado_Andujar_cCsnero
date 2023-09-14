using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BateriaFunction : MonoBehaviour
{

    private bool Onrange = false;
    private bool alive = true;
    private GameObject Player;

    private enum MovementState { Idle };
    private Animator anim;

    [SerializeField] public AudioSource Boom;

    [SerializeField] private AudioSource explosion;

    private ItemCollector item;
    private Weapon arma;
    private PlayerMovement plmove;

    // Start is called before the first frame update
    void Start()
    {
        arma = GameObject.Find("Player").GetComponent<Weapon>();
        anim = GetComponent<Animator>();
        item = GameObject.Find("Player").GetComponent<ItemCollector>();
        plmove = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (Onrange == true && Input.GetKeyDown("c") )
            {
                plmove.Planting = true;
                plmove.mover = false;
                arma.canShoot = false;
                Die();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Onrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Onrange = false;
        }
    }

    private void animationUpdate()
    {
        //MovementState state;
        anim.SetInteger("state", 0);

    }

    private void Die()
    {
        anim.SetTrigger("boom");
        alive = false;
        item.bateries++;
        item.WriteBaterias(item.bateries);
    }

    public void playSound()
    {
        Boom.Play();
    }

    public void playExplosion()
    {
        explosion.Play();
    }

}
