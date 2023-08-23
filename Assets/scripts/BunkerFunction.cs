using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerFunction : MonoBehaviour
{

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;

    public int BunkerHealh = 100;
    [SerializeField] GameObject botiquin;

    private Animator anim;

    [SerializeField] private AudioSource explosion;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamege(int damage)
    {
        BunkerHealh -= damage;
        Debug.Log(BunkerHealh);
        if (BunkerHealh <= 0)
        {
            DestroyBunker();
            SpawnItem();
        }
    }

    public void DestroyBunker()
    {
        explosion.Play();
        anim.SetTrigger("Destroy");
        //Instantiate(botiquin, transform.position, transform.rotation);
        //Destroy(gameObject);
        Debug.Log("bunker destruido");
    }

    public void SpawnItem()
    {
        Vector2 EnemyPos = new Vector2(transform.position.x + 1, transform.position.y - 0.2f);
        Vector2 EnemyPos2 = new Vector2(transform.position.x + 2, transform.position.y - 0.2f);
        Vector2 EnemyPos3 = new Vector2(transform.position.x + 3, transform.position.y - 0.2f);
        Instantiate(Item1, EnemyPos, Quaternion.identity);
        Instantiate(Item2, EnemyPos2, Quaternion.identity);
        Instantiate(Item3, EnemyPos3, Quaternion.identity);
    }

}
