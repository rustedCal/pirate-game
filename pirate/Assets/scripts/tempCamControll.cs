using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempCamControll : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Camera cam;
    public float PlatformOffset;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        cam = gameObject.GetComponent<Camera>();
    }
    private void Start()
    {
        rigidbody2d.velocity = new Vector2(0, 2);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {

    }
}
