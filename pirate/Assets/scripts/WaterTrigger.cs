using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(0.0f, speed);
        Debug.Log(Time.time * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "platform")
        {
            Destroy(collision.gameObject);
        }
    }
}
