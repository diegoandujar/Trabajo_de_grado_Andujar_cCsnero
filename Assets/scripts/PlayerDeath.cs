using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rig;

    public int PlayerHealth = 100;

    [SerializeField] private AudioSource DeadSound;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    //En los objetos con los que "chocamos" se taggean para poder tener un control de lo que son y ademas tener la facilidad de buscarlos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mine"))
        {
            DeadSound.Play();
            collision.gameObject.GetComponent<Animator>().SetTrigger("explosion");
            Die();     
        } 
        else if (collision.gameObject.CompareTag("trap"))
        {
            DeadSound.Play();
            Die();
        }

    }

    private void Die()
    {
        rig.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamege(int damage)
    {
        PlayerHealth -= damage;
        Debug.Log(PlayerHealth);

        if (PlayerHealth <= 0)
        {
            DeadSound.Play();
            Die();
        }

    }

}