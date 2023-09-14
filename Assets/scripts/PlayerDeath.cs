using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public Health_bar healthbar;

    private Animator anim;
    private Rigidbody2D rig;
    private Weapon weapon;

    private PlayerMovement movement;

    private BoxCollider2D box;
    public bool alive = true;

    public int PlayerHealth = 100;

    [SerializeField] private AudioSource DeadSound;
    [SerializeField] private AudioSource HurtSound;
    [SerializeField] private AudioSource mine;

    // Start is called before the first frame update
    private void Start()
    {
        healthbar.Setmaxvalue(PlayerHealth);
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        weapon = GetComponent<Weapon>();
        movement = GetComponent<PlayerMovement>();
    }

    //En los objetos con los que "chocamos" se taggean para poder tener un control de lo que son y ademas tener la facilidad de buscarlos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mine"))
        {
            mine.Play();
            DeadSound.Play();
            collision.gameObject.GetComponent<Animator>().SetTrigger("explosion");
            Die();
        }
        else if (collision.gameObject.CompareTag("trap"))
        {
            DeadSound.Play();
            Die();
        }
        else if (collision.gameObject.CompareTag("watermark"))
        {
            HurtSound.Play();
            Die();
        }

    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("mine"))
        {
            mine.Play();
            DeadSound.Play();
            Die();
        }
    }*/

    private void Die()
    {
        alive = false;
        weapon.canShoot = false;
        rig.bodyType = RigidbodyType2D.Static;
        box.isTrigger = true;
        anim.SetTrigger("death");
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamege(int damage)
    {
        if (alive == true)
        {
            HurtSound.Play();
            PlayerHealth -= damage;
            Debug.Log("Player health = "+PlayerHealth);
            healthbar.UpdateHealthbar(PlayerHealth);

            if (PlayerHealth <= 0)
            {
                alive = false;
                DeadSound.Play();
                Die();
            }
        }
        

    }

    public void takeHealth(int item)
    {
        movement.Health.Play();
        if (item == 0)
        {
            PlayerHealth = 100;
            healthbar.UpdateHealthbar(PlayerHealth);
        }
        else if (item == 1)
        {
            if (PlayerHealth + 25 > 100)
            {
                PlayerHealth = 100;
            }
            else
            {
                PlayerHealth += 25;
            }

            healthbar.UpdateHealthbar(PlayerHealth);
            Debug.Log(PlayerHealth);
        }
    }

}
