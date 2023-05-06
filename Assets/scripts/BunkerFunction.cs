using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerFunction : MonoBehaviour
{

    public int BunkerHealh = 100;
    [SerializeField] GameObject botiquin;

    private Animator anim;

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
        }
    }

    public void DestroyBunker()
    {
        anim.SetTrigger("Destroy");
        //Instantiate(botiquin, transform.position, transform.rotation);
        //Destroy(gameObject);
        Debug.Log("bunker destruido");
    }

}
