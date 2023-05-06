using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    [SerializeField] private Transform player;

    public void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
