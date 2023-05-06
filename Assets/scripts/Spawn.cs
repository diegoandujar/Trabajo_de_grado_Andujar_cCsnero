using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private GameObject gunHolder;
    private SpriteRenderer sp;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnItem()
    {
        Vector2 PlayerPos = new Vector2(player.position.x + 1, player.position.y -0.4f);
        Instantiate(item, PlayerPos, Quaternion.identity);
    }

}
