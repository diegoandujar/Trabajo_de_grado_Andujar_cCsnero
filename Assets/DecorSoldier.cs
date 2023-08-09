using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorSoldier : MonoBehaviour
{

    private float speed = 8f;
    private Rigidbody2D rgb;

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rgb.velocity = transform.right * speed;
    }

}
