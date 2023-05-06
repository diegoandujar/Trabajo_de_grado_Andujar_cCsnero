using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 

    /// <summary>
    /// es mas eficiente tener el componente en vez de llamarlo repetidamente \\ project manager -> input manager
    /// </summary>
    /// 

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpSpeed = 7f;

    private bool right = true;

    private SpriteRenderer SpRen;
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    //audios
    [SerializeField] private AudioSource JumpingSound;

    

    // asi se tienen las animaciones de los movimientos en un mismo sitio
    private enum MovementState { idle, running, jumping, falling};

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        SpRen = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // getAxisRaw se detiene de una, sin el raw no se detiene de una sino que va disminuyendo poco a poco el movimiento

        // Jump y horizontal son direcciones a las teclas que unitiy nos da para esos movimientos horizontal(left right a and d) jump(space)

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w"))&& IsGrounded())
        {
            JumpingSound.Play();
            rb.velocity = new Vector2(rb.velocity.x , jumpSpeed);
        }

        AnimantionUpdate();
        
    }

    private void AnimantionUpdate()
    {
        // se llama al conjunto de "movimeintos", y se colocan en donde se necesitan para la transision
        MovementState state;

        if (dirX > 0f && !right)
        {

            flip();
            state = MovementState.running;

        }
        else if (dirX < 0f && right)
        {

            flip();
            state = MovementState.running;

        }
        else if(dirX > 0f && right)
        {
            state = MovementState.running;
        }
        else if(dirX < 0f && !right)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
           
            state = MovementState.jumping;
        } 
        else if (rb.velocity.y < -.1)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);

    }

    private void flip()
    {
        right = !right;

        transform.Rotate(0f, 180f, 0f);

    }

    private bool IsGrounded()
    {
        ///
        ///esto lo que crea es otra box sobre el box collider, y con la distancia se muve un pelo para ver si el personaje se encuentra sobre el suelo, ya que este estaria sobre el boxcollider del suelo
        ///
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down ,.1f, jumpableGround);
    }

}
