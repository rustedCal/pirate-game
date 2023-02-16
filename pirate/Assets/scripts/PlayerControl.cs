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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        onGround = floorCollider.IsTouching(floorFilter);

        if (!jumped && onGround)
        {
            jumped = true;
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

    private void FixedUpdate()
    {
        if (jumped)
        {
            jumped = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetMouseButton(0))
        {
           //Debug.Log("i am a press");
            //rb.AddForce(Vector2.right * -horSpeed, ForceMode2D.Impulse); 
            //rb.velocity = Vector2.right * horSpeed;
            //rb.velocity = new  Vector2(horizontal * horSpeed, rb.velocity.y);
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
}