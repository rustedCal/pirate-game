using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    bool isPlayDed = false;
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(0.0f, speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "platform")// if platform touch water, destroy
        {
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Player")//if player touch water, kill
        {
            Debug.Log("Player is ded >:)");
            PlayerControl temp = collision.GetComponent<PlayerControl>();
            temp.killPlayer();
            speed = 0.0f;
        }
    }
}
