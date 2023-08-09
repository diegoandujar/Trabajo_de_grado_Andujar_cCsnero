using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soldier : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int CurrentWayPoint = 0; //0 y 1 porque son dos waypoints por los que pasa la plataforma, en este caso

    [SerializeField] private float speed = 2f;

    private bool mover = false;
    private bool OnRange = false;
    private bool llego = false;
    private bool right = true;

    private PlayerMovement plmove;
    private Rigidbody2D rgb;
    private ItemCollector item;

    [SerializeField] BoxCollider2D Notrigger;

    private enum MovementState { Hurt, Move, Idle };
    private Animator anim;

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        item = GameObject.Find("Player").GetComponent<ItemCollector>();
        plmove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mover)
        {
            if (Vector2.Distance(waypoints[CurrentWayPoint].transform.position, transform.position) < 1f)
                {
                    Debug.Log("llegue");
                    mover = false;
                    llego = true;
                    
                }

            // hace que se mueva una distancia X con respecto al frame
            transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWayPoint].transform.position, Time.deltaTime * speed);
        }

        if (OnRange == true && Input.GetKeyDown("c"))
        {
            Debug.Log("Soldier");
            Debug.Log(plmove.mover + "---entrada---" + plmove.helping);
            plmove.mover = false;
            plmove.helping = true;
            item.salvados++;
            item.writeSalvados(item.salvados);
            Notrigger.enabled = true;
            mover = true;
            //estado = true;
            rgb.gravityScale = 1;
            Debug.Log(plmove.mover + "---salida---" + plmove.helping);
        }

        AnimantionUpdate();
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

    private void AnimantionUpdate()
    {
        //se llama al conjunto de "movimeintos", y se colocan en donde se necesitan para la transision
        MovementState state;
        if (llego == true && mover == false)
        {
            if (right == false)
            {
                flip();
                right = true;
            }
            state = MovementState.Idle;
            Debug.Log("idleeeee");
        }
        else if(llego == false && mover == true)
        {
            if (right == true)
            {
                flip();
                right = false;
            }
            state = MovementState.Move;
            Debug.Log("moveeeee");
        }
        else
        {
            state = MovementState.Hurt;
            Debug.Log("Hurt");
        }

        anim.SetInteger("State", (int)state);

    }

    private void flip()
    {

        transform.Rotate(0f, 180f, 0f);

    }

}
