using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    public float horSpeed = 10f;
    Rigidbody2D rb;
    float horizontal;
    private Vector3 touchPosition;
    private Vector3 direction;
    private Animator anim;
    private SpriteRenderer sprite;

    [Header("Jumping")]
    public float jumpForce = 14;
    bool jumped = false;

    [Header("Ground")]
    bool onGround = false;
    public Collider2D floorCollider;
    public ContactFilter2D floorFilter;

    //audio
    AudioSource audio;
    public AudioClip jumpClip;
    //things
    bool isDead = false;






















































































































































































































    void Start()//initalize everything
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            onGround = floorCollider.IsTouching(floorFilter);

            if (!jumped && onGround)
            {
                jumped = true;
                audio.PlayOneShot(jumpClip);
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                direction = (touchPosition - transform.position);
                rb.velocity = new Vector2(direction.x * horSpeed, rb.velocity.y);
                Debug.Log(Input.touchCount);

                if (touch.phase == TouchPhase.Ended)
                {
                    rb.velocity = Vector2.zero;
                }
            }
            //UpdateAnimationUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (jumped)
            {
                jumped = false;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            //--===INPUT-MOVEMENT===--//
            if (Input.GetMouseButton(0))//pressed on screen
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//get mouse posiotion reletive to main camera
                Debug.Log(mousePos.x - transform.position.x);
                if (mousePos.x > transform.position.x)//right side of the player, go right
                {
                    rb.AddForce(Vector2.right * horSpeed);
                }
                else if (mousePos.x < transform.position.x)//left side of screen, go left
                {
                    rb.AddForce(Vector2.right * -horSpeed);
                }
            }
            //cansle out movement when not resiving active input
            else
            {
                rb.AddForce(new Vector2(-rb.velocity.x * 2, 0));//cansles out velocity by adding the - of itself and a intencity multiplyer
            }

        }
    }

    /*private void UpdateAnimationUpdate()
    {
        if (horizontal > 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (horizontal < 0)
        {
            anim.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }*/
    public float getPlayerY()
    {
        return rb.transform.position.y;
    }
    public void killPlayer()
    {
        //freeze player in place and play an animation
        isDead = true;//to stop other plarts of the script
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
        //[]add an animation thingie here
    }
}