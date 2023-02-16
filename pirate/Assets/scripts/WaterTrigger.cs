using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    Rigidbody2D rigid;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "platform")
        {
            Destroy(collision.gameObject);
        }
    }
}
