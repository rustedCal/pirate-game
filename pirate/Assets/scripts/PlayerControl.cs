using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    public float horSpeed = 7.0f;
    Rigidbody2D rB;
    float horizontal;
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
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        onGround = floorCollider.IsTouching(floorFilter);

        if (!jumped && Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            jumped = true;
        }

        UpdateAnimationUpdate();
    }

    private void FixedUpdate()
    {
        rB.velocity = new Vector2(horizontal * horSpeed, rB.velocity.y);

        if (jumped)
        {
            jumped = false;
            rB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void UpdateAnimationUpdate()
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
    }
}