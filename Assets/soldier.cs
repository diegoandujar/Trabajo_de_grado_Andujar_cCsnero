using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldier : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int CurrentWayPoint = 0; //0 y 1 porque son dos waypoints por los que pasa la plataforma, en este caso

    [SerializeField] private float speed = 2f;

    [SerializeField] private bool mover = false;

    private bool OnRange = false;
    [SerializeField] public bool estado = false;

    private Rigidbody2D rgb;

    [SerializeField] BoxCollider2D Notrigger;

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(waypoints[CurrentWayPoint].transform.position, transform.position) < .1f)
        {
            CurrentWayPoint++;
            if (CurrentWayPoint >= waypoints.Length)
            {
                rgb.bodyType = RigidbodyType2D.Static;
                CurrentWayPoint = 0;
                mover = false;
                Notrigger.enabled = false;
                
            }
        }
        if (mover)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWayPoint].transform.position, Time.deltaTime * speed);
        }

        if (OnRange == true && Input.GetKeyDown("c") && estado == false)
        {
            Notrigger.enabled = true;
            mover = true;
            estado = true;
            rgb.gravityScale = 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnRange = false;
        }
    }
}
