using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoldiers : MonoBehaviour
{
    [SerializeField] private GameObject soldier;

    private PlayerMovement player;
    private BoxCollider2D box;

    public int soldiers = 0;
    private ItemCollector tiem;

    private void Awake()
    {
        tiem = GameObject.Find("Player").GetComponent<ItemCollector>();
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            player.moveSpeed = 0.1f;
            //player.mover = false;
            for (int i = 0; i < tiem.TotalSoldados; i++)
            {
                Debug.Log("epale");
                Vector2 PlayerPos = new Vector2(transform.position.x , transform.position.y + 0.5f);
                Instantiate(soldier, PlayerPos, Quaternion.identity);
                soldiers++;
            }
            Destroy(gameObject);

        }
        if (collision.CompareTag("soldierDecor"))
        {
            Destroy(collision.gameObject);
            soldiers--;
            Debug.Log(soldiers);
            if (soldiers==-tiem.TotalSoldados)
            {
                //player.mover = true;
                player.moveSpeed = 7f;
                Destroy(gameObject);   
            }
        }
    }

}
